using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Notion.Client;

namespace BusinessLogic
{
    public class MyBodyExtension : PagesCreateParameters
    {
        public TemplateParameter? Template { get; set; }
    }

    public class TemplateParameter
    {
        [JsonProperty("type")]
        public virtual string? Type { get; set; }
    }

    public class Business
    {
        bool intitated = false;
        private string theToken = string.Empty;
        public Business() { }

        public async Task CreateTask(string taskTitle)
        {

            var client = NotionClientFactory.Create(new ClientOptions
            {
                AuthToken = theToken
            });
            // using
            //try
            // {


            //
            var reqBody = new MyBodyExtension
            {
                Properties = new Dictionary<string, Notion.Client.PropertyValue>(),
                Parent = new Notion.Client.DatabaseParentInput() { DatabaseId = "5cc4331a-8fb9-4d69-bb08-940c188f0715" },
                Template = new TemplateParameter { Type = "default" },

            };
            reqBody.Properties.Add("Name", new TitlePropertyValue { Title = new List<RichTextBase> { new RichTextBase() { PlainText = taskTitle } } });
            // data_source
            var sdsss = await client.Pages.CreateAsync(reqBody);
            if (sdsss != null)
            {

            }
            //}
            //catch (NotionApiRateLimitException rateLimitEx)
            //{
            //    // Handle rate limit - check rateLimitEx.RetryAfter for when to retry
            //   WriteLine($"Rate limited. Retry after: {rateLimitEx.RetryAfter}");
            //}
            //catch (NotionApiException apiEx)
            //{
            //    // Handle other API errors
            //    Console.WriteLine($"API Error: {apiEx.NotionAPIErrorCode} - {apiEx.Message}");
            //}
        }

        public void Init(string token)
        {
            this.theToken = token;
            //var client = NotionClientFactory.Create(new ClientOptions
            //{
            //    AuthToken = token
            //});
            intitated = true;
        }
    }
}
