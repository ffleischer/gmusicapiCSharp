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
		private dynamic pyConvDateTime;

		#region Setup and Login

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
			pyEngine.Execute("import datetime", pyScope);
			pyEngine.Execute("from System import DateTime", pyScope);

			var pyConvDateTimeSrc =
				@"def ConvToPyDateTime(CSDateTime):
					if CSDateTime.Ticks == 0 :
						return None
					else:
						return datetime.datetime(CSDateTime)";
			pyEngine.Execute(pyConvDateTimeSrc, pyScope);

			dynamic typeMobileclient = pyScope.GetVariable("Mobileclient");
			pyConvDateTime = pyScope.GetVariable("ConvToPyDateTime");

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

		#endregion

		#region Songs

		public List<Track> get_all_songs(bool incremental = false, bool include_deleted = false)
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_all_songs(incremental, include_deleted);
			return tmp.ToList<Track>();
		}

		public string get_stream_url(string song_id, string device_id = null, string quality = "hi")
		{
			return pyMobileclient.get_stream_url(song_id, device_id, quality);
		}

		public string change_song_metadata(List<Track> songs)
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

		public List<Track> get_promoted_songs()
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_promoted_songs();
			return tmp.ToList<Track>();
		}

		public void increment_song_playcount(string song_id, int plays = 1, DateTime playtime = default(DateTime))
		{
			dynamic pyDateTime = pyConvDateTime(playtime);
			pyMobileclient.increment_song_playcount(song_id, plays, pyDateTime);
			return;
		}
		#endregion

		#region Playlists
		public List<Playlist> get_all_playlists(bool incremental = false, bool include_deleted = false)
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_all_playlists(incremental, include_deleted);
			return tmp.ToList<Playlist>();
		}

		public List<UserPlaylistsContents> get_all_user_playlist_contents()
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_all_user_playlist_contents();
			return tmp.ToList<UserPlaylistsContents>();
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

		public string reorder_playlist_entry(PlaylistsContents.Track entry, PlaylistsContents.Track to_follow_entry = null, PlaylistsContents.Track to_precede_entry = null)
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

		public List<SharedPlaylistsContents.Track> get_shared_playlist_contents(string share_token)
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_shared_playlist_contents(share_token);
			return tmp.ToList<SharedPlaylistsContents.Track>();
		}


		#endregion

		#region Other

		public List<RegisteredDevice> get_registered_devices()
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_registered_devices();
			return tmp.ToList<RegisteredDevice>();
		}

		#endregion

		#region All Access Radio

		public List<RadioStation> get_all_stations(bool incremental=false,bool include_deleted=false,DateTime updated_after= default(DateTime))
		{

			dynamic pyDateTime = pyConvDateTime(updated_after);
			IronPython.Runtime.List tmp = pyMobileclient.get_all_stations(incremental, include_deleted, pyDateTime);
			return tmp.ToList<RadioStation>();
		}

		public List<Track> get_station_tracks(string station_id,int num_tracks=25,List<string> recently_played_ids=null)
		{
			//TODO convert to python List
			IronPython.Runtime.List tmp = pyMobileclient.get_station_tracks(station_id, num_tracks, recently_played_ids);
			return tmp.ToList<Track>();
		}

		public string create_station(string name,string track_id=null,string artist_id=null,string album_id=null, string genre_id=null)
		{
			//TODO null == None????
			return pyMobileclient.create_station(name, track_id, artist_id, album_id, genre_id);
		}

		public List<string> delete_stations(List<string> station_ids)
		{
			//TODO convert to python List
			IronPython.Runtime.List tmp = pyMobileclient.delete_stations(station_ids);
			return tmp.ToList<string>();
		}
		#endregion

		#region Other All Access features

		public SearchResult search_all_access(string query, int max_results=50)
		{
			IronPython.Runtime.PythonDictionary tmp = pyMobileclient.search_all_access(query, max_results);
			return tmp.ToObject<SearchResult>();
		}

		public string add_aa_track(string aa_song_id)
		{
			return pyMobileclient.add_aa_track(aa_song_id);
		}

		public ArtistInfo get_artist_info(string artist_id, bool include_albums = true, int max_top_tracks = 5, int max_rel_artist = 5)
		{
			IronPython.Runtime.PythonDictionary tmp = pyMobileclient.get_artist_info(artist_id, include_albums, max_top_tracks, max_rel_artist);
			return tmp.ToObject<ArtistInfo>();
		}

		public AlbumInfo get_album_info(string album_id, bool include_tracks = true)
		{
			IronPython.Runtime.PythonDictionary tmp = pyMobileclient.get_album_info(album_id, include_tracks);
			return tmp.ToObject<AlbumInfo>();
		}

		public Track get_track_info(string store_track_id)
		{
			IronPython.Runtime.PythonDictionary tmp = pyMobileclient.get_track_info(store_track_id);
			return tmp.ToObject<Track>();
		}

		public List<Genre> get_genres(string parent_genre_id=null)
		{
			IronPython.Runtime.List tmp = pyMobileclient.get_genres(parent_genre_id);
			return tmp.ToList<Genre>();
		}
		#endregion



	}
}
