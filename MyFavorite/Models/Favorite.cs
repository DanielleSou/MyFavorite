using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFavorite.Models
{
    public class Favorite
    {
        [Key]
		public int  Id { get; set; } // id do favorito

        [Required]
		public int  IdApi{ get; set; } // id do filme ou serie

        [Required]
        public string Type { get; set; }  = null!; // filme ou serie

        // Navigation Property
		public string? IdentityUserId { get; set; }

		[ValidateNever]
		public IdentityUser IdentityUser { get; set; } = null!;
    }
}