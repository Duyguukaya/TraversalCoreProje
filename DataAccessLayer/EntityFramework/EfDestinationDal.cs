using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public List<Destination> GetDestinationsWithGuide(int id)
        {
           using (var c = new Context())
            {
                return c.Destinations.Where(x=>x.DestinationId==id).Include(x => x.Guide).ToList();
            }
        }

        public List<Destination> GetLast4Destinations()
        {
            using (var c = new Context())
            {
               var values = c.Destinations.OrderByDescending(x => x.DestinationId).Take(4).ToList();
                return values;
            }
        }
    }
}
