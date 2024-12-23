using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Windows.Graphics;

namespace PeopleManager.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            CenterWindow();
        }

        private void CenterWindow()
        {
            var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(this); 
            var windowId = Win32Interop.GetWindowIdFromWindow(windowHandle); 
            var appWindow = AppWindow.GetFromWindowId(windowId); 
            var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary); 
            var workArea = displayArea.WorkArea; 
            var centerPosition = new RectInt32 
            { 
                X = (workArea.Width - appWindow.Size.Width) / 2, 
                Y = (workArea.Height - appWindow.Size.Height) / 2, 
                Width = appWindow.Size.Width, 
                Height = appWindow.Size.Height 
            }; 
            appWindow.MoveAndResize(centerPosition);
        }

    }
}
