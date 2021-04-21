using BanHang.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
//using PagedList;

namespace BanHang.Controllers
{
    public class HomeController : Controller
    {
        private ConnectDB db = new ConnectDB();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var product = db.Products.Include(m => m.Category).ToList();
            return View(product);
        }
        //Kiểm tra đăng nhập 
        [Authorize]
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
        //GET : Register
        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //POST : Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.Users.FirstOrDefault(m => m.Email == _user.Email); //m = model, kiểm tra xem email có trong database hay chưa
                if (checkEmail == null) // check email
                {
                    _user.Password = GETMD5(_user.Password); //mã hóa password người dùng nhập
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Home");// đăng kí thành công trả về trang login
                }
                else
                {
                    ViewBag.EmailError = " Email đã tồn tại ";
                    return RedirectToAction("Register");
                }
            }
            return View();

        }
        //GET:Login
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //POST : Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            var passToMD5 = GETMD5(password);
            var ktra_tk = db.Users.Where(m => m.Email.Equals(email) && m.Password.Equals(passToMD5)).FirstOrDefault();
            if (ktra_tk != null)
            {
                Session["id_user"] = ktra_tk.IdUser;
                Session["name_user"] = ktra_tk.UserName;
                var checkAdmin = ktra_tk.Role;// kiểm tra có phải admin 
                if (checkAdmin == "admin")
                {
                    return RedirectToAction("Index", "Home", new { Area = "admin" });
                }
                else
                {
                    return RedirectToAction("Index");
                }
                //return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LoginError = "Đăng nhập thất bại";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return Redirect("/Home");
        }

        // CREATE MD5 : mã hóa dữ liệu 1 chiều
        public static string GETMD5(string Str) //Getmd5 truyền đến 1 mảng
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(Str);
            byte[] targetData = md5.ComputeHash(fromData);
            string mahoa = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                mahoa += targetData[i].ToString("x2");

            }
            return mahoa;
        }
        //linq: tạo action trả về dữ liệu bảng account 
        /*public ActionResult DemoLinq ()
        {
            var list = ( from acc in db.users
                       join role in db.Roles on acc.RoleID equals role.RoleID
                       select new
                       {
                           acc.user,
                           role.RoleName,
                       }).ToList();
            var ac = db.users.ToList();
            return (View(ac));
        }*/

        //public ViewResult PageList(int? page)
        //{
        //    var pagesize = 3;
        //    var model = db.Products.ToList();
        //    int pageNumber = page ?? 1;
        //    return View(model.ToPagedList(pageNumber, pagesize));
        //}
    }
}