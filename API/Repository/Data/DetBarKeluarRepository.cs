using API.Context;
using API.Models;
using API.Repository.Interface;

namespace API.Repository.Data
{
    public class DetBarKeluarRepository : GeneralRepository<DetailBarkeluar, int, MyContext>, IDetBarKeluarRepository
    {
        public DetBarKeluarRepository(MyContext context) : base(context) { }
    }
}
