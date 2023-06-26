using API_New.Context;
using API_New.Models;
using API_New.Repository.Interface;

namespace API_New.Repository.Data
{
    public class BarangRepository : GeneralRepository<Barang, string, MyContext>, IBarangRepository
    {
        public BarangRepository(MyContext context) : base(context) { }
    }
}
