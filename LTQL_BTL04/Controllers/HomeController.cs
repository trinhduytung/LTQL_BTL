using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LTQL_BTL04.Models;
using System.Data.Entity;


namespace LTQL_BTL04.Controllers
{
   

    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            var matHangs = db.MatHangs.Include(S => S.LoaiHang);
            return View(matHangs.ToList());
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
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string password)
        {
            if (ModelState.IsValid)
            {
                var ma_hoa_du_lieu = GETMD5(password);
                var kiem_tra_tai_khoan = db.KhachHangs.Where(s => s.Email.Equals(Email) && s.password.Equals(ma_hoa_du_lieu)).ToList();
                if (kiem_tra_tai_khoan != null)
                {
                    Session["MaKhachHang"] = kiem_tra_tai_khoan.FirstOrDefault().MaKH;
                    Session["TenKhachHang"] = kiem_tra_tai_khoan.FirstOrDefault().TenKH;
                    var checkAdmin = kiem_tra_tai_khoan.FirstOrDefault().Role;
                    if (checkAdmin == "Admin")
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    ViewBag.LoginError = "Đăng nhập không thành công ";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Khachhang kh)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.KhachHangs.FirstOrDefault(m => m.Email == kh.Email);//kiểm tra trong database đã có email chưa
                if (checkEmail == null)//nếu không lấy email ở trong database thì sẽ lấy dữ liệu người dùng nhập vào
                {
                    kh.password = GETMD5(kh.password);
                    db.Configuration.ValidateOnSaveEnabled = false;//check điều kiện
                    db.KhachHangs.Add(kh);
                    _ = db.SaveChanges();
                    return RedirectToAction("Login");//trả về trang Login
                }
                else
                {
                    ViewBag.EmailError = "Email đã tồn tại";
                    return RedirectToAction("Register");
                }
            }
            return View();
        }
        public static string GETMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();// nhấn Ctrl . để sửa lỗi
            byte[] fromData = Encoding.UTF8.GetBytes(pass);// nhấn Ctrl . để sửa lỗi
            byte[] targetData = md5.ComputeHash(fromData);
            string mat_khau_ma_hoa = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                mat_khau_ma_hoa += targetData[i].ToString("x2");

            }
            return mat_khau_ma_hoa;


        }
    }
}