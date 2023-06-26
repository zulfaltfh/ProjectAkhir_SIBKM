using API_New.Context;
using API_New.Models;
using API_New.Repository.Interface;

namespace API_New.Repository.Data
{
    public class BarKeluarRepository : GeneralRepository<BarangKeluar, int, MyContext>, IBarangKeluarRepository
    {
        public BarKeluarRepository(MyContext context) : base(context) { }
    }
}
