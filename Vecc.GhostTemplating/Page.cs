using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Text.Json.Serialization;

namespace Vecc.GhostTemplating
{
    public class Page : Post
    {
        [JsonPropertyName("mobile_doc")]
        public string MobileDoc { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        public override Header GetHeader()
        {
            var result = new Header();

            if (Tags != null && Tags.Any())
            {
                result.BodyClasses = "page-template page-tags";
            }
            else
            {
                result.BodyClasses = "page-template";
            }

            result.Author = PrimaryAuthor;
            result.Description = MetaDescription ?? CustomExcerpt ?? Excerpt;
            result.ImageHeight = 0;
            result.ImageWidth = 0;
            result.OGDescription = OGDescription;
            result.OGImage = OGImage;
            result.OGTitle = OGTitle;
            result.OGUrl = Url;
            result.Settings = Settings;
            result.Title = Title;
            result.TwitterCard = "summary";
            result.TwitterDescription = TwitterDescription;
            result.TwitterImage = TwitterImage;
            result.TwitterTitle = TwitterTitle;
            result.TwitterUrl = Url;
            result.Url = Url;

            return result;
        }
    }
}
