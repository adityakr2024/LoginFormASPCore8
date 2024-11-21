using System.Diagnostics;
using LoginFormASPCore8.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginFormASPCore8.Controllers
{
    public class HomeController : Controller
    {
        public LoginDbContext Context { get; } //create field for constructor

        public HomeController(LoginDbContext context) //create constructor
        {
            this.Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login() //LoginPage
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard"); //redirect to Dashboard incase already login
            }
            return View();
        }

        public IActionResult Logout() //logoutPage
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");   //destroy Session
                return RedirectToAction("Login");
            }
            return View();
        }


        [HttpPost]
        public IActionResult Login(TblUser user) //for matching
        {
            var myUser = Context.TblUsers.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault(); //matching crdentials with DB
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Email);
                return RedirectToAction("Dashboard");                         //if correct redirect to Dahboard
            }
            else
            {
                ViewBag.Message = "Login Failed";                             //else show login failed message
            }
            return View();
        }


        public IActionResult Dashboard()                                //Dashboard after login
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
            return View();  
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
