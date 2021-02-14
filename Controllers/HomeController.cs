using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideotekaWebApp3.Models;

namespace VideotekaWebApp3.Controllers
{
    public class HomeController : Controller
    {   

        private List<Film> DohvatiFilmoveIzSessiona()
        {
            List<Film>filmovi = new List<Film>();
            filmovi = Session["filmovi"] as List<Film>;
            if (filmovi == null)
            {
                filmovi = new Film().DohvatiFilmove(50);
                Session["filmovi"] = filmovi;
            }

            return filmovi;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [Route("dohvatilistu/{count}")]
        public ActionResult ListaFilmova(int count)
        {
            //Film film = new Film();

            return PartialView(DohvatiFilmoveIzSessiona());
        }



        [HttpGet]
        [Route("dohvatilistupaginacija/{page}")]
        public ActionResult ListaFilmovaPaginacija(int page)
        {        
           var filmovi = DohvatiFilmoveIzSessiona().Skip(page).Take(10).ToList();
          return PartialView("ListaFilmova",filmovi);
        }


        [HttpGet]
        [Route("filmjson/{id}")]
        public ActionResult FilmJson(int id)
        {        
           var film = DohvatiFilmoveIzSessiona().FirstOrDefault(x=>x.Id == id);
          return Json(film, JsonRequestBehavior.AllowGet);
        }

    }
}