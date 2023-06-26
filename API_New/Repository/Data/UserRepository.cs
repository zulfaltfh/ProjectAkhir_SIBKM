using API_New.Context;
using API_New.Handlers;
using API_New.Models;
using API_New.Repository.Interface;
using API_New.ViewModels;

namespace API_New.Repository.Data
{
    public class UserRepository : GeneralRepository<Users,string, MyContext>, IUsersRepository
    {
        public UserRepository(MyContext context) : base(context) { }

        public bool Login(LoginVM loginVM)
        {
            var getUser = _context.Users.FirstOrDefault(e => e.Username == loginVM.Username);

            if (getUser == null)
                return false;

            return Hashing.ValidatePassword(loginVM.Password, getUser.Password);
        }

        public int Register(RegisterVM registerVM)
        {
            int result = 0;

            //insert to table User
            var user = new Users
            {
                UserNIP = registerVM.UserNIP,
                Username = registerVM.Username,
                Password = Hashing.HashPassword(registerVM.Password),
                FullName = registerVM.FullName,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
            };
            _context.Set<Users>().Add(user);
            result = _context.SaveChanges();

            //insert to UsersRole Table
            var usersRole = new UsersRole
            {
                UserNIP = registerVM.UserNIP,
                RoleId = 2 //as a karyawan biasa
            };
            _context.Set<UsersRole>().Add(usersRole);
            result = _context.SaveChanges();

            return result;
        }
    }
}
