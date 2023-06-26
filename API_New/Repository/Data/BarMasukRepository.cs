using API_New.Context;
using API_New.Models;
using API_New.Repository.Interface;

namespace API_New.Repository.Data
{
    public class BarMasukRepository :GeneralRepository<BarangMasuk, int, MyContext>, IBarangMasukRepository
    {
        public BarMasukRepository(MyContext context) : base(context) { }
    }
}
