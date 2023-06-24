using API.Context;
using API.Models;
using API.Repository.Interface;

namespace API.Repository.Data
{
    public class DetBarMasukRepository : GeneralRepository<DetailBarMasuk, int, MyContext>, IDetBarMasukRepository
    {
        public DetBarMasukRepository(MyContext context) : base(context) { }
    }
}
