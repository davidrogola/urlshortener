using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrlShortenerService.Models;
using UrlShortenerService.Services;

namespace UrlShortenerService.Controllers
{
    public class UrlShortenerController : Controller
    {
        IUrlShortener urlShortener = null;

        public UrlShortenerController()
        {
            urlShortener = new UrlShortenerImp();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShortenUrl()
        {
            return View(new ShortenUrlViewModel { });
        }

        [HttpPost]
        public ActionResult ShortenUrl(ShortenUrlViewModel model)
        {
            var shortUrl = urlShortener.ShortenUrl(model.LongUrl);

            return View(new ShortenUrlViewModel { ShortUrl = shortUrl });
        }

        public ActionResult Get(string Id)
        {
            var shortUrl = urlShortener.GetLongUrlById(Guid.Parse(Id));
            return RedirectPermanent(shortUrl);
        }


    }
}