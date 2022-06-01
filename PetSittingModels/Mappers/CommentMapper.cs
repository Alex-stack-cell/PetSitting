using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentBll = BLLPetSitting.Concretes.Comment;
using CommentEntity = DALPetSitting.Entities.Comment;

namespace BLLPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'entité/Modèle Comment
    /// L'entité = DB
    /// Modèle = BLL
    /// </summary>
    public static class CommentMapper
    {
        /// <summary>
        /// Correspondance de Comment de la DAL vers la BLL
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public static CommentBll ToBll(this CommentEntity Entity)
        {
            CommentBll Comment =  new CommentBll(Entity.ID, Entity.Title, Entity.Description, Entity.Score, Entity.CreatedAt);

            Comment.IdPrestation = Entity.ID_Prestation;
            Comment.IdOwner = Entity.ID_Owner;
            Comment.IdPetSitter = Entity.ID_PetSitter;

            return Comment;
        }
        /// <summary>
        /// Correspondance du Comment de la BLL vers la DAL
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static CommentEntity ToDal(this CommentBll Model)
        {
            return new CommentEntity()
            {
                ID = (int)Model.Id,
                ID_Prestation = (int)Model.IdPrestation,
                ID_Owner = (int)Model.IdOwner,
                ID_PetSitter = (int)Model.IdPetSitter,
                Title = Model.Title,
                Description = Model.Description,
                CreatedAt = Model.CreatedAt,
                Score = Model.Score,
            };
        }
    }
}
