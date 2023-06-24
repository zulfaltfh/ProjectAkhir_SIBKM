using API.Base;
using API.Models;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GeneralController<IUsersRepository, Users, string>
    {
        public UserController(
            IUsersRepository usersRepository
            ) : base(usersRepository)
        {
            
        }

    }
}
