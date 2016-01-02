using Bing;
using Bing.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace EntertaimentGroup.ViewModel
{
    public class MediaPlayer
    {
        
        public async Task<string> ChangedStatus(MediaElement m)
        {
            string TimeStatus;
            string sec, min, hour;
            if(m.Position.Seconds<10)
            {
                sec = "0" + m.Position.Seconds;
            }
            else
            {
                sec = m.Position.Seconds.ToString();
            }

            if(m.Position.Minutes<10)
            {
                min = "0" + m.Position.Minutes;
            }
            else
            {
                min = m.Position.Minutes.ToString();
            }

            if(m.Position.Hours<10)
            {
                hour = "0" + m.Position.Hours;
            }
            else
            {
                hour = m.Position.Hours.ToString();
            }

            //
            if(m.Position.Hours==0)
            {
                TimeStatus = min + ":" + sec + " /";
            }
            else
            {
                TimeStatus = hour + ":" + min + ":" + sec +" /";
            }
            await Task.Delay(1);
            return TimeStatus;
        }


        public async Task<string> TotalTimerStatus(MediaElement m)
        {
            TimeSpan ts = m.NaturalDuration.TimeSpan;
            string totaltimer;
            string sec, min, hour;
            if(ts.Seconds<10)
            {
                sec = "0" + ts.Seconds.ToString();
            }
            else
            {
                sec = ts.Seconds.ToString();
            }
            
            if(ts.Minutes<10)
            {
                min = "0" + ts.Minutes.ToString();
            }
            else
            {
                min = ts.Minutes.ToString();
            }

            if(ts.Hours<10)
            {
                hour = "0" + ts.Hours.ToString();
            }
            else
            {
                hour = ts.Hours.ToString();
            }

            //
            if(ts.Hours==0)
            {
                totaltimer = min + ":" + sec;
            }
            else
            {
                totaltimer = hour + ":" + min + ":" + sec;
            }
            await Task.Delay(1);
            return totaltimer;
        }

        public async void MediaEnded(ListView lst,ListView lst1, MediaElement m, SymbolIcon s)
        {
            SolidColorBrush Currentcolor1 = (SolidColorBrush)s.Foreground;
            SolidColorBrush color = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));

            if (Currentcolor1.Color.Equals(color.Color))
            {
                RepeatSongs(m);
            }
            
            else if(lst.SelectedIndex==lst.Items.Count-1 || lst1.SelectedIndex==lst1.Items.Count-1)
            {
                if(lst.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    lst.SelectedIndex = 0;
                }
                else if (lst1.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    //lsv1.SelectedIndex = lsv.SelectedIndex;
                    lst1.SelectedIndex = 0;
                }
                else
                    return;
            }
            else
            {
                if (lst.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    lst.SelectedIndex++;
                }
                else if (lst1.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    //lsv1.SelectedIndex = lsv.SelectedIndex;
                    lst1.SelectedIndex++;
                }
                else
                    return;
            }
            await Task.Delay(1);
            
        }

        public async void MediaFailed(ListView lst,ListView lst1, SymbolIcon s)
        {
            if(lst.SelectedIndex==lst.Items.Count-1 || lst1.SelectedIndex==lst1.Items.Count-1)
            {

                if (lst.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    lst.SelectedIndex=0;
                }
                else if (lst1.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    //lsv1.SelectedIndex = lsv.SelectedIndex;
                    lst1.SelectedIndex=0;
                }
                else
                    return;
            }
            else
            {
                var dialog = new MessageDialog("Unable to play '.m3u'. Automatically to next song");
                await dialog.ShowAsync();
                
                if (lst.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    lst.SelectedIndex++;
                }
                else if (lst1.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    //lsv1.SelectedIndex = lsv.SelectedIndex;
                    lst1.SelectedIndex++;
                }
                else
                    return;
                    
            }
            s.Symbol = Symbol.Play;
        }

        public void SelectedSong(MediaElement m, string link, int currentIndex, ListView lst)
        {
            m.Source = new Uri(link);
            m.Play();
        }

        public void _Play(SymbolIcon s,SymbolIcon s1,MediaElement m)
        {
            s.Symbol = Symbol.Pause;
            s1.Symbol = Symbol.Pause;
            m.Play();

        }

        public void _Pause(SymbolIcon s, SymbolIcon s1, MediaElement m)
        {
            s.Symbol = Symbol.Play;
            s1.Symbol = Symbol.Play;
            m.Pause();
        }

        public void NextSongs(MediaElement m, ListView lsv,ListView lsv1, SymbolIcon s, SymbolIcon s2)
        {
            SolidColorBrush Currentcolor1 = (SolidColorBrush)s.Foreground;
            SolidColorBrush Currentcolor2 = (SolidColorBrush)s2.Foreground;
            SolidColorBrush color = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));


            if (lsv.SelectedIndex < lsv.Items.Count - 1 || lsv1.SelectedIndex<lsv1.Items.Count-1)
            {
                
                
                
                if(!Currentcolor1.Color.Equals(color.Color) && !Currentcolor2.Color.Equals(color.Color))
                {
                    if (lsv.Visibility == Windows.UI.Xaml.Visibility.Visible)
                    {
                        lsv.SelectedIndex++;
                    }
                    else
                      if (lsv1.Visibility == Windows.UI.Xaml.Visibility.Visible)
                    {
                        //lsv1.SelectedIndex = lsv.SelectedIndex;
                        lsv1.SelectedIndex++;
                    }
                    else
                        return;

                }
                else
                {
                    if (Currentcolor1.Color.Equals(color.Color)&& s.Name == "shuffleIcon")
                    {
                        Shuffler(lsv);
                    }

                    else if (Currentcolor2.Color.Equals(color.Color) && s2.Name == "repeatIcon")
                    {
                        RepeatSongs(m);
                    }
                }
                    
            }
            else
                return;
            
        }

        public void PreviousSongs(MediaElement m, ListView lsv,ListView lsv1, SymbolIcon s, SymbolIcon s2)
        {
            SolidColorBrush Currentcolor1 = (SolidColorBrush)s.Foreground;
            SolidColorBrush Currentcolor2 = (SolidColorBrush)s2.Foreground;
            SolidColorBrush color = new SolidColorBrush(Color.FromArgb(255,51,51,51));



            if ((lsv.SelectedIndex < 0 || lsv.SelectedIndex <= lsv.Items.Count - 1) || (lsv1.SelectedIndex<0||lsv1.SelectedIndex<=lsv1.Items.Count-1) )
            {
                if (!Currentcolor1.Color.Equals(color.Color) && !Currentcolor2.Color.Equals(color.Color))
                {
                    if (lsv.Visibility == Windows.UI.Xaml.Visibility.Visible)
                    {
                        lsv.SelectedIndex--;
                    }
                    else                      
                    if (lsv1.Visibility == Windows.UI.Xaml.Visibility.Visible)
                    {
                        //lsv1.SelectedIndex = lsv.SelectedIndex;
                        lsv1.SelectedIndex--;
                    }
                    else
                        return;
                }
                else
                {
                    if (Currentcolor1.Color.Equals(color.Color) && s.Name == "shuffleIcon")
                    {
                        Shuffler(lsv);
                    }

                    else if (Currentcolor2.Color.Equals(color.Color) && s2.Name == "repeatIcon")
                    {
                        RepeatSongs(m);
                    }
                }
            }
            else
                return;
        }

        public void RepeatSongs(MediaElement m)
        {
            //m.IsLooping = true;
            m.Position = TimeSpan.Zero;
            m.Play();
        }

        public void Shuffler(ListView lsv)
        {
            Random rd = new Random();
            lsv.SelectedIndex = rd.Next(lsv.SelectedIndex, lsv.Items.Count);
        }
       

        //bool isShufflerorRepeat = false;
        public void ForegroundSymbolIcon(SymbolIcon s)
        {
            SolidColorBrush Currentcolor1 = (SolidColorBrush)s.Foreground;
            SolidColorBrush color = new SolidColorBrush(Color.FromArgb(255, 185, 185, 185));
            if (Currentcolor1.Color == color.Color && s.Name== "shuffleIcon")
            {
                s.Foreground = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));
            }
            else if (Currentcolor1.Color == color.Color && s.Name == "repeatIcon")
            {
                s.Foreground = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));
            }
            else
            {
                s.Foreground = new SolidColorBrush(Color.FromArgb(255, 185, 185, 185));
            }


           

        }


        public void ThumbailForTitle(TextBlock txt1, TextBlock txt2, Image img, string title, string user, string image)
        {
            try
            {
                txt1.Text = title;
                txt2.Text = user;
                img.Source = new BitmapImage(new Uri(image, UriKind.RelativeOrAbsolute));
            }
            catch(Exception)
            {
                return;
            }
            
        }
        /*
        public async void GetBackgroundMedia()
        {
            var list = PoiEntityGroups.Entertainment();
            //list.Add(PoiEntityTypes.EntertainmentElectronics);

            //var filter = PoiEntityGroups.BuildFilter(list);

            var client = new SpatialDataClient("YgRrCyLFi/xIVZI+brbQXpDdiTRWGmMpbaSJtHzHv4M");

           // var results = await client.Find<PointOfInterest>("taylorswift", searchRadius:5000,filter:"" ,orderBy:"",skip:0, top: 10);

            
        }
        */
    }
}
