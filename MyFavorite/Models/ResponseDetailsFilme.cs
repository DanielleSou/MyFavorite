using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
namespace MyFavorite.Models
{
    public class ResponseDetailsFilme
    {
        public int?  id { get; set; }
        public string? name { get; set; }
        public string? title { get; set; }
        public string? overview { get; set; }

        public string? status { get; set; }

        public string? poster_path { get; set;  }
        public string? release_date { get; set; }
        public List<Company>? production_companies { get; set; }
        public List<Country>? production_countries { get; set; }


    }
}
