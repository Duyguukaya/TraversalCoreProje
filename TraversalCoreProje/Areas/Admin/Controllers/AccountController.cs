using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountService.TGetById(model.SenderId);
            var valueReciver = _accountService.TGetById(model.ReciverId);

            valueSender.Balance -= model.Amount;
            valueReciver.Balance += model.Amount;

            List<Account> modifiedAccount = new List<Account>() 
            {
                valueSender,
                valueReciver
            };


            _accountService.TMultiUpdate(modifiedAccount);

            return View();
        }


    }
}
