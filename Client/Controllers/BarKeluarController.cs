using API_New.Models;
using Client.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Client.Controllers
{
    public class BarKeluarController : Controller
    {
        private readonly BarKeluarRepository repository;

        public BarKeluarController(BarKeluarRepository barKeluarRepository)
        {
            repository = barKeluarRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Results = await repository.Get();
            var barKeluar = new List<BarangKeluar>();

            if (Results != null)
            {
                barKeluar = Results.Data.ToList();
            }

            return View(barKeluar);
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
        public async Task<IActionResult> Create(BarangKeluar barKeluar)
        {
            var result = await repository.Post(barKeluar);
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
            var barKeluar = Results.Data;

            //if (Results != null)
            //{
            //    employee = Results.Data;
            //}

            return View(barKeluar);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Results = await repository.Get(id);
            var barKeluar = new BarangKeluar();

            if (Results.Data?.Id is null)
            {
                return View(barKeluar);
            }
            else
            {
                barKeluar.Id = Results.Data.Id;
                barKeluar.TanggalKeluar = Results.Data.TanggalKeluar;
                barKeluar.KodeBarang = Results.Data.KodeBarang;
                barKeluar.Jumlah = Results.Data.Jumlah;
                barKeluar.Pembeli = Results.Data.Pembeli;
                barKeluar.UserNIP = Results.Data.UserNIP;
            }
            return View(barKeluar);
        }

        /*
         -- edit
         -- HttpPost 
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BarangKeluar barKeluar)
        {
            if (ModelState.IsValid)
            {
                var result = await repository
                    .Put(barKeluar.Id, barKeluar);
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
            var barKeluar = result?.Data;

            return View(barKeluar);
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

            var barKeluar = await repository.Get(id);
            return View("Delete", barKeluar?.Data);
        }
    }
}
