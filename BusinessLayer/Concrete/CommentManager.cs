using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _CommentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _CommentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
            _CommentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _CommentDal.Delete(t);
        }

        public Comment TGetById(int id)
        {
            return _CommentDal.GetById(id);
        }

        public List<Comment> TGetList()
        {
            return _CommentDal.GetList();
        }

        public void TUpdate(Comment t)
        {
            _CommentDal.Update(t);
        }

        public List<Comment> TGetDestinationByID(int id)
        {
            return _CommentDal.GetListByFilter(x => x.DestinationId == id);
        }
    }
}
