using API_New.Models;
using API_New.ViewModels;

namespace API_New.Repository.Interface
{
    public interface IUserRolesRepository : IGeneralRepository<UsersRole, int>
    {
        IEnumerable<string> GetRolesByUsername(string username);
    }
}
