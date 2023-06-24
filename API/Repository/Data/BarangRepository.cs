using API.Context;
using API.Models;
using API.Repository.Interface;

namespace API.Repository.Data
{
    public class BarangRepository : GeneralRepository<Barang, string, MyContext>, IBarangRepository
    {
        public BarangRepository(MyContext context) : base(context) { }
    }
}
