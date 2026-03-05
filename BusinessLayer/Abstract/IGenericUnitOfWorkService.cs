namespace BusinessLayer.Abstract
{
    public interface IGenericUnitOfWorkService<T>
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TMultiUpdate(List<T> t);
        T TGetById(int id);
    }
}
