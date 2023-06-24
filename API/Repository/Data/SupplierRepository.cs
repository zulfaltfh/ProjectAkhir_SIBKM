using API.Context;
using API.Models;
using API.Repository.Interface;

namespace API.Repository.Data
{
    public class SupplierRepository : GeneralRepository<Supplier, int, MyContext>, ISupplierRepository
    {
        public SupplierRepository(MyContext context) : base(context) { }
    }
}
