using BLLPetSitting.Concretes;
using BLLPetSitting.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentDalService = DALPetSitting.Services.CommentService;

namespace BLLPetSitting.Services
{
    public class CommentService
    {
        private readonly CommentDalService _commentDalService;
        public CommentService(CommentDalService commentDalService)
        {
            _commentDalService = commentDalService;
        }
        public int Create(Comment comment)
        {
            return _commentDalService.Create(comment.ToDal());
        }
        public int Delete(int id)
        {
            return _commentDalService.Delete(id);
        }
        public IEnumerable<Comment> GetAll()
        {
            return _commentDalService.GetAll().Select(c => c.ToBll());
        }
        public IEnumerable<Comment> GetById(int id)
        {
            return _commentDalService.GetById(id).Select(c => c.ToBll());
        }
        public IEnumerable<Comment> GetCommentByScoreAsc()
        {
            return _commentDalService.GetCommentByScoreAsc().Select(c => c.ToBll());
        }
        public IEnumerable<Comment> GetCommentByScoreDesc()
        {
            return _commentDalService.GetCommentByScoreDesc().Select(c => c.ToBll());
        }
        public int Update(Comment comment)
        {
            return _commentDalService.Update(comment.ToDal());
        }
    }
}
