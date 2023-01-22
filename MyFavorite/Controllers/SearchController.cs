using Microsoft.AspNetCore.Mvc;
using MyFavorite.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;


namespace MyFavorite.Controllers
{
    public class SearchController : Controller
    {
      

        public IActionResult Index()
        {
            
            string query = Request.QueryString.ToString().Replace("?query=","");
            GetCollection(query);

            return View();
        }
       
        public void GetCollection(string search)
        {
            string apiKey = "824b02750cdd141a844ce98e04d02d29";
            string apiToRequest = "https://api.themoviedb.org/3/search/multi?api_key=" + apiKey + "&query=" + search + "&language=pt-PT&include_adult=false";

            WebClient client = new();
            string content = client.DownloadString(apiToRequest);

            ResponseSearch rootObject = JsonConvert.DeserializeObject<ResponseSearch>(content);

            StringBuilder sb = new();
            
            
            foreach (Search result in rootObject.results!)
            {
                if (result.media_type != "person")
                {
                    string image = result == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + result.poster_path;
                    string detailsLink = "";



                    if (result!.media_type == "movie")
                    {
                        detailsLink = "<a class=\"text-decoration-none\" href=\"/Filmes/Details/" + result!.id + "\">";
                    }
                    else if (result!.media_type == "tv")
                    {
                        detailsLink = "<a class=\"text-decoration-none\" href=\"/Series/Details/" + result!.id + "\">";
                    }


                    sb.Append("<div class=\"col-lg-2 col-md-9 mb-2 d-flex align-items-stretch\" resourceId=\"" + result! + "\">" +
                        "<div class=\"row p-2\">" +
                        "<div class=\"card border-light mb-3\">" +
                        "<img src=\"" + image + "\" class=\"card-img img-fluid\" alt=\"Image\" />" +
                        "<div class=\"card-name text-center pt-3\"><h5>" +
                        detailsLink +
                        result!.name + "</a></h5></div>" +
                        "</div></div></div>");
                }
               
            }


            ViewBag.Result = sb.ToString();
        }
    }
}
