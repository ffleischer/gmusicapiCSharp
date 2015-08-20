using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gmusicapi
{
	internal static class ObjectExtensions
	{
		private static class New<T>
		{
			public static readonly Func<T> Instance = Creator();

			static Func<T> Creator()
			{
				Type t = typeof(T);
				if (t == typeof(string))
					return Expression.Lambda<Func<T>>(Expression.Constant(string.Empty)).Compile();

				if (t.HasDefaultConstructor())
					return Expression.Lambda<Func<T>>(Expression.New(t)).Compile();

				return () => (T)FormatterServices.GetUninitializedObject(t);
			}
		}

		private static bool HasDefaultConstructor(this Type t)
		{
			return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
		}

		public static T ToObject<T>(this IronPython.Runtime.PythonDictionary source)
			where T : class, new()
		{
			T someObject = new T();
			Type someObjectType = someObject.GetType();

			foreach (var item in source)
			{
				try
				{
					var newValue = item.Value;
					PropertyInfo prop = null;
					
					//try to get the property from the sub class
					prop = someObjectType.GetProperty((String)item.Key,BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
					if(prop == null)
					{
						//serch in the base classes
						prop = someObjectType.GetProperty((String)item.Key);
					}
					
					if (newValue.GetType() == typeof(IronPython.Runtime.List))
					{

						MethodInfo method = typeof(ObjectExtensions).GetMethod("ToList");
						MethodInfo generic = method.MakeGenericMethod(prop.PropertyType.GenericTypeArguments[0]);
						newValue = generic.Invoke(null, new object[] { (IronPython.Runtime.List)newValue });
					}

					else if (newValue.GetType() == typeof(IronPython.Runtime.PythonDictionary))
					{
						MethodInfo method = typeof(ObjectExtensions).GetMethod("ToObject");
						MethodInfo generic = method.MakeGenericMethod(prop.PropertyType);
						newValue = generic.Invoke(null, new object[] { (IronPython.Runtime.PythonDictionary)newValue });
					}

					prop.SetValue(someObject, newValue, null);

				}
				catch (Exception ex)
				{
					Console.WriteLine("Unable to set:" + item.Key);
					Console.WriteLine(ex.Message);
				}
			}

			return someObject;
		}

		public static List<T> ToList<T>(this IronPython.Runtime.List source)
		   where T : class
		{
			T someObject = New<T>.Instance();
			List<T> someList = new List<T>();
			Type someObjectType = someObject.GetType();

			foreach (var item in source)
			{
				T newValue = null;
				try
				{
					if (item.GetType() == typeof(IronPython.Runtime.List))
					{
						MethodInfo method = typeof(ObjectExtensions).GetMethod("ToList");
						MethodInfo generic = method.MakeGenericMethod(someObjectType.GenericTypeArguments[0]);
						newValue = (T)generic.Invoke(null, new object[] { (IronPython.Runtime.PythonDictionary)item });
					}
					else if (item.GetType() == typeof(IronPython.Runtime.PythonDictionary))
					{
						MethodInfo method = typeof(ObjectExtensions).GetMethod("ToObject");
						MethodInfo generic = method.MakeGenericMethod(someObjectType);
						newValue = (T)generic.Invoke(null, new object[] { (IronPython.Runtime.PythonDictionary)item });
					}
					else
					{
						newValue = (T)item;
					}

					someList.Add(newValue);

				}
				catch (Exception ex)
				{
					Console.WriteLine("Unable to add:" + newValue.ToString());
					Console.WriteLine(ex.Message);
				}
			}

			return someList;
		}

		public static IronPython.Runtime.List AsPyList(this IList source)
		{
			var pyList = new IronPython.Runtime.List();

			Type someObjectType = source.GetType();

			foreach (var item in source)
			{
				object newValue = null;
				try
				{
					if ((item.GetType().GetInterfaces().Contains(typeof(System.Collections.IList))))
					{
						MethodInfo method = typeof(ObjectExtensions).GetMethod("AsPyList");
						MethodInfo generic = method.MakeGenericMethod(someObjectType.GenericTypeArguments[0]);
						newValue = generic.Invoke(null, new object[] {item});
					}
					else if (item.GetType().Namespace == typeof(ObjectExtensions).Namespace)
					{
						MethodInfo method = typeof(ObjectExtensions).GetMethod("AsPyDictionary");
						newValue = method.Invoke(null, new object[] { item });
					}
					else
					{
						newValue = item;
					}

					pyList.Add(newValue);

				}
				catch (Exception ex)
				{
					Console.WriteLine("Unable to add:" + newValue.ToString());
					Console.WriteLine(ex.Message);
				}
			}
			return pyList;
		}

		public static IronPython.Runtime.PythonDictionary AsPyDictionary(this object source)//, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
		{
			var pyDic = new IronPython.Runtime.PythonDictionary();
			Type someObjectType = source.GetType();
			foreach (var item in source.GetType().GetProperties())
			{
				object newValue = null;
				try
				{
					if ((item.PropertyType.GetInterfaces().Contains(typeof(System.Collections.IList))))
					{
						MethodInfo method = typeof(ObjectExtensions).GetMethod("AsPyList");
						var value = item.GetValue(source, null);
						if (value != null)
						{
							newValue = method.Invoke(null, new object[] { item.GetValue(source, null) });
						}
					}
					else if (item.PropertyType.Namespace == typeof(ObjectExtensions).Namespace)
					{
						MethodInfo method = typeof(ObjectExtensions).GetMethod("AsPyDictionary");
						var value = item.GetValue(source, null);
						if (value != null)
						{
							newValue = method.Invoke(null, new object[] { item.GetValue(source, null) });
						}
					}
					else
					{
						newValue = item.GetValue(source, null);
					}

					//pyDic.Add(item.Name, item.GetValue(source, null));
					if(newValue != null)
					{
						//we encode strings as unicode
						if(newValue.GetType() == typeof(string))
						{
							pyDic.Add(item.Name, Encoding.Unicode.GetString(Encoding.Unicode.GetBytes((string)newValue)));
						}
						else
						{
							pyDic.Add(item.Name, newValue);
						}
					}
					

				}
				catch (Exception ex)
				{
					Console.WriteLine("Unable to add:" + newValue.ToString());
					Console.WriteLine(ex.Message);
				}
			}


			return pyDic;
		}
	}
}
