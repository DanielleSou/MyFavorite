using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyFavorite.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

using System.Text;

namespace MyFavorite.Controllers

{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            CallAPI(Convert.ToInt32(1));
            CallAPIForTv(Convert.ToInt32(1));

            return View();
        }

       
        public void CallAPI(int page)
        {
            int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);
            string apiKey = "824b02750cdd141a844ce98e04d02d29";
            string apiToRequest = "https://api.themoviedb.org/3/movie/now_playing?api_key=" + apiKey + "&language=pt-PT&page=" + pageNo + "&include_adult=false";

            WebClient client = new();
            string content = client.DownloadString(apiToRequest);

            ResponseFilme rootObject = JsonConvert.DeserializeObject<ResponseFilme>(content)!;


            StringBuilder sb = new();

            foreach (Filme result in rootObject.results!)
            {
                string image = result == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + result.poster_path;


                sb.Append("<div class=\"col-lg-2 col-md-9 mb-2 d-flex align-items-stretch\" resourceId=\"" + result!.id + "\">" +
                    "<div class=\"row p-2\">" +
                    "<div class=\"card border-light mb-3\">" +
                    "<img src=\"" + image + "\" class=\"card-img img-fluid\" alt=\"Image\" />" +
                    "<div class=\"card-title text-center pt-3\"><h5>" +
                    "<a class=\"text-decoration-none\" href=\"/Filmes/Details/" + result!.id + "\">" +
                    result.title + "</a></h5></div>" +
                    "</div></div></div>");

            }
            ViewBag.Result = sb.ToString();
        }

        public void CallAPIForTv(int page)
        {

            int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);
            string apiKey = "824b02750cdd141a844ce98e04d02d29";
            string apiToRequest = "https://api.themoviedb.org/3/tv/popular?api_key=" + apiKey + "&language=pt-PT&page=" + pageNo + "&include_adult=false";

            WebClient client = new();
            string content = client.DownloadString(apiToRequest);

            ResponseSerie rootObject = JsonConvert.DeserializeObject<ResponseSerie>(content)!;

            StringBuilder sb = new();

            foreach (Serie result in rootObject.results!)
            {
                string image = result == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + result.poster_path;


                sb.Append("<div class=\"col-lg-2 col-md-9 mb-2 d-flex align-items-stretch\" resourceId=\"" + result!.id + "\">" +
                    "<div class=\"row p-2\">" +
                    "<div class=\"card border-light mb-3\">" +
                    "<img src=\"" + image + "\" class=\"card-img img-fluid\" alt=\"Image\" />" +
                    "<div class=\"card-name text-center pt-3\"><h5>" +
                    "<a class=\"text-decoration-none\" href=\"/Series/Details/" + result!.id + "\">" +
                    result.name + "</a></h5></div>" +
                    "</div></div></div>");
            }

            ViewData["Series"] = sb.ToString();
        }

    }
 
}

   




