using API_New.Context;
using API_New.Models;
using API_New.Repository;
using API_New.Repository.Interface;

namespace API_New.Repository.Data
{
    public class DetBarMasukRepository : GeneralRepository<DetailBarMasuk, int, MyContext>, IDetBarMasukRepository
    {
        public DetBarMasukRepository(MyContext context) : base(context) { }
    }
}
