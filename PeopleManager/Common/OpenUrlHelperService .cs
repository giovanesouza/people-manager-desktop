using PeopleManager.Abstracts;
using System.Diagnostics;

namespace PeopleManager.Common
{
    public class OpenUrlHelperService : IOpenUrlHelperService
    {
        public async Task OpenUrlAsync(string url)
        {
            if (string.IsNullOrEmpty(url)) return;

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri _)) return;

            await Task.Run(() =>
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true,
                });
            });
        }
    }
}
