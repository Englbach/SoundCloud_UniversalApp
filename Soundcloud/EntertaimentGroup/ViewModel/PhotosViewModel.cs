using EntertaimentGroup.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertaimentGroup.ViewModel
{
    public class PhotosViewModel
    {
        public ObservableCollection<Photos> photosCollection { get; set; }

        public async Task GetBackgroundForSoundCloudAsyncTask(string link)
        {
            string result = await StaticMethod.GetJsonStringTask(link);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(result);

            photosCollection = new ObservableCollection<Photos>();
           // var nodeCollection=doc.DocumentNode.Descendants
        }
    }
}
