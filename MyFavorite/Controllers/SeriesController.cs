using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyFavorite.Data;
using MyFavorite.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MyFavorite.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SeriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? pageNo)
        {
            int pageToRequest = (int)(pageNo == null ? 1 : pageNo);
            CallAPIForPopularTv(Convert.ToInt32(pageNo));

            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            string apiKey = "824b02750cdd141a844ce98e04d02d29";
            string apiToRequest = "https://api.themoviedb.org/3/tv/" + id + "?api_key=" + apiKey + "&language=pt-PT";

            WebClient client = new();
            string content = client.DownloadString(apiToRequest);

            ResponseDetailsSerie rootObject = JsonConvert.DeserializeObject<ResponseDetailsSerie>(content)!;
            //HttpContext.Session["selectedSerie"] = rootObject;

            return View(rootObject);
        }

        //[Authorize]
        public IActionResult Favorito(int id)
        {
            //ResponseDetailsSerie? selectedSerie = (ResponseDetailsSerie?)Session["selectedSerie"];
            if (ModelState.IsValid)
            {
                //_db.Series.Add(selectedSerie);
                //_db.SaveChanges();
                TempData["sucesso"] = "Adicionada com sucesso";
            }
            return RedirectToAction("Details", new { id = id });
        }

        public void CallAPIForPopularTv(int? page)
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

            ViewBag.Result = sb.ToString();
        }
    }
}
