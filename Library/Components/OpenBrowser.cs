using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Components
{
    internal static class OpenBrowser
    {
        public static void OpenLinkInBrowser(string baseUrl, string searchQuery = "")
        {
            string urlEncodedSearchQuery = System.Web.HttpUtility.UrlEncode(searchQuery);
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = $"{baseUrl}{urlEncodedSearchQuery}",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
        }
    }
}
