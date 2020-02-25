using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Input;

namespace MultiMirrorOsuBeatmapsDownloader.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private double WindowHeight;
        private double WindowWidth;
        public int ButtonHeight { get => 30; }
        public int ButtonWidth { get => 30; }
      //  public Thickness m;
        public string Title { get; set; }
        public ICommand CloseWindowCommand { get; private set; }
        private void CloseWindow(IResizable window)
        {
            if (window!=null)
            {
                window.Close();
            }
        }
        public ICommand MaximizeWindowCommand { get; private set; }
        private void MaximizeWindow(IResizable window) 
        {
            if (window!=null)
            {
                window.Maximize();
            }
            
        }
        public ICommand MinimizeWindowCommand { get; private set; }
        private void MinimizeWindow(IResizable window)
        {
            if (window!=null)
            {
                window.Minimize();
            }
        }
        public MainViewModel()
        {
            CloseWindowCommand = new RelayCommand<IResizable>(this.CloseWindow);
            MaximizeWindowCommand = new RelayCommand<IResizable>(MaximizeWindow);
            MinimizeWindowCommand = new RelayCommand<IResizable>(MinimizeWindow);
            

            // m.Left = App.Current.MainWindow.ActualWidth - 2 * ButtonHeight;
            if (IsInDesignMode)
            {
                Title = "Multi Mirror Osu Beatmap Downloader (Design Mode)";
            }
            else
            {
                Title = "Multi Mirror Osu Beatmap Downloader";
                // Code runs "for real"
            }
        }

        private void SaveWindowSize()
        {
            WindowHeight = App.Current.MainWindow.ActualHeight;
            WindowWidth = App.Current.MainWindow.ActualWidth;
        }
    }
}