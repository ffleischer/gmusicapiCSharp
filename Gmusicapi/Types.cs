using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gmusicapi
{
	public class ArtistArtRef
	{
		//    'url': 'http://lh6.ggpht.com/...'
		public String url { get; set; }
	};

	public class Url
	{
		//    'url': 'http://lh6.ggpht.com/...'
		public String url { get; set; }
	};

	public class DescriptionAttribution
	{
		//	license_url: "http://creativecommons.org/licenses/by/4.0/legalcode"
		public string license_url { get; set; }
		//	source_url: ""
		public string source_url { get; set; }
		//	source_title: "Freebase"
		public string source_title { get; set; }
		//	kind: "sj#attribution"
		public string kind { get; set; }
		//	license_title: "Creative Commons Attribution CC-BY"
		public string license_title { get; set; }
	}

	[DebuggerDisplay("{title} - {artist}")]
	public class Track
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

	[DebuggerDisplay("{name}")]
	public class Playlist
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

	[DebuggerDisplay("{name} - {artist}")]
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
	[DebuggerDisplay("{name}")]
	public class ArtistInfo
	{
		//  'albums':[  # only if include_albums is True
		public List<Album> albums { get; set; }
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
		public List<Track> topTracks { get; set; }
		//'total_albums':21

		public int total_albums { get; set; }
	}

	public abstract class PlaylistsContents : Playlist
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
			public string nid { get; set; }
			public string trackType { get; set; }

			public Gmusicapi.Track track { get; set; }
		}

		public List<Track> tracks { get; set; }
	}

	public class SharedPlaylistsContents : PlaylistsContents
	{
	}

	public class UserPlaylistsContents : PlaylistsContents
	{
		public new class Track : PlaylistsContents.Track
		{
			//{[clientId, d719ed8e....]}
			public string clientId { get; set; }
			//'playlistId': '3d72c9b5-baad-4ff7-815d-cdef717e5d61',
			public string playlistId { get; set; }
		}

		public new List<Track> tracks { get; set; }
	}

	[DebuggerDisplay("{friendlyName}")]
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

	[DebuggerDisplay("{name}")]
	public class RadioStation
	{
		//'imageUrl': 'http://lh6.ggpht.com/...',
		public string imageUrl { get; set; }

		public List<Url> imageUrls { get; set; }

		//'kind': 'sj#radioStation',
		public string kind { get; set; }
		//'name': 'station',
		public string name { get; set; }
		//'deleted': False,
		public bool deleted { get; set; }
		//'lastModifiedTimestamp': '1370796487455005',
		public string lastModifiedTimestamp { get; set; }
		//'recentTimestamp': '1370796487454000',
		public string recentTimestamp { get; set; }
		//'clientId': 'c2639bf4-af24-4e4f-ab37-855fc89d15a1',
		public string clientId { get; set; }
		public Seed seed { get; set; }
		//'seed':
		public class Seed
		{
			//	'kind': 'sj#radioSeed',
			public string kind { get; set; }
			//	curatedStationId: "Lj5t64obht37ek53tyzadutr3w4"
			public string curatedStationId { get; set; }
			public string trackId { get; set; }
			public string genreId { get; set; }
			public string albumId { get; set; }
			//	'trackLockerId': '7df3aadd-9a18-3dc1-b92e-a7cf7619da7e'
			public string trackLockerId { get; set; }
			//	# possible keys:
			//	#  albumId, artistId, genreId, trackId, trackLockerId},

			//			newValue
			//	seedType: "3"
			public string seedType { get; set; }
			//	artistId: "Ajcdi7sbli5io6i5ivldfh3pcjq"
			public string artistId { get; set; }
			//	metadataSeed: {IronPython.Runtime.PythonDictionary}
			public MetadataSeed metadataSeed { get; set; }
			public class MetadataSeed
			{
				public Track track { get; set; }
				public Artist artist { get; set; }
				public class Artist
				{
					//artistId: "Ajcdi7sbli5io6i5ivldfh3pcjq"
					public string artistId { get; set; }
					//artistArtRef: "http://lh5.ggpht.com/uU_YjjxxGbbpTCuKtgplMiDnO9EJ5qEqK5hUXb0H6JHPu110D_qSHcMhFWIixd19F3CMfF4JsA"
					public string artistArtRef { get; set; }
					//name: "Bosse"
					public string name { get; set; }
					//artist_bio_attribution: {IronPython.Runtime.PythonDictionary}
					public DescriptionAttribution artist_bio_attribution { get; set; }
					//total_albums: 0
					public int total_albums { get; set; }
					//kind: "sj#artist"
					public string kind { get; set; }
					//artistBio: "Bosse is a German rock band from Braunschweig. The band's name comes from the lead singer, Axel Bosse."
					public string artistBio { get; set; }
				}
				public string kind { get; set; }
			}
		}
		//'id': '69f1bfce-308a-313e-9ed2-e50abe33a25d'
		public string id { get; set; }
	}

	public class SearchResult
	{
		public List<AlbumHit> album_hits { get; set; }

		public class AlbumHit
		{
			public class Album : Gmusicapi.Album
			{
				public DescriptionAttribution description_attribution { get; set; }
				//source["description_attribution"]
			}
			//'album':{},
			public Album album { get; set; }

			// 'best_result':True,
			public bool best_result { get; set; }
			// 'score':385.55609130859375,
			public double score { get; set; }
			// 'type':'3'
			public string type { get; set; }

			public bool navigational_result { get; set; }
		}


		public List<ArtistHit> artist_hits { get; set; }
		//'artist_hits':[
		//   {
		public class ArtistHit
		{
			public Artist artist { get; set; }
			//		 'artist':{
			public class Artist
			{
				//		 'artistArtRef':'http://lh6.ggpht.com/...',
				public string artistArtRef { get; set; }
				//		 'artistId':'Apoecs6off3y6k4h5nvqqos4b5e',
				public string artistId { get; set; }
				//		 'kind':'sj#artist',
				public string kind { get; set; }
				//		 'name':'Amorphis'
				public string name { get; set; }

				public DescriptionAttribution artist_bio_attribution { get; set; }				
			}
			//	  'score':237.86375427246094,
			public double score { get; set; }
			//	  'type':'2'
			public string type { get; set; }
			public bool navigational_result { get; set; }
			public bool best_result { get; set; }
		}

		public List<SongHit> song_hits { get; set; }

		public class SongHit
		{
			//'score':105.23198699951172,
			public double score { get; set; }
			//'track':{},
			public Track track { get; set; }
			// 'type':'1'
			public string type { get; set; }
			public bool navigational_result { get; set; }
			public bool best_result { get; set; }
		}

		public List<PlaylistHit> playlist_hits { get; set; }

		public class PlaylistHit
		{
			//'score': 0.0,
			public double score { get; set; }

			public Playlist playlist { get; set; }
			//'playlist':{
			public class Playlist
			{
				//	'albumArtRef':[
				public List<Url> albumArtRef { get; set; }
				//	   {
				//		  'url':'http://lh4.ggpht.com/...'
				//	   }
				//	],
				//	'description': 'Krasnoyarsk concert setlist 29.09.2013',
				public string description { get; set; }
				//	'kind': 'sj#playlist',
				public string kind { get; set; }
				//	'name': 'Amorphis Setlist',
				public string name { get; set; }
				//	'ownerName': 'Ilya Makarov',
				public string ownerName { get; set; }
				//	'ownerProfilePhotoUrl': 'http://lh6.googleusercontent.com/...',
				public string ownerProfilePhotoUrl { get; set; }
				//	'shareToken': 'AMaBXymmMfeA8iwoEWWI9Z1A...',
				public string shareToken { get; set; }
				//	'type': 'SHARED'
				public string type { get; set; }
				//},
			}
			//'type': '4'
			public string type { get; set; }
		}
	}

	public class AlbumInfo : Album
	{
		public List<Track> tracks { get; set; }
	}

	[DebuggerDisplay("{name}")]
	public class Genre
	{
		//'name': 'Alternative/Indie',
		public string name { get; set; }
		//'id': 'ALTERNATIVE_INDIE'
		public string id { get; set; }
		public string parentId { get; set; }
		//'kind': 'sj#musicGenre',
		public string kind { get; set; }

		public List<string> children { get; set; }
		//'children': [             # this key may not be present
		//'images': [
		public List<Url> images { get; set; }
	}


	public enum GoogleMusicType : int
	{
		Purchased = 1,
		Uploaded = 2,
		Matched = 6
	}
}
