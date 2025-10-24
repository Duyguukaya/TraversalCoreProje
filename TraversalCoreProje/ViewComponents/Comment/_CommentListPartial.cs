using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Comment
{
    public class _CommentListPartial : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            using var c = new Context();
            var values = commentManager.TGetDestinationByID(id);
            ViewBag.v1 = c.Comments.Where(x => x.DestinationId == id).Count();
            return View(values);
        }
    }
}
