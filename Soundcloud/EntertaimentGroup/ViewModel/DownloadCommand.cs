using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EntertaimentGroup.ViewModel
{
    public class DownloadCommand:INotifyPropertyChanged
    {

        public string title;
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if(value!=this.title)
                {
                    this.title = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                    }
                }
            }
        }
        public string thumb;
        public string Thumb
        {
            get
            {
                return this.thumb;
            }
            set
            {
                if (value != this.thumb)
                {
                    this.thumb = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Thumb"));
                    }
                }
            }
        }

        public string status;
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                if(value!=this.status)
                {
                    this.status = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                    }
                }
            }
        }

        public string total;
        public string Total
        {
            get
            {
                return this.total;
            }

            set
            {
                if (value != this.total)
                {
                    this.total = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Total"));
                    }
                }
            }
        }
        public string downloaded;
        public string Downloaded
        {
            get
            {
                return this.downloaded;
            }
            set
            {
                if (value != this.downloaded)
                {
                    this.downloaded = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Downloaded"));
                    }
                }
            }
        }
        public double percentage;
        public double Percentage
        {
            get
            {
                return this.percentage;
            }

            set
            {
                if (value != this.percentage)
                {
                    this.percentage = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Percentage"));
                    }
                }
            }
        }

        public Visibility visibility;
        public Visibility Visibility
        {
            get
            {
                return this.visibility;
            }
            set
            {
                if(value!=this.visibility)
                {
                    this.visibility = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Visibility"));
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DownloadCommand(string requestUrl,string thumb, string filename, string fileType)
        {
            //this.Total = 1240;
            //this.percentage = 0;
            //this.downloaded = 0;
            this.Visibility = Visibility.Collapsed;
            this.Title = filename;
            this.Thumb = thumb;
            Downloader(requestUrl,thumb, filename, fileType);
            
        }

        public void ProgressCallBack(DownloadOperation obj)
        {
            this.Visibility = Visibility.Visible;
            this.Percentage = ((double)obj.Progress.BytesReceived / obj.Progress.TotalBytesToReceive)*100;
            this.Downloaded = string.Format("{0:0,000}",(double)(obj.Progress.BytesReceived / 1240));
            this.Total =string.Format("{0:0,000}",(double)(obj.Progress.TotalBytesToReceive / 1240));
            
            this.Status = "Downloading";
            if (Percentage >= 100)
            {
                //listbox will removed this item and keep to download at next item.
                this.Status = "Completed";
                this.Percentage = 0.0;
                this.Downloaded = "0";
                this.Total = "0";
            }
        }

        private async Task StartDownloadAsync(DownloadOperation obj)
        {
            var process = new Progress<DownloadOperation>(ProgressCallBack);
            await obj.StartAsync().AsTask(process);
        }

       public async void Downloader(string requestUrl,string thumb, string filename, string fileType)
        {
           try
            {
                var downloader = new BackgroundDownloader();
                var regex = new Regex(@"[\\|/\:\*\?""<>\\|]");
                var result_filename = regex.Replace(filename, " ").Replace(";", "");

                FolderPicker fo = new FolderPicker();
                fo.SuggestedStartLocation = PickerLocationId.Downloads;
                fo.FileTypeFilter.Add(fileType);
                StorageFolder folder = await fo.PickSingleFolderAsync();
                var filePart = await folder.CreateFileAsync(result_filename + fileType, CreationCollisionOption.ReplaceExisting);
                DownloadOperation download = downloader.CreateDownload(new Uri(requestUrl), filePart);
                await StartDownloadAsync(download);
            } 
            catch(Exception)
            {
                return;
            }
            
        }
        
        
    }
}
