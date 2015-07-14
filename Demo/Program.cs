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
            const string ironDir = @"dir\of\ironpython";

            const string email = "user@gmail.com";
            const string password = "password";
            const string android_id = "ffffffffffffffff";

            var api = new Mobileclient(ironDir);
            api.login(email, password, android_id);

            var devices = api.get_registered_devices();

            var tracks = api.get_all_songs();

            var info = api.get_artist_info(tracks[0].artistId[0]);
            var pl = api.get_all_user_playlist_contents();

            var subscribed_to = api.get_all_playlists().Where(wh => wh.type == "SHARED").ToList();
            var share_tok = subscribed_to[0].shareToken;
            var shared_tracks = api.get_shared_playlist_contents(share_tok);

            api.logout();
        }
    }
}
