﻿using API_New.Base;
using API_New.Models;
using API_New.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BarMasukController : GeneralController<IBarangMasukRepository, BarangMasuk, int>
    {
        public BarMasukController(
            IBarangMasukRepository barangMasukRepository
            ) : base(barangMasukRepository)
        {

        }
    }
}
