namespace PeopleManager.Abstracts
{
    public interface ISortService
    {
        string SortPeopleBy { get; set; }
        void PublishSortEvent(string sortBy);
    }
}
