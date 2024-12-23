using PeopleManager.Models;
using Prism.Events;

namespace PeopleManager.Events
{
    public class PersonAddedEvent : PubSubEvent<Person> { }
}
