using API_New.Models;
using Client.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Client.Controllers
{
    public class BarMasukController : Controller
    {
        private readonly BarMasukRepository _barMasukRepository;

        public BarMasukController(BarMasukRepository barMasukRepository)
        {
            _barMasukRepository = barMasukRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Results = await _barMasukRepository.Get();
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
        public async Task<IActionResult> Create(BarangMasuk barangMasuk)
        {
            var result = await _barMasukRepository.Post(barangMasuk);
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
            var Results = await _barMasukRepository.Get(id);
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
            var Results = await _barMasukRepository.Get(id);
            var barMasuk = new BarangMasuk();

            if (Results.Data?.Id is null)
            {
                return View(barMasuk);
            }
            else
            {
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
        public async Task<IActionResult> Edit(BarangMasuk barangMasuk)
        {
            if (ModelState.IsValid)
            {
                var result = await _barMasukRepository.Put(barangMasuk.Id, barangMasuk);
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
            var result = await _barMasukRepository.Get(id);
            var barangMasuk = result?.Data;

            return View(barangMasuk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _barMasukRepository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }

            var barangMasuk = await _barMasukRepository.Get(id);
            return View("Delete", barangMasuk?.Data);
        }
    }
}
