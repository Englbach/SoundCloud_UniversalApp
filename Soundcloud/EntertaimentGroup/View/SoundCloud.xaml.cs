using System;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using EntertaimentGroup.Model;
using EntertaimentGroup.ViewModel;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Display;
using Lumia.Imaging.Adjustments;
using Lumia.Imaging.Artistic;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EntertaimentGroup.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SoundCloud : Page
    {

        string Api_key = "";// input your api_key here







        TrackSoundCloudViewModel trackViewModel = new TrackSoundCloudViewModel();
        ObservableCollection<DownloadCommand> downloadList = new ObservableCollection<DownloadCommand>();
        //ObservableCollection<MenuMainPage> list;
        MediaPlayer player = new ViewModel.MediaPlayer();

        string href;
        int offset=0;// get offset to next items or privous items


        DispatcherTimer timer = new DispatcherTimer();
        public delegate void timerTick();
        timerTick tick;


        
        public SoundCloud()
        {
            this.InitializeComponent();
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Colors.White;
            titleBar.ButtonForegroundColor = Colors.Black;

            
           

            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
            //tick = new timerTick(player.ChangedStatus);
            timer.Start();
            this.Loaded += SoundCloud_Loaded;

        }

        private async void Timer_Tick(object sender, object e)
        {
            //throw new NotImplementedException();
            if(MediaPlayer.Source!=null)
            {
                processMedia.Minimum = 0;
                processMedia.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                processMedia.Value = MediaPlayer.Position.TotalSeconds;
                string changedStatus= await player.ChangedStatus(MediaPlayer);
                txtMediaTimeStatus.Text = changedStatus;
            }
        }

        private void SoundCloud_Loaded(object sender, RoutedEventArgs e)
        {
            if (Api_key != "")
            {
                lstHambugerItems.IsEnabled = true;
                lstHambugerItems.SelectedIndex = 0;
                //throw new NotImplementedException();
                lstHambugerItems.SelectedIndex = 0;

                // get category for combobox
                CategoriesSoundCloudViewModel category = new CategoriesSoundCloudViewModel();
                cbbCategory.ItemsSource = category.GetCategorieslist();
            }
            else
            {
                txtError.Text = "Please to input your API_KEY to use application";
                lstHambugerItems.IsEnabled = false;
            }
                
          

        }
       


        private void lstHambugerItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Splsidebar.OpenPaneLength = 0;
            if (lstHambugerItems.SelectedIndex == 0)
            {
                trackViewModel.GetTrackSounCloud("https://api-v2.soundcloud.com/explore/Popular+Music?tag=out-of-experiment&limit=30&linked_partitioning=1", LsvTrackSoundCloud, LsvTrackSoundCloudMobile, pivContent, txtError);

                href = "https://api-v2.soundcloud.com/explore/Popular+Music?tag=out-of-experiment&limit=30&linked_partitioning=1";

                txtTitle.Text = "Home";
            }
            else if (lstHambugerItems.SelectedIndex == 1)
            {
                Splsidebar.OpenPaneLength = 280;
            }
            else if (lstHambugerItems.SelectedIndex == 2)
            {
                pivContent.SelectedIndex = 3;
                txtTitle.Text = "Download";
            }
            else if(lstHambugerItems.SelectedIndex==3)
                Frame.GoBack();
           
        }

        private void cbbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbbCategory.SelectedIndex!=-1)
            {
                var getItem = cbbCategory.SelectedItem as CategoriesSoundCloud;
                trackViewModel.GetTrackSounCloud(getItem.link, LsvTrackSoundCloud, LsvTrackSoundCloudMobile, pivContent,txtError);
                href = getItem.link;
                offset = 0;
                txtTitle.Text = getItem.name;

            }
        }

        private void PivotItem_LayoutUpdated(object sender, object e)
        {
            LsvTrackSoundCloud.Width = pivContent.ActualWidth;
            LsvTrackSoundCloudMobile.Width = pivContent.ActualWidth;
            LsvPlaylistSoundCloud.Width = pivContent.ActualWidth;
            LsvPlaylistSoundCloudMobile.Width = pivContent.ActualWidth;

            lsvTrackByUser.Width = pivContent.ActualWidth;
            lsvTrackByUserMobile.Width = pivContent.ActualWidth;

            lstDownload.Width = pivContent.ActualWidth;
            processMedia.Width = pivContent.ActualWidth;
        }


        string _url;
        string _title;
        string _thumb;
        /// <summary>
        /// ////////
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <param name="thumb"></param>
        private async void GetItemForDownload(int id,string url, string title, string thumb)
        {
            if(id!=0)
            {
                _url = await trackViewModel.Getlinkdownload(id,Api_key);
            }
            else
            {
                _url = url;
            }
            _title = title;
            if(_thumb!=null)
            {
                _thumb = thumb;
            }
            else
            {
                _thumb = "/Asset/nologo.jpg";
            }
            
        }

        
        int playlistOrTrack;
        //object oldSource;
        private async void LsvTrackSoundCloud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            playlistOrTrack = 1;
            if (LsvTrackSoundCloud.SelectedIndex!=-1 || LsvTrackSoundCloudMobile.SelectedIndex!=-1)
            {
                var Streamitem = ((ListView)sender).SelectedItem as Model.TracksSoundCloud.Track;
                var Collectionitem = ((ListView)sender).SelectedItem as Model.SearchSoundCloud.Collection;
                var UserTrackItem = ((ListView)sender).SelectedItem as Model.UserSoundCloud.Collection;
                
                if(Streamitem!=null)
                {
                    if (Streamitem.kind == "track")
                    {

                        //Download
                        GetItemForDownload(Streamitem.id,"", Streamitem.title, Streamitem.artwork_url);
                       
                        //
                        if(Streamitem.stream_url!=null)
                        {
                            MediaPlayer.Source = new Uri(Streamitem.stream_url + "?client_id="+Api_key, UriKind.RelativeOrAbsolute);
                            
                        }
                        else
                        {
                            string stream_url = await trackViewModel.Getlinkdownload(Collectionitem.id,Api_key);
                            player.SelectedSong(MediaPlayer, stream_url, LsvTrackSoundCloud.SelectedIndex, LsvTrackSoundCloud);
                            //Download
                            GetItemForDownload(0,stream_url, Streamitem.title, Streamitem.artwork_url);
                        }
                        player.ThumbailForTitle(txtNameSongs, txtUserUpload, imgThumbailSongs, Streamitem.title, Streamitem.user.full_name, Streamitem.artwork_url);
                        //

                        
                       
                    }
                    //playlist
                    else
                    {
                        ///pivContent.SelectedIndex = 1;
                        trackViewModel.GetPlaylistSoundCloud("https://api.soundcloud.com/playlists/" + Streamitem.id + "?client_id="+Api_key,LsvPlaylistSoundCloud,LsvPlaylistSoundCloudMobile, pivContent);
                    }
                }
                //track of user
                else if(UserTrackItem!=null)
                {
                   
                    //Download
                    GetItemForDownload(UserTrackItem.id,"", UserTrackItem.title, UserTrackItem.artwork_url);

                   
                    //
                    if (UserTrackItem.uri != null)
                    {
                        MediaPlayer.Source = new Uri(UserTrackItem.uri + "/stream?client_id="+Api_key, UriKind.RelativeOrAbsolute);

                    }
                    player.ThumbailForTitle(txtNameSongs, txtUserUpload, imgThumbailSongs, Streamitem.title, Streamitem.user.full_name, Streamitem.artwork_url);

                }
                //Collectionitem will show up when we are finding any things.
                else
                {
                    if(Collectionitem.kind=="track")
                    {
                        //Download
                        GetItemForDownload(Collectionitem.id,"", Collectionitem.title, Collectionitem.artwork_url);


                      
                        //
                        if (Collectionitem.stream_url!=null)
                        {
                            MediaPlayer.Source = new Uri(Collectionitem.stream_url + "?client_id="+Api_key, UriKind.RelativeOrAbsolute);
                            
                        }
                        
                        else
                        {
                            string stream_url = await trackViewModel.Getlinkdownload(Collectionitem.id,Api_key);
                            //Download
                            GetItemForDownload(0,stream_url, Collectionitem.title, Collectionitem.artwork_url);

                            player.SelectedSong(MediaPlayer, stream_url, LsvTrackSoundCloud.SelectedIndex, LsvTrackSoundCloud);
                        }
                        player.ThumbailForTitle(txtNameSongs, txtUserUpload, imgThumbailSongs, Collectionitem.title, Collectionitem.user.full_name, Collectionitem.artwork_url);

                    }
                    // when we are finding any tracks or playlist or user...
                    // example: search a "Travis Scott". app will show up any tracks of this user and on first of a item is user. When you click on user then app will return to this user page(pivotContent.selectedIndex=2)
                    else if (Collectionitem.kind == "user")
                    {
                        //pivContent.SelectedIndex = 0;
                        playlistOrTrack = 3;
                        trackViewModel.GetUserTrackByID("https://api-v2.soundcloud.com/users/" + Collectionitem.id + "/tracks?client_id="+Api_key+"&limit=30&offset=0&linked_partitioning=1", "https://api.soundcloud.com/users/" + Collectionitem.id+ "?client_id=9ac2b17027e4af068adbb4f10330e1b3", lsvTrackByUser ,lsvTrackByUserMobile,pivContent,ThumbForUser,txtUsername,txtFollowerCount,txtFollwingCount,txtTrackCount);
                    }

                    // It such "user"
                    // return to playlist page(pivotContent.selectedIndex=1)
                    else
                    {
                        //pivContent.SelectedIndex = 1;
                        playlistOrTrack = 2;
                        trackViewModel.GetPlaylistSoundCloud("https://api.soundcloud.com/playlists/" + Collectionitem.id + "?client_id="+Api_key,LsvPlaylistSoundCloud,LsvPlaylistSoundCloudMobile,pivContent);
                    }
                }
               
               
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LsvPlaylistSoundCloud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            playlistOrTrack = 2;
            // pivContent.SelectedIndex = 2;
            var playlistItem = ((ListView)sender).SelectedItem as Model.PlaylistSoundCloud.Track;
            if(playlistItem!=null)
            {
                
                //
                if (playlistItem.stream_url != null)
                {
                    MediaPlayer.Source = new Uri(playlistItem.stream_url + "?client_id="+Api_key, UriKind.RelativeOrAbsolute);
                    
                }
                else
                {
                    string stream_url = await trackViewModel.Getlinkdownload(playlistItem.id,Api_key);
                    player.SelectedSong(MediaPlayer, stream_url, LsvPlaylistSoundCloud.SelectedIndex, LsvPlaylistSoundCloud);
                }
                player.ThumbailForTitle(txtNameSongs, txtUserUpload, imgThumbailSongs, playlistItem.title, playlistItem.user.username, playlistItem.artwork_url);
            }
        }
        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void lsvTrackByUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            playlistOrTrack = 3;
            var trackItem = ((ListView)sender).SelectedItem as Model.UserSoundCloud.Collection;
            if(trackItem!=null)
            {
               
                if(trackItem.stream_url!=null)
                {
                    MediaPlayer.Source=new Uri(trackItem.stream_url + "?client_id="+Api_key, UriKind.RelativeOrAbsolute);
                }
                else
                {
                    string stream_url = await trackViewModel.Getlinkdownload(trackItem.id,Api_key);
                    player.SelectedSong(MediaPlayer, stream_url, LsvPlaylistSoundCloud.SelectedIndex, LsvPlaylistSoundCloud);
                }
                player.ThumbailForTitle(txtNameSongs, txtUserUpload, imgThumbailSongs, trackItem.title, trackItem.user.username, trackItem.artwork_url);
            }
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHambuger_Click(object sender, RoutedEventArgs e)
        {
            splvHambuger.IsPaneOpen = !splvHambuger.IsPaneOpen;
        }

        private void btnprivous_Click(object sender, RoutedEventArgs e)
        {
            lstHambugerItems.SelectedIndex = 0;

        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Splsidebar.OpenPaneLength = 280;
        }
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrending_Click(object sender, RoutedEventArgs e)
        {
            lstHambugerItems.SelectedIndex = 0;
            Splsidebar.OpenPaneLength = 0;
        }
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            lstHambugerItems.SelectedIndex = 1;
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownloadManager_Click(object sender, RoutedEventArgs e)
        {
            lstHambugerItems.SelectedIndex = 2;
            Splsidebar.OpenPaneLength = 0;
        }
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseSliber_Click(object sender, RoutedEventArgs e)
        {
            Splsidebar.OpenPaneLength = 0;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SbSearch_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            trackViewModel.GetSearchTrackSounCloud("https://api-v2.soundcloud.com/search?q=" + SbSearch.Text + "&facet=model&limit=30&offset=0&client_id="+Api_key,LsvTrackSoundCloud, LsvTrackSoundCloudMobile, pivContent,txtError);
            href = "https://api-v2.soundcloud.com/search?q=" + SbSearch.Text + "&facet=model&limit=50&offset=0&client_id="+Api_key;
            offset = 0;
        }
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pivContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
            if(pivContent.SelectedIndex==0)
            {
                btnprivous.Visibility = Visibility.Collapsed;
                txtTitle.Text = "Home";
            }
            else if(pivContent.SelectedIndex!=0)
            {
                btnprivous.Visibility = Visibility.Visible;
                lstHambugerItems.SelectedIndex = -1;
                
            }
                
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaPlayerPanel.Visibility = Visibility.Visible;
            //pivContent.SelectedIndex = 3;           
            string totalTime = await player.TotalTimerStatus(MediaPlayer);
            txtMediaTimeTotalStatus.Text = totalTime;
            playIcon.Symbol = Symbol.Pause;
            playIconMobile.Symbol = Symbol.Pause;
           
            
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaPlayer_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            
            if (playlistOrTrack==1)
            {
                player.MediaFailed(LsvTrackSoundCloud,LsvTrackSoundCloudMobile,playIcon);
            }
            else if(playlistOrTrack==2)
            {
                player.MediaFailed(LsvPlaylistSoundCloud,LsvPlaylistSoundCloudMobile,playIcon);
            }
            else
            {
                player.MediaFailed(lsvTrackByUser,lsvTrackByUserMobile, playIcon);
            }
            MediaPlayerPanel.Visibility = Visibility.Collapsed;
           
           
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            
            if (playlistOrTrack == 1)
            {
                player.MediaEnded(LsvTrackSoundCloud, LsvTrackSoundCloudMobile, MediaPlayer, repeatIcon);
            }
            else if(playlistOrTrack==2)
            {
                player.MediaEnded(LsvPlaylistSoundCloud,LsvPlaylistSoundCloudMobile, MediaPlayer, repeatIcon);
            }
            else
            {
                player.MediaEnded(lsvTrackByUser,lsvTrackByUserMobile, MediaPlayer, repeatIcon);
            }
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if(playIcon.Symbol==Symbol.Pause)
            {
                player._Pause(playIcon,playIconMobile, MediaPlayer);
            }
            else
            {
                player._Play(playIcon,playIconMobile, MediaPlayer);
            }
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNextSongs_Click(object sender, RoutedEventArgs e)
        {
            if(playlistOrTrack == 1)
            {
                player.NextSongs(MediaPlayer, LsvTrackSoundCloud,LsvTrackSoundCloudMobile, shuffleIcon, repeatIcon);
            }
            else if(playlistOrTrack==2)
            {
                player.NextSongs(MediaPlayer, LsvPlaylistSoundCloud,LsvPlaylistSoundCloudMobile, shuffleIcon, repeatIcon);
            }
            else
            {
                player.NextSongs(MediaPlayer, lsvTrackByUser,lsvTrackByUserMobile, shuffleIcon, repeatIcon);
            }
            
        }
        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPreviousSongs_Click(object sender, RoutedEventArgs e)
        {

            if (playlistOrTrack == 1)
            {
                player.PreviousSongs(MediaPlayer, LsvTrackSoundCloud, LsvTrackSoundCloudMobile, shuffleIcon, repeatIcon);
            }
            else if(playlistOrTrack==2)
            {
                player.PreviousSongs(MediaPlayer, LsvPlaylistSoundCloud,LsvPlaylistSoundCloudMobile, shuffleIcon, repeatIcon);
            }
            else
            {
                player.PreviousSongs(MediaPlayer, lsvTrackByUser,lsvTrackByUserMobile, shuffleIcon, repeatIcon);
            }

        }



        //int shuffCount = 1;
        //int repeatCount = 1;
        private void BtnShuffler_Click(object sender, RoutedEventArgs e)
        {
            //shuffCount++;
            player.ForegroundSymbolIcon(shuffleIcon);
        }

        private void BtnRepeat_Click(object sender, RoutedEventArgs e)
        {
            //repeatCount++;
            player.ForegroundSymbolIcon(repeatIcon);
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            lstHambugerItems.SelectedIndex = 2;
            downloadList.Add(new DownloadCommand(_url, _thumb, _title, ".mp3") );
            lstDownload.ItemsSource = downloadList;
            
        }

        private void NextItem_Click(object sender, RoutedEventArgs e)
        {
            if (txtError.Text == "")
            {
                offset += 30;
                trackViewModel.GetTrackSounCloud(href + "&offset=" + offset, LsvTrackSoundCloud, LsvTrackSoundCloudMobile, pivContent, txtError);
            }
            else
                return;
            
        }

        private void BackItem_Click(object sender, RoutedEventArgs e)
        {
            if (offset > 0)
            {
                offset -= 30;
                trackViewModel.GetTrackSounCloud(href + "&offset=" + offset, LsvTrackSoundCloud, LsvTrackSoundCloudMobile, pivContent,txtError);
            }
            else
                return;
           
        }

        private void Downloader_Click(object sender, RoutedEventArgs e)
        {
            lstHambugerItems.SelectedIndex = 2;
        }

        private void SearchBox_Click(object sender, RoutedEventArgs e)
        {
            Splsidebar.OpenPaneLength = 280;
        }
    }
}
