using API_New.Models;
using API_New.ViewModels;

namespace API_New.Repository.Interface
{
    public interface IUsersRepository : IGeneralRepository<Users,string>
    {
        int Register(RegisterVM registerVM);
        bool Login(LoginVM loginVM);
    }
}
