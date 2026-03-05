using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfAccountDal : GenericUnitOfWorkRepository<Account>, IAccountDal
    {
        public EfAccountDal(Context context) : base(context)
        {
        }
    }
}
