using System.Threading.Tasks;

namespace PeopleManager.Abstracts
{
    public interface IOpenUrlHelperService
    {
        Task OpenUrlAsync(string url);
    }
}
