using Gmusicapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			const string email = "user@gmail.com";
			const string password = "password";
			const string android_id = "ffffffffffffffff";

			//the verify_ssl option currently causes a SSL Exception
			var api = new Mobileclient(false,true,false);
			
			api.login(email, password, android_id);

			var search = api.search_all_access("Marsimoto");
			if(search.song_hits.Count > 5)
			{
				var playlist_id = api.create_playlist("Marsi_Demo", "A short test from gmusicapi");
				var songs_to_add = new List<string>();
				for (int i = 0; i < 5; i++)
				{
					songs_to_add.Add(search.song_hits[i].track.storeId);
				}
				api.add_songs_to_playlist(playlist_id, songs_to_add);

				var playlist = api.get_all_user_playlist_contents().FirstOrDefault(x => x.id == playlist_id);

				//TODO this doesn't work
				//api.reorder_playlist_entry(playlist.tracks[4], playlist.tracks[0], playlist.tracks[1]);

				foreach (var item in playlist.tracks)
				{
					api.remove_entries_from_playlist(new List<string> { item.id });
				}

				api.delete_playlist(playlist_id);
			}


			var devices = api.get_registered_devices();

			var tracks = api.get_all_songs();

			var info = api.get_artist_info(tracks[0].artistId[0]);
			var pl = api.get_all_user_playlist_contents();

			var subscribed_to = api.get_all_playlists().Where(wh => wh.type == "SHARED").ToList();
			var share_tok = subscribed_to[0].shareToken;
			var shared_tracks = api.get_shared_playlist_contents(share_tok);

			var genres = api.get_genres();
			var sub_genres = api.get_genres("POP");
			var allStations = api.get_all_stations();
			var updatedStations = api.get_all_stations(false, false, DateTime.Now.AddMonths(-6));

			api.logout();
		}
	}
}
