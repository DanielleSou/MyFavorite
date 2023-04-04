using System.ComponentModel.DataAnnotations;


namespace MyFavorite.Models
{
    public class ResponseDetailsSerie
    {
        [Key]
        public int id { get; set; }

        public int? page { get; set; }
        public string? backdrop_path { get; set; }

        public string? original_name { get; set; }

        public string? poster_path { get; set; }
        public string? overview { get; set; }
        public string? first_air_date { get; set; }
        public string? last_air_date { get; set; }
        public string? homepage { get; set; }
        public int? number_of_episodes { get; set; }
        public int? number_of_seasons { get; set; }

        public List<Company>? production_companies { get; set; }
        public List<Country>? production_countries { get; set; }




    }

}
