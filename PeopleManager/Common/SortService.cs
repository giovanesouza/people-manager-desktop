using PeopleManager.Abstracts;
using PeopleManager.Events;
using Prism.Events;

namespace PeopleManager.Common
{
    public class SortService : ISortService
    {
        private static string _sortPeopleBy;
        public string SortPeopleBy
        {
            get => _sortPeopleBy;
            set
            {
                _sortPeopleBy = value;
                PublishSortEvent(_sortPeopleBy);
            }
        }

        public void PublishSortEvent(string sortBy)
        {
            EventAggregator.Current.GetEvent<PeopleSortedEvent>().Publish(sortBy);
        }
    }
}
