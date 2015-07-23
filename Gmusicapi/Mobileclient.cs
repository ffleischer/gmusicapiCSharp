using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmusicapi
{
	public class Mobileclient
	{
		private static ScriptEngine pyEngine = null;
		private dynamic pyMobileclient;

		public Mobileclient(bool debug_logging=true, bool validate=true, bool verify_ssl=true)
		{
			if (pyEngine == null)
			{
				Dictionary<string, object> options = new Dictionary<string, object>();
				options["FullFrames"] = true;
				//options["Debug"] = true;
				pyEngine = Python.CreateEngine(options);
			}

			ScriptScope pyScope = pyEngine.CreateScope();
			
			pyEngine.Execute("import sys", pyScope);
			//needed for the IronPyCrypto.dll
			pyEngine.Execute("sys.path.insert(0, '" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "')", pyScope);
			//import Lib from zip file
			pyEngine.Execute("sys.path.insert(1, '" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "Resources/Lib.zip')", pyScope);
			pyEngine.Execute("sys.path.insert(2, '" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "Resources/Lib.zip/site-packages')", pyScope);

			pyEngine.Execute("from gmusicapi import Mobileclient", pyScope);
			dynamic typeMobileclient = pyScope.GetVariable("Mobileclient");

			pyMobileclient = typeMobileclient(debug_logging, validate, verify_ssl);
		}

		public bool login(string email, string password, string android_id)
		{
			return pyMobileclient.login(email, password, android_id);
		}

		public bool authenticated { get { return pyMobileclient.is_authenticated(); } }
		public string android_id { get { return pyMobileclient.android_id; } }

		public bool logout()
		{
			return pyMobileclient.logout();
		}



		#region Songs

		public List<GoogleMusicSong> get_all_songs(bool incremental = false, bool include_deleted = false)
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_all_songs(incremental, include_deleted);
			return tmp.ToList<GoogleMusicSong>();
		}

		public string get_stream_url(string song_id, string device_id = null, string quality = "hi")
		{
			return pyMobileclient.get_stream_url(song_id, device_id, quality);
		}

		public string change_song_metadata(List<GoogleMusicSong> songs)
		{
			throw new NotImplementedException();
			//TODO convert to python List/Dictionary
			return pyMobileclient.change_song_metadata(songs);
		}

		public string delete_songs(List<string> library_song_ids)
		{
			throw new NotImplementedException();
			//TODO convert to python List/Dictionary
			return pyMobileclient.delete_songs(library_song_ids);
		}

		public List<GoogleMusicSong> get_promoted_songs()
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_promoted_songs();
			return tmp.ToList<GoogleMusicSong>();
		}

		public void increment_song_playcount(string song_id, int plays = 1, DateTime playtime = default(DateTime))
		{
			throw new NotImplementedException();
			//TODO convert to python Datetime?
			pyMobileclient.increment_song_playcount(song_id, plays, playtime);
			return;
		}
		#endregion

		#region Playlists
		public List<GoogleMusicPlaylist> get_all_playlists(bool incremental = false, bool include_deleted = false)
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_all_playlists(incremental, include_deleted);
			return tmp.ToList<GoogleMusicPlaylist>();
		}

		public List<GoogleMusicUserPlaylistsContents> get_all_user_playlist_contents()
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_all_user_playlist_contents();
			return tmp.ToList<GoogleMusicUserPlaylistsContents>();
		}

		public string create_playlist(string name, string description = "", bool Public = false)
		{
			return pyMobileclient.create_playlist(name, description, Public);
		}

		public string delete_playlist(string playlist_id)
		{
			return pyMobileclient.delete_playlist(playlist_id);
		}

		public string edit_playlist(string playlist_id, string new_name = null, string new_description = null, bool Public = false)
		{
			return pyMobileclient.edit_playlist(playlist_id, new_name, new_description, Public);
		}

		public List<string> add_songs_to_playlist(string playlist_id, List<string> song_ids)
		{
			throw new NotImplementedException();
			//TODO convert to python List
			IronPython.Runtime.List tmp = pyMobileclient.add_songs_to_playlist(playlist_id, song_ids);
			return tmp.ToList<string>();

		}

		public string reorder_playlist_entry(GoogleMusicPlaylistsContents.Track entry, GoogleMusicPlaylistsContents.Track to_follow_entry = null, GoogleMusicPlaylistsContents.Track to_precede_entry = null)
		{
			throw new NotImplementedException();
			//TODO convert to python dict
			return pyMobileclient.reorder_playlist_entry(entry, to_follow_entry, to_precede_entry);
		}

		public List<string> remove_entries_from_playlist(List<string> entry_ids)
		{
			throw new NotImplementedException();
			//TODO convert to python List
			IronPython.Runtime.List tmp = pyMobileclient.remove_entries_from_playlist(entry_ids);
			return tmp.ToList<string>();
		}

		public List<GoogleMusicSharedPlaylistsContents.Track> get_shared_playlist_contents(string share_token)
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_shared_playlist_contents(share_token);
			return tmp.ToList<GoogleMusicSharedPlaylistsContents.Track>();
		}


		#endregion

		#region Other

		public List<RegisteredDevice> get_registered_devices()
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_registered_devices();
			return tmp.ToList<RegisteredDevice>();
		}

		#endregion

		public GoogleArtistInfo get_artist_info(string artist_id, bool include_albums = true, int max_top_tracks = 5, int max_rel_artist = 5)
		{
			IronPython.Runtime.PythonDictionary tmp = pyMobileclient.get_artist_info(artist_id, include_albums, max_top_tracks, max_rel_artist);
			return tmp.ToObject<GoogleArtistInfo>();
		}




	}
}
