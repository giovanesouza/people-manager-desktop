using PeopleManager.Abstracts;
using PeopleManager.Common;

namespace PeopleManager.ViewModels
{
    public partial class FooterViewModel : ViewModelBase
    {
        private readonly ILocalizationService _localizationService;
        private readonly IOpenUrlHelperService _openUrlHelper;

        public ICommand GitHubLinkCommand { get; }
        public ICommand LinkedInLinkCommand { get; }

        public FooterViewModel(ILocalizationService localizationService, IOpenUrlHelperService openUrlHelper)
        {
            _localizationService = localizationService;
            _openUrlHelper = openUrlHelper;

            GitHubLinkCommand = new RelayCommand<object>(async () => await GitHubClickAsync());
            LinkedInLinkCommand = new RelayCommand<object>(async () => await LinkedInClickAsync());
        }

        public async Task GitHubClickAsync()
        {
            var gitHubLink = _localizationService.GetString("GitHubLink");
            await _openUrlHelper.OpenUrlAsync(gitHubLink);
        }

        public async Task LinkedInClickAsync()
        {
            var linkedInLink = _localizationService.GetString("LinkedInLink");
            await _openUrlHelper.OpenUrlAsync(linkedInLink);
        }
    }
}
