using API.Context;
using API.Models;
using API.Repository.Interface;

namespace API.Repository.Data
{
    public class UserRepository : GeneralRepository<Users,string, MyContext>, IUsersRepository
    {
        public UserRepository(MyContext context) : base(context) { }
    }
}
