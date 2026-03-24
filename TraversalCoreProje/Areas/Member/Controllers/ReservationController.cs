using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueList = reservationManager.GetListWithReservationByAccepted(values.Id);
            return View(valueList);
        }


        public async Task<IActionResult> MyOldReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueList = reservationManager.GetListWithReservationByPrevious(values.Id);
            return View(valueList);
        }

        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListWithReservationByWaiyAprroval(values.Id);
            return View(valuesList);
        }


        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList() select new SelectListItem
            {
                Text = x.City,
                Value = x.DestinationId.ToString()
            }).ToList();
            ViewBag.v = values;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                p.AppUserId = user.Id;

                // Tarih Kontrolü: Girilen tarih şu anki zamandan küçük mü?
                if (p.ReservationDate < System.DateTime.Now)
                {
                    // Eğer tarih geçmişse
                    p.Status = "Geçmiş Rezervasyon"; // Veya veritabanındaki karşılığına göre "Tamamlandı"
                    reservationManager.TAdd(p);

                    // Geçmiş Rezervasyonlarım sayfasına yönlendiriyoruz
                    return RedirectToAction("MyOldReservation");
                }
                else
                {
                    // Eğer tarih gelecek bir tarihse
                    p.Status = "Onay Bekliyor";
                    reservationManager.TAdd(p);

                    // Onay Bekleyenler veya Aktif Rezervasyonlar sayfasına yönlendiriyoruz
                    return RedirectToAction("MyApprovalReservation");
                }
            }

            // Kullanıcı oturumu düşmüşse dropdown'ı tekrar doldur ve sayfaya dön
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(p);
        }
    }
}
