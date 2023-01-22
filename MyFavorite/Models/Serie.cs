using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MyFavorite.Models
{
    public class Serie
    {
       
            [Key]
        [Required]
            public int id { get; set; }

            public string? poster_path { get; set; }

            public string? name { get; set; }

            public int season_number { get; set; }

            [MaxLength(500)]
            public string? overview { get; set; }

            

            public float? popularity { get; set; }


            public bool? video { get; set; }

            [DisplayName("Lingagem Original ")]
            public string? original_language { get; set; }

            
        }
}