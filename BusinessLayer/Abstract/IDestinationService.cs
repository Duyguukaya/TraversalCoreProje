using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService:IGenericService<Destination>
    {
        public List<Destination> TGetDestinationsWithGuide(int id);
    }
}
