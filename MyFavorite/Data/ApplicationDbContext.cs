using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFavorite.Models;

namespace MyFavorite.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<ResponseDetailsSerie> Series { get; set; }

        public DbSet< ResponseDetailsFilme> FavoritosFilme { get; set;}
       
        public DbSet<ResponseDetailsSerie> FavoritosSerie { get; set; }
    }

}
