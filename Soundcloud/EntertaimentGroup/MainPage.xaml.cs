using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using EntertaimentGroup.View;
using EntertaimentGroup.ViewModel;
using System.Collections.ObjectModel;
using EntertaimentGroup.Model;
using Windows.System.Profile;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EntertaimentGroup
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MenuMainPageViewModel menu = new MenuMainPageViewModel();
            ObservableCollection<MenuMainPage> list = menu.GetMenu();
            lstMenuMain.ItemsSource = list;
        }

        private void lstMenuMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame fr = Window.Current.Content as Frame;
            fr.Navigate(typeof(SoundCloud));
        }
        double width_main;
        double height_main;
        private void lstMenuMain_LayoutUpdated(object sender, object e)
        {

            width_main = lstMenuMain.ActualWidth;
            height_main = lstMenuMain.ActualWidth;
           
        }

        public static DependencyObject MyFindListViewChildByName(DependencyObject parant, string ControlName)
        {
            int count = VisualTreeHelper.GetChildrenCount(parant);

            for (int i = 0; i < count; i++)
            {
                var MyChild = VisualTreeHelper.GetChild(parant, i);
                if (MyChild is FrameworkElement && ((FrameworkElement)MyChild).Name == ControlName)
                    return MyChild;

                var FindResult = MyFindListViewChildByName(MyChild, ControlName);
                if (FindResult != null)
                    return FindResult;
            }

            return null;
        }

        private void x_LayoutUpdated(object sender, object e)
        {
            /*
            Ellipse mystack = MyFindListViewChildByName(lstMenuMain, "x") as Ellipse;
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                mystack.Width = (width_main - 10) / 2;
                mystack.Height = mystack.ActualWidth;
            }
            else
            {
                //mystack.Width = 200;
                mystack.Height = 200;
            }
            */
        }
    }
}
