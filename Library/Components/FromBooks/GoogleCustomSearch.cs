using Newtonsoft.Json;
using System.Configuration;
using System.Web;
public class GoogleCustomSearch
{
    private PictureBox pictureBox1;
    private TextBox textBox1;
    public string linkToGoogleBookPage;

    // The constructor takes a PictureBox and a TextBox as parameters and stores them in the pictureBox1 and textBox1 fields.
    public GoogleCustomSearch(PictureBox pictureBox, TextBox textBox)
    {
        pictureBox1 = pictureBox;
        textBox1 = textBox;
    }

    // The GetGoogleCustomSearch method performs a Google Custom Search for the specified book title, and updates the PictureBox and TextBox with the image and snippet of the first search result.
    // It also stores the link to the Google Books page of the first search result in the linkToGoogleBookPage field.
    public async Task GetGoogleCustomSearch(string title)
    {
        // Get the API key and cx (search engine ID) from the app settings
        string apiKey = ConfigurationManager.AppSettings["GoogleCustomSearchApiKey"];
        string cx = ConfigurationManager.AppSettings["GoogleCustomSearchCx"];
        // URL encode the book title
        string urlEncodedBookTitle = HttpUtility.UrlEncode(title);
        // Construct the API URL
        string apiUrl = $"https://www.googleapis.com/customsearch/v1?key={apiKey}&cx={cx}&q={urlEncodedBookTitle}";

        using (HttpClient client = new HttpClient())
        {
            // Send a GET request to the API URL
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                // Deserialize the JSON content
                dynamic json = JsonConvert.DeserializeObject(content);
                // Get the image URL and snippet from the first search result
                string imageUrl = json.items[0].pagemap.cse_image[0].src;
                imageUrl = imageUrl.Replace("zoom=1", "zoom=0");
                string description = json.items[0].snippet;

                // Update the PictureBox and TextBox with the image and snippet
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Load(imageUrl);
                textBox1.Text = description;
                // Store the link to the Google Books page of the first search result
                linkToGoogleBookPage = json.items[0].link;
            }
        }
    }
}