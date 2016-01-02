using Lumia.Imaging;
using Lumia.Imaging.Adjustments;
using Lumia.Imaging.Artistic;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace EntertaimentGroup.ViewModel
{
    public class EffectImaging
    {
        public GrayscaleEffect _grayscaleEffect;
        public LensBlurEffect _lensburEffect;
        public LomoEffect _lomoEffect;
        public MoonlightEffect _moonlighEffect;
        private WriteableBitmap _writeableBitmap;
        private WriteableBitmap _thumbnailImageBitmap;
        public async Task<bool> ApplyEffectAsync(StorageFile file, SwapChainPanelRenderer m_renderer)
        {
            IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read);
            string errorMessage = null;

            try
            {
                fileStream.Seek(0);

                ((IImageConsumer)_grayscaleEffect).Source = new Lumia.Imaging.RandomAccessStreamImageSource(fileStream);
                await m_renderer.RenderAsync();
            }
            catch( Exception exception)
            {
                errorMessage = exception.Message;
            }

            if(!string.IsNullOrEmpty(errorMessage))
            {
                var dialog = new MessageDialog(errorMessage);
                await dialog.ShowAsync();
                return false;
            }
            return true;
        }
    }
}
