using System.Threading.Tasks;

namespace PeopleManager.Abstracts
{
    public interface IDialogService
    {
        Task<bool> ShowConfirmationDialogAsync(string title, string message, string primaryButtonText, string primaryButtonStyle);
    }
}
