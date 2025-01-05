using Microsoft.UI.Xaml;
using PeopleManager.Common;
using PeopleManager.Events;
using Prism.Events;

namespace PeopleManager.Views
{
    public partial class MainWindow : Window
    {
        private readonly int MinWindowWidth = 780;
        private readonly int MinWindowHeight = 650;
        private readonly int InitialWidth = 1200;

        public MainWindow()
        {
            this.InitializeComponent();
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(TitleBar);
            _ = new WindowSizeManager(this, MinWindowWidth, MinWindowHeight, InitialWidth, MinWindowHeight);
        }


        private void MainWindow_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            var dimensions = new Dimensions
            {
                Width = (int)e.Size.Width,
                Height = (int)e.Size.Height,
                Size = GetWidthSize((int)e.Size.Width)
            };
            EventAggregator.Current.GetEvent<ResizeComponents>().Publish(dimensions);
        }

        private static Sizes GetWidthSize(int width)
        {
            if (width > 1000) return Sizes.Infinity;
            if (width > 800) return Sizes.ExtraLarge;
            if (width > 600) return Sizes.Large;
            if (width > 400) return Sizes.Medium;
            if (width > 200) return Sizes.Small;
            return Sizes.ExtraSmall;
        }
    }
}
