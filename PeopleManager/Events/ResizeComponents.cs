using Prism.Events;

namespace PeopleManager.Events
{
    public enum Sizes { Infinity, ExtraLarge, Large, Medium, Small, ExtraSmall }
    public enum HeightSizes { Large, Medium, Small }
    public class Dimensions 
    { 
        public Sizes Size { get; set; } 
        public HeightSizes HeightSize { get; set; } 
        public int Width { get; set; } 
        public int Height { get; set; } 
    }

    public class ResizeComponents : PubSubEvent<Dimensions> { }
}
