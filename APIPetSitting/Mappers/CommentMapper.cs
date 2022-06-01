using CommentApi = APIPetSitting.Models.Comment;
using CommentBll = BLLPetSitting.Concretes.Comment;

namespace APIPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'API/BLL Comment
    /// </summary>
    public static class CommentMapper
    {
        /// <summary>
        /// Correspondance de Comment de la BLL vers Comment dans l'API
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static CommentApi ToApi(this CommentBll Bll)
        {
            return new CommentApi
            {
                ID = Bll.Id,
                ID_Prestation = Bll.IdPrestation,
                ID_Owner = Bll.IdOwner,
                ID_PetSitter = Bll.IdPetSitter,
                Title = Bll.Title,
                Description = Bll.Description,
                CreatedAt = Bll.CreatedAt,
                Score = Bll.Score,
                IsOwner = Bll.IsOwner
            };
        }
        /// <summary>
        /// Correspondance de Comment dans l'API de la BLL vers Comment de la BLL
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static CommentBll ToBll(this CommentApi Api)
        {
            CommentBll comment = new CommentBll(Api.ID, Api.Title, Api.Description, Api.Score, Api.CreatedAt);
            comment.IdPrestation = Api.ID_Prestation;
            comment.IdOwner = Api.ID_Owner;
            comment.IdPetSitter = Api.ID_PetSitter;
            comment.IsOwner = Api.IsOwner;

            return comment;
        }
    }
}
