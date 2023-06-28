using API_New.Models;
using API_New.ViewModels;
using Client.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Client.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Results = await _userRepository.Get();
            var users = new List<Users>();

            if (Results != null)
            {
                users = Results.Data.ToList();
            }

            return View(users);
        }

        /*
         * LOGIN
         */
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var results = await _userRepository.Login(login);
            if (results.Code == 200)
            {
                HttpContext.Session.SetString("JWToken", results.Data);
                return RedirectToAction("Index", "Home");
            }
            else if (results.Code == 409)
            {
                ModelState.AddModelError(string.Empty, results.Message);
                return View();
            }
            return View();
        }

        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/User/Login");
        }

        /*
         -- registrasi
         -- untuk httpget alias untuk menampilkan tampilan form
         */
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            var result = await _userRepository.Register(register);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return Redirect("/User/Login");
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }

            return View();
        }

        /*
         -- create
         -- untuk httpget alias untuk menampilkan tampilan form
         */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Users user)
        {
            var result = await _userRepository.Post(user);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }

            return View();
        }

        /*
         -- details - get by id
         */
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {

            var Results = await _userRepository.Get(id);
            var user = Results.Data;

            //if (Results != null)
            //{
            //    employee = Results.Data;
            //}

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var Results = await _userRepository.Get(id);
            var user = new Users();

            if (Results.Data?.UserNIP is null)
            {
                return View(user);
            }
            else
            {
                user.UserNIP = Results.Data.UserNIP;
                user.Username = Results.Data.Username;
                user.Password = Results.Data.Password;
                user.FullName = Results.Data.FullName;
                user.Email = Results.Data.Email;
                user.PhoneNumber = Results.Data.PhoneNumber;
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Users users)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.Put(users.UserNIP, users);
                if (result.Code == 200)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (result.Code == 500)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return View();
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userRepository.Get(id);
            var user = result?.Data;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(string id)
        {
            var result = await _userRepository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }

            var user = await _userRepository.Get(id);
            return View("Delete", user?.Data);
        }
    }
}