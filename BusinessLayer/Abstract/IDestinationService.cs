using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService:IGenericService<Destination>
    {
        public List<Destination> TGetDestinationsWithGuide(int id);
        public List<Destination> TGetLast4Destinations();
    }
}
