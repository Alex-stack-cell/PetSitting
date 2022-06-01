using System.Collections.Generic;

namespace DALPetSitting.Repository
{
    /// <summary>
    /// Centralsiation des opérations CRUD au sein d'une interface générique
    /// </summary>
    public interface IGenericRepository <T> where T : class
    {
        /// <summary>
        /// Requête DML affichant tout les enregistrements
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll();
        /// <summary>
        /// Requête DML affichant un enregistrement
        /// à partir de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<T> GetById (int id);
        /// <summary>
        /// Requête DDL permettant d'ajouter un enregistrement
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Create(T type);
        /// <summary>
        /// Requête DDL permettant de mettre à jour
        /// une table
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Update(T type);
        /// <summary>
        /// Requête DDL permettant de supprimer 
        /// un enregitrement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id);
    }
}
