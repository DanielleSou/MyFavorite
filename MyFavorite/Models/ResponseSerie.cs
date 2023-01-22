using System.ComponentModel.DataAnnotations;

namespace MyFavorite.Models
{
    public class ResponseSerie
    {
        public int? page { get; set; }
        public List<Serie>? results  { get; set; }

    }
}
