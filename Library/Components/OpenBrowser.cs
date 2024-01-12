using System;

namespace Library.Components
{
    // The OpenBrowser class provides a method to open a URL in the default web browser.
    internal static class OpenBrowser
    {
        // The OpenLinkInBrowser method takes a base URL and an optional search query as parameters,
        // URL encodes the search query, appends it to the base URL, and opens the resulting URL in the default web browser.
        public static void OpenLinkInBrowser(string baseUrl, string searchQuery = "")
        {
            string urlEncodedSearchQuery = System.Web.HttpUtility.UrlEncode(searchQuery);

            // Create a new ProcessStartInfo object with the URL to open
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = $"{baseUrl}{urlEncodedSearchQuery}",
                UseShellExecute = true
            };

            // Start a new process to open the URL in the default web browser
            System.Diagnostics.Process.Start(psi);
        }
    }
}