
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetList();
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
    }
}
