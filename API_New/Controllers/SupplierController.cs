using API_New.Base;
using API_New.Models;
using API_New.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SupplierController : GeneralController<ISupplierRepository, Supplier, int>
    {
        public SupplierController(
            ISupplierRepository supplierRepository
            ) : base(supplierRepository)
        {

        }

    }
}
