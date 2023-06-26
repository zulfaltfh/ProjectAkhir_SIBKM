using API_New.Base;
using API_New.Handlers;
using API_New.Models;
using API_New.Repository.Interface;
using API_New.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace API_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : GeneralController<IUsersRepository, Users, string>
    {
        //private readonly IUsersRepository _usersRepository;
        private readonly ITokenService _tokenService;
        private readonly IUserRolesRepository _userRolesRepository;

        public UserController(
            IUsersRepository usersRepository,
            ITokenService tokenService, IUserRolesRepository userRolesRepository
            ) : base(usersRepository) 
        {
            _tokenService = tokenService;
            _userRolesRepository = userRolesRepository;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = _repository.Login(loginVM);
            if (!login)
            {
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Login Failed, Account or Password Not Found!"
                });
            }

            var claims = new List<Claim>()
            {
                new Claim("Username", loginVM.Username),
                new Claim("Password", loginVM.Password)
            };

            var getRoles = _userRolesRepository.GetRolesByUsername(loginVM.Username);
            foreach (var role in getRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role ));
            }

            var token = _tokenService.GenerateToken(claims);

            return Ok(new ResponseDataVM<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Login Success",
                Data = token
            });

        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var register = _repository.Register(registerVM);
            if (register > 0)
            {
                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Register Success"
                });
            }

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Register Failed"
            });
        }
    }
}
