﻿using API_New.Base;
using API_New.Models;
using API_New.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RolesController : GeneralController<IRolesRepository, Roles, int>
    {
        public RolesController(
            IRolesRepository rolesRepository
            ) : base(rolesRepository)
        {

        }

    }
}
