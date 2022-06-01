using BLLPetSitting.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPetSitting.Concretes
{
    /// <summary>
    /// Comment issu de la BLL
    /// </summary>
    public sealed class Comment
    {
        private string _title;
        private string _description;
        private DateTime _createdAt;
        private int _score;

        public int? Id { get; set; }
        public int? IdPrestation { get; set; }
        public int? IdOwner { get; set; }
        public int? IdPetSitter { get; set; }
        public string Title { get { return this._title; } set { this._title = value; } }
        public string Description { get { return this._description; } set { this._description = value; } }
        public DateTime CreatedAt { get { return this._createdAt; } set { this._createdAt = value; } }
        public int Score { get { return this._score; } set { this._score = value; } }
        public bool IsOwner { get; set; }

        public Comment(int? id, string title, string description, int score, DateTime createdAt)
        {
            this.Id = id;
            this._title = title;
            this._description = description;
            this._createdAt = createdAt;
            this._score = score;

            //Validation
            ValidateTitle(title);
            ValidateComment(description, score);
            //ValidateCreatedAt(createdAt);
        }

        /// <summary>
        /// Évalue si le titre fournit est valide ou non
        /// Critère non nulle, et doit être de longueur min. de 3 caractères
        /// </summary>
        /// <param name="title"></param>
        public void ValidateTitle(string title)
        {
            if (title.Length<3)
            {
                throw new CustomException("Le titre fourni est incorrecte");
            }
        }

        /// <summary>
        /// Évalue si la description fournie est valide ou non
        /// Critère non nulle et doit être de longueur min. de 15 caractères
        /// </summary>
        /// <param name="description"></param>
        public void ValidateComment(string description, int score)
        {
            if(description.Length <15)
            {
                throw new CustomException("Votre commentaire est trop court");
            }
            else if (score < 0 || score > 5)
            {
                throw new CustomException("La note fournie est incorrecte ! (min. 0 - max. 5)");
            }
        }

        /// <summary>
        /// Évalue si la date de création du commentaire est valide ou non
        /// Critère strictement égale à la date du jour
        /// </summary>
        /// <param name="createdAt"></param>
        //public void ValidateCreatedAt(DateTime createdAt)
        //{
        //    if(createdAt != DateTime.Now)
        //    {
        //        throw new CustomException("La date de création du poste est invalide");
        //    }
        //}
    }
}
