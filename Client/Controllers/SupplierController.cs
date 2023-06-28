using API_New.Models;
using Client.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Client.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierRepository _supplierRepository;

        public SupplierController(SupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Results = await _supplierRepository.Get();
            var barang = new List<Supplier>();

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
        public async Task<IActionResult> Create(Supplier supplier)
        {
            var result = await _supplierRepository.Post(supplier);
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
            var Results = await _supplierRepository.Get(id);
            var barang = Results.Data;

            //if (Results != null)
            //{
            //    employee = Results.Data;
            //}

            return View(barang);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Results = await _supplierRepository.Get(id);
            var supplier = new Supplier();

            if (Results.Data?.Id is null)
            {
                return View(supplier);
            }
            else
            {
                supplier.Id = Results.Data.Id;
                supplier.Name
                    = Results.Data.Name;
            }
            return View(supplier);
        }

        /*
         -- edit
         -- HttpPost 
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var result = await _supplierRepository
                    .Put(supplier.Id, supplier);
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
            var result = await _supplierRepository.Get(id);
            var supplier = result?.Data;

            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _supplierRepository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }

            var supplier = await _supplierRepository.Get(id);
            return View("Delete", supplier?.Data);
        }
    }
}
