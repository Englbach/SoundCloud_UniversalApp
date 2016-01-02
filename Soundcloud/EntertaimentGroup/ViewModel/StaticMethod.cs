using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace EntertaimentGroup.ViewModel
{
    public class StaticMethod
    {
        public object StorgeFolder { get; private set; }

        public static async Task<string> GetJsonStringTask(string link)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(link);
            string result = await message.Content.ReadAsStringAsync();
            return result;
        }

        
/*
       public async void blurImage(Image m)
        {
            using (var stream = await RenderToRandomAccessStream())
            {
                var device = new CanvasDevice();
                var bitmap = await CanvasBitmap.LoadAsync(device, stream);

                var rederer = new CanvasRenderTarget(device, bitmap.SizeInPixels.Width, bitmap.SizeInPixels.Height, bitmap.Dpi);

                using (var ds = rederer.CreateDrawingSession())
                {
                    var blur = new GaussianBlurEffect();
                    blur.BlurAmount = 0.5f;
                    blur.Source = bitmap;
                    ds.DrawImage(blur);

                }

                stream.Seek(0);
                await rederer.SaveAsync(stream, CanvasBitmapFileFormat.Png);

                BitmapImage image = new BitmapImage();
                image.SetSource(stream);

                m.Source = image;
            }
        }
        */
       
    }
}
