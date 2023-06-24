using API.Context;
using API.Models;
using API.Repository.Interface;

namespace API.Repository.Data
{
    public class BarKeluarRepository : GeneralRepository<BarangKeluar, int, MyContext>, IBarangKeluarRepository
    {
        public BarKeluarRepository(MyContext context) : base(context) { }
    }
}
