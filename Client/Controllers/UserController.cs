using API_New.Models;
using Client.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

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
         -- registrasi
         -- untuk httpget alias untuk menampilkan tampilan form
         */
        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(Users user)
        //{
        //    var result = await _userRepository.Post(user);
        //    if (result.Code == 200)
        //    {
        //        TempData["Success"] = "Data berhasil masuk";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else if (result.Code == 409)
        //    {
        //        ModelState.AddModelError(string.Empty, result.Message);
        //        return View();
        //    }

        //    return View();
        //}

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
    }
}