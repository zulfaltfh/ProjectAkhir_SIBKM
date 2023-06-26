using API_New.Context;
using API_New.Models;
using API_New.Repository.Interface;

namespace API_New.Repository.Data
{
    public class RolesRepository : GeneralRepository<Roles,int,MyContext>, IRolesRepository
    {
        public RolesRepository(MyContext context) : base(context) { }
    }
}
