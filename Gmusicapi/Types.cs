using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gmusicapi
{
    public class GoogleMusicSong
    {
        public class PrimaryVideo
        {
            public class Thumbnail
            {
                public int width { get; set; }
                public int height { get; set; }
                public String url { get; set; }
            }

            //[DataMember(Name="url")]
            public String kind { get; set; }
            public String id { get; set; }
            public List<Thumbnail> thumbnails { get; set; }
        };


        public class TrackOrigin
        {
            //[DataMember(Name="url")]
            public String origin { get; set; }
        };

        //'comment':'',
        public string comment { get; set; }
        //'rating':'0',
        public string rating { get; set; }
        //'albumArtRef':[
        public List<AlbumArtRef> albumArtRef { get; set; }
        //  {
        public class AlbumArtRef
        {
            //[DataMember(Name="url")]
            public String url { get; set; }
        };

        //'artistId':[
        //  'Aod62yyj3u3xsjtooghh2glwsdi'
        //],
        public List<string> artistId { get; set; }
        //'composer':'',
        public string composer { get; set; }
        //'year':2011,
        public int year { get; set; }
        //'creationTimestamp':'1330879409467830',
        public string creationTimestamp { get; set; }
        //'id':'5924d75a-931c-30ed-8790-f7fce8943c85',
        public string id { get; set; }
        //'album':'Heritage ',
        public string album { get; set; }
        //'totalDiscCount':0,
        public int totalDiscCount { get; set; }
        //'title':'Haxprocess',
        public string title { get; set; }
        //'recentTimestamp':'1372040508935000',
        public string recentTimestamp { get; set; }
        //'albumArtist':'',
        public string albumArtist { get; set; }
        //'trackNumber':6,
        public int trackNumber { get; set; }
        //'discNumber':0,
        public int discNumber { get; set; }
        //'deleted':False,
        public bool deleted { get; set; }
        //'storeId':'Txsffypukmmeg3iwl3w5a5s3vzy',
        public string storeId { get; set; }
        //'nid':'Txsffypukmmeg3iwl3w5a5s3vzy',
        public string nid { get; set; }
        //'totalTrackCount':10,
        public int totalTrackCount { get; set; }
        //'estimatedSize':'17229205',
        public string estimatedSize { get; set; }
        //'albumId':'Bdkf6ywxmrhflvtasnayxlkgpcm',
        public string albumId { get; set; }
        //'beatsPerMinute':0,
        public int beatsPerMinute { get; set; }
        //'genre':'Progressive Metal',
        public string genre { get; set; }
        //'playCount':7,
        public int playCount { get; set; }
        //'artistArtRef':[
        public List<ArtistArtRef> artistArtRef { get; set; }
        public class ArtistArtRef
        {
            //    'url': 'http://lh6.ggpht.com/...'
            public String url { get; set; }
        };
        //],

        //'kind':'sj#track',
        public string kind { get; set; }
        //'artist':'Opeth',
        public string artist { get; set; }
        //'lastModifiedTimestamp':'1330881158830924',
        public string lastModifiedTimestamp { get; set; }
        //'clientId':'+eGFGTbiyMktbPuvB5MfsA',
        public string clientId { get; set; }
        //'durationMillis':'418000'
        public string durationMillis { get; set; }

        public string trackType { get; set; }
        public string contentType { get; set; }

        public List<TrackOrigin> trackOrigin { get; set; }

        public PrimaryVideo primaryVideo { get; set; }

        public bool albumAvailableForPurchase { get; set; }
        public bool trackAvailableForPurchase { get; set; }
        public bool trackAvailableForSubscription { get; set; }
        public string lastRatingChangeTimestamp { get; set; }
        // }
    }

    public class GoogleMusicPlaylist
    {
        public string description { get; set; }
        //'type': 'USER_GENERATED',
        public string type { get; set; }
        //'kind': 'sj#playlist',
        public string kind { get; set; }
        //'name': 'Something Mix',
        public string name { get; set; }
        //'deleted': False,
        public bool deleted { get; set; }
        //'lastModifiedTimestamp': '1325458766483033',
        public string lastModifiedTimestamp { get; set; }
        //'recentTimestamp': '1325458766479000',
        public string recentTimestamp { get; set; }
        //'shareToken': '<long string>',
        public string shareToken { get; set; }
        //'ownerProfilePhotoUrl': 'http://lh3.googleusercontent.com/...',
        public string ownerProfilePhotoUrl { get; set; }
        //'ownerName': 'Simon Weber',
        public string ownerName { get; set; }
        //'accessControlled': False,  # has to do with shared playlists
        public bool accessControlled { get; set; }
        //'creationTimestamp': '1325285553626172',
        public string creationTimestamp { get; set; }
        //'id': '3d72c9b5-baad-4ff7-815d-cdef717e5d61'
        public string id { get; set; }
    }

    public class GoogleArtistInfo
    {
        //  'albums':[  # only if include_albums is True
        public List<Album> albums { get; set; }
        //  {
        public class Album
        {
            //    'albumArtRef':'http://lh6.ggpht.com/...',
            public string albumArtRef { get; set; }
            //    'albumArtist':'Amorphis',
            public string albumArtist { get; set; }
            //    'albumId':'Bfr2onjv7g7tm4rzosewnnwxxyy',
            public string albumId { get; set; }
            //    'artist':'Amorphis',
            public string artist { get; set; }
            //    'artistId':[
            //      'Apoecs6off3y6k4h5nvqqos4b5e'
            //    ],
            public List<string> artistId { get; set; }
            //    'kind':'sj#album',
            public string kind { get; set; }
            //    'name':'Circle',
            public string name { get; set; }
            //    'year':2013
            public int year { get; set; }
            //  },
        }
        //],
        //'artistArtRef':  'http://lh6.ggpht.com/...',
        public string artistArtRef { get; set; }
        //'artistId':'Apoecs6off3y6k4h5nvqqos4b5e',
        public string artistId { get; set; }
        //'kind':'sj#artist',
        public string kind { get; set; }
        //'name':'Amorphis',
        public string name { get; set; }
        //'related_artists':[  # only if max_rel_artists > 0
        public List<RelatedArtists> related_artists { get; set; }
        //  {
        public class RelatedArtists
        {
            //    'artistArtRef':      'http://lh5.ggpht.com/...',
            public string artistArtRef { get; set; }
            //    'artistId':'Aheqc7kveljtq7rptd7cy5gvk2q',
            public string artistId { get; set; }
            //    'kind':'sj#artist',
            public string kind { get; set; }
            //    'name':'Dark Tranquillity'
            public string name { get; set; }
            //  }
            //],
        }

        //'topTracks':[  # only if max_top_tracks > 0
        public List<GoogleMusicSong> topTracks { get; set; }
        //'total_albums':21

        public int total_albums { get; set; }
    }

    public abstract class GoogleMusicPlaylistsContents : GoogleMusicPlaylist
    {
        public class Track
        {
            //'kind': 'sj#playlistEntry',
            public string kind { get; set; }
            //'deleted': False,
            public bool deleted { get; set; }
            //'trackId': '2bb0ab1c-ce1a-3c0f-9217-a06da207b7a7',
            public string trackId { get; set; }
            //'lastModifiedTimestamp': '1325285553655027',
            public string lastModifiedTimestamp { get; set; }
            //'absolutePosition': '01729382256910287871',  # denotes playlist ordering
            public string absolutePosition { get; set; }
            //'source': '1',  # ??
            public string source { get; set; }
            //'creationTimestamp': '1325285553655027',
            public string creationTimestamp { get; set; }
            //'id': 'c9f1aff5'
            public string id { get; set; }

            public GoogleMusicSong track { get; set; }
        }

        public List<Track> tracks { get; set; }
    }

    public class GoogleMusicSharedPlaylistsContents : GoogleMusicPlaylistsContents
    {
    }

    public class GoogleMusicUserPlaylistsContents : GoogleMusicPlaylistsContents
    {
        public new class Track : GoogleMusicPlaylistsContents.Track
        {
            //{[clientId, d719ed8e....]}
            public string clientId { get; set; }
            //'playlistId': '3d72c9b5-baad-4ff7-815d-cdef717e5d61',
            public string playlistId { get; set; }
        }

        public new List<Track> tracks { get; set; }
    }

    public class RegisteredDevice
    {
        //u'kind':               u'sj#devicemanagementinfo',
        public string kind { get; set; }
        //u'friendlyName':       u'my-hostname',
        public string friendlyName { get; set; }
        //u'id':                 u'AA:BB:CC:11:22:33',
        public string id { get; set; }
        //u'lastAccessedTimeMs': u'1394138679694',
        public string lastAccessedTimeMs { get; set; }
        //u'type':               u'DESKTOP_APP'
        public string type { get; set; }
        //{[smartPhone, False]}
        public bool smartPhone { get; set; }
    }

    public enum GoogleMusicType : int
    {
        Purchased = 1,
        Uploaded = 2,
        Matched = 6
    }
}
