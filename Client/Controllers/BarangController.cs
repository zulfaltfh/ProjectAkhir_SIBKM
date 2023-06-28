using API_New.Models;
using Client.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Client.Controllers
{
    public class BarangController : Controller
    {
        private readonly BarangRepository _barangRepository;

        public BarangController(BarangRepository barangRepository)
        {
            _barangRepository = barangRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Results = await _barangRepository.Get();
            var barang = new List<Barang>();

            if (Results != null)
            {
                barang = Results.Data.ToList();
            }

            return View(barang);
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
        public async Task<IActionResult> Create(Barang barang)
        {
            var result = await _barangRepository.Post(barang);
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
        public async Task<IActionResult> Details(string id)
        {
            var Results = await _barangRepository.Get(id);
            var barang = Results.Data;

            //if (Results != null)
            //{
            //    employee = Results.Data;
            //}

            return View(barang);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var Results = await _barangRepository.Get(id);
            var barang = new Barang();

            if (Results.Data?.KodeBarang is null)
            {
                return View(barang);
            }
            else
            {
                barang.KodeBarang = Results.Data.KodeBarang;
                barang.NamaBarang = Results.Data.NamaBarang;
                barang.JenisBarang = Results.Data.JenisBarang;
                barang.Stock = Results.Data.Stock;
            }
            return View(barang);
        }

        /*
         -- edit
         -- HttpPost 
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Barang barang)
        {
            if (ModelState.IsValid)
            {
                var result = await _barangRepository
                    .Put(barang.KodeBarang, barang);
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
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _barangRepository.Get(id);
            var barang = result?.Data;

            return View(barang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(string id)
        {
            var result = await _barangRepository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }

            var barang = await _barangRepository.Get(id);
            return View("Delete", barang?.Data);
        }
    }
}
