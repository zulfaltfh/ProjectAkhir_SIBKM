using API_New.Context;
using API_New.Models;
using API_New.Repository.Interface;

namespace API_New.Repository.Data
{
    public class SupplierRepository : GeneralRepository<Supplier, int, MyContext>, ISupplierRepository
    {
        public SupplierRepository(MyContext context) : base(context) { }
    }
}
