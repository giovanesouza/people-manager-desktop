using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Windows.Graphics;

namespace PeopleManager.Common
{
    public class WindowSizeManager
    {
        private readonly AppWindow appWindow;
        private readonly int minWidth;
        private readonly int minHeight;

        public WindowSizeManager(Window window, int minWidth, int minHeight, int initialWidth, int initialHeight)
        {
            this.minWidth = minWidth;
            this.minHeight = minHeight;

            var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
            var windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            appWindow = AppWindow.GetFromWindowId(windowId);

            SetInitialSize(initialWidth, initialHeight);
            CenterWindow();
            SetMinimumSize();
        }

        private void SetInitialSize(int width, int height)
        {
            var newSize = new SizeInt32 { Width = width, Height = height };
            appWindow.Resize(newSize);
        }

        private void CenterWindow()
        {
            var displayArea = DisplayArea.GetFromWindowId(appWindow.Id, DisplayAreaFallback.Primary);
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

        private void SetMinimumSize()
        {
            appWindow.Changed += (sender, args) =>
            {
                if (args.DidSizeChange)
                {
                    var newSize = appWindow.Size;
                    if (newSize.Width < minWidth || newSize.Height < minHeight)
                    {
                        appWindow.Resize(new SizeInt32
                        {
                            Width = newSize.Width < minWidth ? minWidth : newSize.Width,
                            Height = newSize.Height < minHeight ? minHeight : newSize.Height
                        });
                    }
                }
            };
        }
    }
}
