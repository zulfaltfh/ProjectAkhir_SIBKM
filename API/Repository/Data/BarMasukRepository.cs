using API.Context;
using API.Models;
using API.Repository.Interface;

namespace API.Repository.Data
{
    public class BarMasukRepository :GeneralRepository<BarangMasuk, int, MyContext>, IBarangMasukRepository
    {
        public BarMasukRepository(MyContext context) : base(context) { }
    }
}
