using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using S_c_first.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public IActionResult SearchUser(string Searcher)
        {

            List<User_M> users = new List<User_M>();

            using (var db = new Demo_Context())
            {
                users = db.Users.Where(u => u.Name.ToLower().Contains(Searcher.ToLower())).ToList();

            }
            ViewBag.users = users;
            return View("AddUsers");
        }
        [HttpPost]
        public IActionResult UpdateUser(User_M user)
        {
            using (var db = new Demo_Context())
            {
                var userTemp = db.Users.Where(u => u.id == user.id).FirstOrDefault();

                TempData["userTemp"] = userTemp;
            }

            return View("UpdateUser");
        }

        public IActionResult UpdateUserFinal(User_M user)
        {
            using(var db = new Demo_Context())
            {
                var UpdateUserr = db.Users.Where(u => u.id == user.id).FirstOrDefault();

                UpdateUserr.Name = user.Name;
                UpdateUserr.Username = user.Username;
                UpdateUserr.Age = user.Age;
                UpdateUserr.email = user.email;

                db.SaveChanges();
            }
            return View("AddUsers");
        }
        public IActionResult AddUsers()
        {
            List<User_M> users = new List<User_M>();

            using (var db = new Demo_Context())
            {
                users = db.Users.ToList();

            }
            ViewBag.users = users;

            return View();
        }

        [HttpPost]
        public IActionResult AddUsers(User_M user)
        {
            var Valid = false;
            if (ModelState.IsValid)
                {
                using (var db = new Demo_Context())
                {
                    Valid = !db.Users.Any(var => var.email == user.email);
                    if (Valid)
                    {
                            db.Add(user);
                            db.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("", "uzytkownik znajduje sie w bazie");
                    }
                }
                }
            return View();
        }
        }
    }   


