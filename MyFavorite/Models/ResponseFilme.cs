using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;


namespace MyFavorite.Models

{
    public class ResponseFilme
    {
        public int page { get; set; }
        public List<Filme>? results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    
    }
}
