using System.ComponentModel.DataAnnotations;

namespace MyFavorite.Models
{
    public class FavoritosSerie

    {
        [Key]
        public int id { get; set; }

        [Required]
        public int idSerie { get; set; }


        [Required]
        public int UserId { get; set; }

    }
}
