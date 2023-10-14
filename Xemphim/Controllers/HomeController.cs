using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xemphim.Models;

namespace Xemphim.Controllers
{
    public class HomeController : Controller
    {
        XemPhimEntities databse = new XemPhimEntities();
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
        public ActionResult Trailer()
        {

            return View();
        }
        public ActionResult TrangChu()
        {
            using (var dbContext = new XemPhimEntities())
            {
                var items = dbContext.Phims.ToList();

                return View(items);
            }

        }
        public ActionResult NewMovie()
        {
            return View();

        }
        public ActionResult DangNhap()
        {
            return View();

        }
        public ActionResult ChiTietPhim(int Id)
        {
            var Phim = databse.Phims.FirstOrDefault(s => s.IdPhim == Id);
            return View(Phim);
        }
        public ActionResult XemPhim(int Id)
        {
            var Phim = databse.Phims.FirstOrDefault(s => s.IdPhim == Id);
            return View(Phim);
        }
    }
}