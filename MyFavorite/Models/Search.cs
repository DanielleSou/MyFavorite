using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using Newtonsoft.Json;

namespace MyFavorite.Models
{
    public class Search
    {
        public int? id { get; set; }

        public string? media_type { get; set; }

        [JsonProperty("title")]
        private string? title { set { name = value; } }
        public string? name { get; set; }

        public string? poster_path { get; set; }
    }
}
