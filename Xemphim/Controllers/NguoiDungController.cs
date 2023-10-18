using Xemphim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Xemphim.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        XemPhimEntities database = new XemPhimEntities();
        XemPhimEntities UserDataBase = new XemPhimEntities();
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(kh.HoTenKH))
                    ModelState.AddModelError(String.Empty, "Họ tên không được để trống");
                if (String.IsNullOrEmpty(kh.TenDangNhap))
                    ModelState.AddModelError(String.Empty, "Tên đăng nhập không được để trống");
                if (String.IsNullOrEmpty(kh.MatKhau))
                    ModelState.AddModelError(String.Empty, "Mật Khẩu không được để trống");
                if (String.IsNullOrEmpty(kh.Email))
                    ModelState.AddModelError(String.Empty, "Email không được để trống");

                var khachhang = database.KhachHangs.FirstOrDefault(k => k.TenDangNhap == kh.TenDangNhap);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng ký tên này");

                if (ModelState.IsValid)
                {
                    database.KhachHangs.Add(kh);
                    database.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("DangNhap");
        }

        public ActionResult DangNhap(KhachHang kh)
        {
            if(ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.TenDangNhap))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(kh.MatKhau))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if(ModelState.IsValid)
                {
                    var khach = database.KhachHangs.FirstOrDefault(k => k.TenDangNhap == kh.TenDangNhap && k.MatKhau == kh.MatKhau);
                    if (khach != null)
                    {
                        ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";

                        Session["TaiKhoan"] = khach.TenDangNhap;
                    }
                    else
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }

        public ActionResult ChiTietUser(string tkkh)
        {
            var User = UserDataBase.KhachHangs.FirstOrDefault(s => s.TenDangNhap == tkkh);
            return View(User);
        }
        //[HttpGet]
        //public ActionResult DangKy1(int id =0)
        //{
        //    KhachHang userModel = new KhachHang();
        //    return View(userModel);
        //}
        //[HttpPost]
        //public ActionResult DangKy1(KhachHang kh)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (String.IsNullOrEmpty(kh.HoTenKH))
        //            ModelState.AddModelError(String.Empty, "Họ tên không được để trống");
        //        if (String.IsNullOrEmpty(kh.TenDangNhap))
        //            ModelState.AddModelError(String.Empty, "Tên đăng nhập không được để trống");
        //        if (String.IsNullOrEmpty(kh.MatKhau))
        //            ModelState.AddModelError(String.Empty, "Mật Khẩu không được để trống");
        //        if (String.IsNullOrEmpty(kh.Email))
        //            ModelState.AddModelError(String.Empty, "Email không được để trống");

        //        var khachhang = database.KhachHangs.FirstOrDefault(k => k.TenDangNhap == kh.TenDangNhap);
        //        if (khachhang != null)
        //            ModelState.AddModelError(string.Empty, "Đã có người đăng ký tên này");

        //        if (ModelState.IsValid)
        //        {
        //            database.KhachHangs.Add(kh);
        //            database.SaveChanges();
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    return RedirectToAction("DangNhap");
    }
}
