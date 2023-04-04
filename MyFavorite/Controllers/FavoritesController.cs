using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using MyFavorite.Data;
using MyFavorite.Models;
using Newtonsoft.Json;

namespace MyFavorite.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FavoritesController(ApplicationDbContext db)
        {
            _db = db;

            Favorite serie = new Favorite();
            Favorite filme = new Favorite();

        }

        public IActionResult index()
        {
            getFavorites();
           
            
        return View();
        }
        
        [Authorize]
        public void getFavorites()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            String userId = claim!.Value;

            List<Favorite> FavoritesList = _db.Favorites.Where(_ => _.IdentityUserId == userId).ToList();

            List<ResponseDetailsSerie> seriesList = new();
            List<ResponseDetailsFilme> filmesList = new();

            foreach (Favorite favorite in FavoritesList)
            {
                switch (favorite.Type)
                {
                    case "serie":
                        ResponseDetailsSerie serie = getDetailsSerie(favorite.IdApi);
                        seriesList.Add(serie);
                        break;

                    case "filme":
                        ResponseDetailsFilme filme = getDetailsFilme(favorite.IdApi);
                        filmesList.Add(filme);
                        break;

                    default:
                        break;
                }
            }

            StringBuilder sbSerie = new();
            foreach (ResponseDetailsSerie serie in seriesList)
            {
                string image = serie == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + serie.poster_path;

                sbSerie.Append("<div class=\"col-lg-2 col-md-9 mb-2 d-flex align-items-stretch\" resourceId=\"" + serie!.id + "\">" +
                    "<div class=\"row p-2\">" +
                    "<div class=\"card border-light mb-3\">" +
                    "<img src=\"" + image + "\" class=\"card-img img-fluid\" alt=\"Image\" />" +
                    "<div class=\"card-name text-center pt-3\"><h5>" +
                    "<a class=\"text-decoration-none\" href=\"/Series/Details/" + serie!.id + "\">" +
                    serie.original_name + "</a></h5></div>" +
                    "</div></div></div>");
            }

            ViewData["Series"] = sbSerie.ToString();
            
            StringBuilder sbFilme = new();

            foreach (ResponseDetailsFilme filme in filmesList)
            {
                string image = filme == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + filme.poster_path;


                sbFilme.Append("<div class=\"col-lg-2 col-md-9 mb-2 d-flex align-items-stretch\" resourceId=\"" + filme.id + "\">" +
                    "<div class=\"row p-2\">" +
                    "<div class=\"card border-light mb-3\">" +
                    "<img src=\"" + image + "\" class=\"card-img img-fluid\" alt=\"Image\" />" +
                    "<div class=\"card-title text-center pt-3\"><h5>" +
                    "<a class=\"text-decoration-none\" href=\"/Filmes/Details/" + filme.id + "\">" +
                    filme.title + "</a></h5></div>" +
                    "</div></div></div>");
            }

            ViewData["Filmes"] = sbFilme.ToString();

        }


        private ResponseDetailsSerie getDetailsSerie(int id)
        {
            string apiKey = "824b02750cdd141a844ce98e04d02d29";
            string apiToRequest = "https://api.themoviedb.org/3/tv/" + id + "?api_key=" + apiKey + "&language=pt-PT";

            WebClient client = new();
            string content = client.DownloadString(apiToRequest);

            ResponseDetailsSerie rootObject = JsonConvert.DeserializeObject<ResponseDetailsSerie>(content)!;
            return rootObject;
        }

        
        
      
        private ResponseDetailsFilme getDetailsFilme(int id)
        {
            string apiKey = "824b02750cdd141a844ce98e04d02d29";
            string apiToRequest = "https://api.themoviedb.org/3/movie/" + id + "?api_key=" + apiKey + "&language=pt-PT";

            WebClient client = new();
            string content = client.DownloadString(apiToRequest);

            ResponseDetailsFilme rootObject = JsonConvert.DeserializeObject<ResponseDetailsFilme>(content)!;
            
            return rootObject;

        }

        
    }
}
