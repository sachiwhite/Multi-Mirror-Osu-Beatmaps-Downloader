using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiMirrorOsuBeatmapsDownloader
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IResizable
    {
        private readonly int ButtonCountInBorder = 3;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Maximize()
        {
            if (App.Current.MainWindow.WindowState == WindowState.Maximized)
                App.Current.MainWindow.WindowState = WindowState.Normal;
            else
                App.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        public void Minimize() =>
            App.Current.MainWindow.WindowState = WindowState.Minimized;
       
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            if (e.WidthChanged)
            {
                firstButton.Margin = new Thickness(App.Current.MainWindow.ActualWidth - ButtonCountInBorder * firstButton.Width, 0, 0, 0);
            }
          
        }
    }
}
