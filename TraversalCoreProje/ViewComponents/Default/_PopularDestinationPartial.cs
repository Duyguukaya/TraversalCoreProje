using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _PopularDestinationPartial : ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var allDestinations = destinationManager.TGetList();

            var activeDestinations = allDestinations.Where(x => x.Satus == true).ToList();

            return View(activeDestinations);
        }
    }
}