using API_New.Context;
using API_New.Models;
using API_New.Repository.Interface;

namespace API_New.Repository.Data
{
    public class UserRolesRepository : GeneralRepository<UsersRole, int, MyContext>, IUserRolesRepository
    {
        public UserRolesRepository(MyContext context) : base(context) { }

        public IEnumerable<string> GetRolesByUsername(string username)
        {
           var getUserNIP = _context.Users.FirstOrDefault(x => x.Username == username)!.UserNIP;
           var getUserRoles = _context.UsersRoles
                                 .Where(ur => ur.UserNIP == getUserNIP)
                                 .Join(_context.Roles,
                                        ur => ur.RoleId,
                                        r => r.Id,
                                        (ar, r) => new { ar, r })
                                 .Select(role => role.r.Name);
            return getUserRoles;
        }
    }
}
