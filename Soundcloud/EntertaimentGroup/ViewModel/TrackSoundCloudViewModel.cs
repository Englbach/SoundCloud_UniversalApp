using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntertaimentGroup.Model;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Foundation;

namespace EntertaimentGroup.ViewModel
{
    public class TrackSoundCloudViewModel
    {
        public ObservableCollection<TracksSoundCloud.Track> TrackCollection;
        public ObservableCollection<SearchSoundCloud.Collection> SearchTrackCollection { get; set; }
        public ObservableCollection<PlaylistSoundCloud.Track> PlaylistCollection;
        public ObservableCollection<RootObject> User = new ObservableCollection<RootObject>();
        public ObservableCollection<UserSoundCloud.Collection> UserTrack = new ObservableCollection<UserSoundCloud.Collection>();



        
        /*
        public void GetOffset(string next_url, int _t)
        {
            Uri uri = new Uri(next_url);
            WwwFormUrlDecoder _decover = new WwwFormUrlDecoder(uri.Query);
            int offset;
            offset=(Convert.ToInt32(_decover.GetFirstValueByName("offset")));
            _t= offset;
        }
        */
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public async Task GetTrackAsyncTask(string link)
        {
            var result = await StaticMethod.GetJsonStringTask(link);
            TrackCollection = new ObservableCollection<TracksSoundCloud.Track>();
            if (result!=null)
            {
                var getItem = JsonConvert.DeserializeObject<TracksSoundCloud.RootObject>(result);
                //GetOffset(getItem.next_href,t);

                if (getItem != null)
                {
                   
                    foreach (var item in getItem.tracks)
                    {
                        TrackCollection.Add(item);
                    }
                    
                }
                else
                    return;

                

            }
        }
        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public async Task GetPlaylistAsyncTask(string link)
        {

            var result = await StaticMethod.GetJsonStringTask(link);
            PlaylistCollection = new ObservableCollection<PlaylistSoundCloud.Track>();
            if (result!=null)
            {
                var getItem = JsonConvert.DeserializeObject<PlaylistSoundCloud.RootObject>(result);
                foreach(var item in getItem.tracks)
                {
                    PlaylistCollection.Add(item);
                }
              
            }
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public async Task GetSearchCollectionAsyncTask(string link)
        {
            var result = await StaticMethod.GetJsonStringTask(link);
            
            if (result != null)
            {
                var getItem = JsonConvert.DeserializeObject<SearchSoundCloud.RootObject>(result);
                SearchTrackCollection = new ObservableCollection<SearchSoundCloud.Collection>();
                foreach (var item in getItem.collection)
                {
                    SearchTrackCollection.Add(item);
                }
                
            }
        }
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public async Task GetTrackCollectionUserAsyncTask(string link)
        {
            var result = await StaticMethod.GetJsonStringTask(link);
            if (result != null)
            {
                var getItem = JsonConvert.DeserializeObject<UserSoundCloud.RootObject>(result);
   
                foreach (var item in getItem.collection)
                {
                    UserTrack.Add(item);
                }
                //Next_href.Add(getItem.next_href);
            }
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public async void GetUserInforAsyncTask(string link,string linkuser, ImageBrush img, TextBlock username, TextBlock follower, TextBlock following, TextBlock tracks )
        {
            try
            {
                var result = await StaticMethod.GetJsonStringTask(linkuser);
                var getItem = JsonConvert.DeserializeObject<RootObject>(result);
                img.ImageSource = new BitmapImage(new Uri(getItem.avatar_url));
                username.Text = getItem.username;
                follower.Text = getItem.followers_count.ToString();
                following.Text = getItem.followings_count.ToString();
                tracks.Text = getItem.track_count.ToString();
            }
            catch(Exception)
            {
                return;
            }
            
            
        }


        ObservableCollection<MenuMainPage> List = new ObservableCollection<MenuMainPage>();
        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="owner"></param>
        /// <param name="kind"></param>
        /// <param name="thumb"></param>
        /// <returns></returns>
        public ObservableCollection<MenuMainPage> GetHistoryItem(string tile, string owner, string kind,string thumb)
        {
            //List = new ObservableCollection<MenuMainPage>();
            List.Add(new MenuMainPage { name = tile, thumbail = thumb, owner = owner, kind = kind });
            return List;
        }

/// <summary>
/// ///////
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
        public async Task<string> Getlinkdownload(int id,string _api_key)
        {
            string link="";
            var result = await StaticMethod.GetJsonStringTask("https://api.soundcloud.com/i1/tracks/" + id + "/streams?client_id="+_api_key);
            if(result!=null)
            {
                var Getlink = JsonConvert.DeserializeObject<DownloadSoundCloud>(result);
                if (Getlink.http_mp3_128_url != null)
                    link = Getlink.http_mp3_128_url;
                
                else
                    link = Getlink.hls_mp3_128_url;
            }
            return link;

        }


        /// <summary>
        /// /////
        /// </summary>
        /// <param name="link"></param>
        /// <param name="LsvTrackSoundCloud"></param>
        /// <param name="pivContent"></param>
        /// <param name="nextItem"></param>
        public async void GetTrackSounCloud(string link, ListView LsvTrackSoundCloud, ListView lsvTrackSoundCloudMobile, Pivot pivContent,TextBlock _txtError)
        {
            TrackSoundCloudViewModel trackViewModel = new TrackSoundCloudViewModel();
            LsvTrackSoundCloud.ItemsSource = null;
            lsvTrackSoundCloudMobile.ItemsSource = null;
            await trackViewModel.GetTrackAsyncTask(link);
            if(trackViewModel.TrackCollection.Count!=0)
            {
                LsvTrackSoundCloud.ItemsSource = trackViewModel.TrackCollection;
                lsvTrackSoundCloudMobile.ItemsSource = trackViewModel.TrackCollection;
                _txtError.Text = "";
            }
            else
            {
                _txtError.Text = "No more results, please to previous results...";
            }
            
            //track_offset = GetOffset();
            pivContent.SelectedIndex = 0;
        }

        /// <summary>
        /// ////
        /// </summary>
        /// <param name="link"></param>
        /// <param name="LsvTrackSoundCloud"></param>
        /// <param name="pivContent"></param>
        /// <param name="nextItem"></param>
        public async void GetSearchTrackSounCloud(string link, ListView LsvTrackSoundCloud,ListView lsvTrackSoundCloudMobile, Pivot pivContent,TextBlock _txtError)
        {
            TrackSoundCloudViewModel trackViewModel = new TrackSoundCloudViewModel();
            LsvTrackSoundCloud.ItemsSource = null;
            lsvTrackSoundCloudMobile.ItemsSource = null;
            await trackViewModel.GetSearchCollectionAsyncTask(link);
            if(trackViewModel.SearchTrackCollection.Count!=0)
            {
                LsvTrackSoundCloud.ItemsSource = trackViewModel.SearchTrackCollection;
                lsvTrackSoundCloudMobile.ItemsSource = trackViewModel.SearchTrackCollection;
                _txtError.Text = "";
            }
            else
            {
                _txtError.Text = "No more results, please to previous results...";
            }
           
            //nextItem = trackViewModel.Next_href[0].ToString();
            pivContent.SelectedIndex = 0;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="link"></param>
        /// <param name="LsvTrackSoundCloud"></param>
        /// <param name="pivContent"></param>
        /// 
        public class RootObject
        {
            public int id { get; set; }
            public string permalink { get; set; }
            public string username { get; set; }
            public string uri { get; set; }
            public string permalink_url { get; set; }
            public string avatar_url { get; set; }
            public string country { get; set; }
            public string full_name { get; set; }
            public string city { get; set; }
            public string description { get; set; }
            public object discogs_name { get; set; }
            public object myspace_name { get; set; }
            public string website { get; set; }
            public string website_title { get; set; }
            public bool online { get; set; }
            public int track_count { get; set; }
            public int playlist_count { get; set; }
            public int followers_count { get; set; }
            public int followings_count { get; set; }
            public int public_favorites_count { get; set; }
        }
        public async void GetUserTrackByID(string link,string linkuser, ListView LsvTrackSoundCloud,ListView lsvTrackSoundCloudMobile, Pivot pivContent, ImageBrush img, TextBlock username, TextBlock follower, TextBlock following, TextBlock tracks)
        {
            TrackSoundCloudViewModel trackViewModel = new TrackSoundCloudViewModel();
            LsvTrackSoundCloud.ItemsSource = null;
            lsvTrackSoundCloudMobile.ItemsSource = null;
            await trackViewModel.GetTrackCollectionUserAsyncTask(link);
            trackViewModel.GetUserInforAsyncTask("",linkuser,img,username,follower,following,tracks);
            LsvTrackSoundCloud.ItemsSource = trackViewModel.UserTrack;
            lsvTrackSoundCloudMobile.ItemsSource = trackViewModel.UserTrack;
            //string next_href = trackViewModel.Next_href[0].ToString();
            pivContent.SelectedIndex = 2;
        }

        /// <summary>
        /// //////
        /// </summary>
        /// <param name="link"></param>
        /// <param name="LsvPlaylistSoundCloud"></param>
        /// <param name="pivContent"></param>
        public async void GetPlaylistSoundCloud(string link, ListView LsvPlaylistSoundCloud,ListView lsvPlaylistSoundCloudMobile, Pivot pivContent)
        {
            TrackSoundCloudViewModel trackViewModel = new TrackSoundCloudViewModel();
            LsvPlaylistSoundCloud.ItemsSource = null;
            lsvPlaylistSoundCloudMobile.ItemsSource = null;
            await trackViewModel.GetPlaylistAsyncTask(link);
            LsvPlaylistSoundCloud.ItemsSource = trackViewModel.PlaylistCollection;
            lsvPlaylistSoundCloudMobile.ItemsSource = trackViewModel.PlaylistCollection;
            pivContent.SelectedIndex = 1;
        }
    }
}
