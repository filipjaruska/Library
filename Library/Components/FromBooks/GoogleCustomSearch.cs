using Newtonsoft.Json;
using System.Configuration;
using System.Web;

public class GoogleCustomSearch
{
    private PictureBox pictureBox1;
    private TextBox textBox1;
    public string linkToGoogleBookPage;

    public GoogleCustomSearch(PictureBox pictureBox, TextBox textBox)
    {
        pictureBox1 = pictureBox;
        textBox1 = textBox;
    }

    public async Task GetGoogleCustomSearch(string title)
    {
        string apiKey = ConfigurationManager.AppSettings["GoogleCustomSearchApiKey"];
        string cx = ConfigurationManager.AppSettings["GoogleCustomSearchCx"];
        string urlEncodedBookTitle = HttpUtility.UrlEncode(title);
        string apiUrl = $"https://www.googleapis.com/customsearch/v1?key={apiKey}&cx={cx}&q={urlEncodedBookTitle}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(content);
                string imageUrl = json.items[0].pagemap.cse_image[0].src;
                imageUrl = imageUrl.Replace("zoom=1", "zoom=0");
                string description = json.items[0].snippet;

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Load(imageUrl);
                textBox1.Text = description;
                linkToGoogleBookPage = json.items[0].link;
            }
        }
    }
}