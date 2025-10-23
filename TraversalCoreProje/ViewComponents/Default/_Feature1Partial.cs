using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Feature1Partial:ViewComponent
    {
        Feature1Manager feature1Manager = new Feature1Manager(new EfFeatureDal());

        public IViewComponentResult Invoke()
        {
            var values = feature1Manager.TGetList();
            return View(values);
        }
    }
}
