using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IGuideService:IGenericService<Guide>
    {
        void TChangeToTrueByGuide(int id);
        void TChangeToFalseByGuide(int id);
    }
}
