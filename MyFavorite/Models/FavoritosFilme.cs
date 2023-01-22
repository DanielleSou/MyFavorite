using System.ComponentModel.DataAnnotations;

namespace MyFavorite.Models
{
    public class FavoritosFilme

    {
        [Key]
        public int id { get; set; }

        [Required]
        public int idFilme { get; set; }
        
        [Required]
        public int UserId { get; set; }

    }
}
