using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public AccountManager(IUnitOfWorkDal unitOfWorkDal, IAccountDal accountDal)
        {
            _unitOfWorkDal = unitOfWorkDal;
            _accountDal = accountDal;
        }

        public Account TGetById(int id)
        {
           return _accountDal.GetById(id);
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _unitOfWorkDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _unitOfWorkDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _unitOfWorkDal.Save();
        }
    }
}
