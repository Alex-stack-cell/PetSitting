using DALPetSitting.Entities;
using DALPetSitting.Repository;
using System.Collections.Generic;

namespace DALPetSitting.Repositories
{
    /// <summary>
    /// Repository pour l'entité Comment
    /// </summary>
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        IEnumerable<Comment> GetCommentByScoreAsc();
        IEnumerable<Comment> GetCommentByScoreDesc();
    }
}
