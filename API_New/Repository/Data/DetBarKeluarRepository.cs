using API_New.Context;
using API_New.Models;
using API_New.Repository;
using API_New.Repository.Interface;

namespace API_New.Repository.Data
{
    public class DetBarKeluarRepository : GeneralRepository<DetailBarkeluar, int, MyContext>, IDetBarKeluarRepository
    {
        public DetBarKeluarRepository(MyContext context) : base(context) { }
    }
}
