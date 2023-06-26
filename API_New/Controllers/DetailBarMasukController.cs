using API_New.Base;
using API_New.Models;
using API_New.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailBarMasukController : GeneralController<IDetBarMasukRepository, DetailBarMasuk, int>
    {
        public DetailBarMasukController(IDetBarMasukRepository detBarMasukRepository) : base(detBarMasukRepository)
        {
        }
    }
}
