using API_New.Models;
using Client.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Client.Controllers
{
    public class BarMasukController : Controller
    {
        private readonly BarMasukRepository repository;

        public BarMasukController(BarMasukRepository barMasukRepository)
        {
            repository = barMasukRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Results = await repository.Get();
            var barMasuk = new List<BarangMasuk>();

            if (Results != null)
            {
                barMasuk = Results.Data.ToList();
            }

            return View(barMasuk);
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

        /*
         -- create
         -- HttpPost untuk mengirimkan data yang diinputkan di form ke dalam database
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BarangMasuk barMasuk)
        {
            var result = await repository.Post(barMasuk);
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
         * Details --> get by id
         */
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Results = await repository.Get(id);
            var barMasuk = Results.Data;

            //if (Results != null)
            //{
            //    employee = Results.Data;
            //}

            return View(barMasuk);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Results = await repository.Get(id);
            var barMasuk = new BarangMasuk();

            if (Results.Data?.Id is null)
            {
                return View(barMasuk);
            }
            else
            {
                barMasuk.Id = Results.Data.Id;
                barMasuk.TanggalMasuk = Results.Data.TanggalMasuk;
                barMasuk.KodeBarang = Results.Data.KodeBarang;
                barMasuk.Jumlah = Results.Data.Jumlah;
                barMasuk.Supplier = Results.Data.Supplier;
                barMasuk.UserNIP = Results.Data.UserNIP;
            }
            return View(barMasuk);
        }

        /*
         -- edit
         -- HttpPost 
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BarangMasuk barMasuk)
        {
            if (ModelState.IsValid)
            {
                var result = await repository
                    .Put(barMasuk.Id, barMasuk);
                if (result.Code == 200)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (result.Code == 409)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return View();
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await repository.Get(id);
            var barMasuk = result?.Data;

            return View(barMasuk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await repository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }

            var barMasuk = await repository.Get(id);
            return View("Delete", barMasuk?.Data);
        }
    }
}
