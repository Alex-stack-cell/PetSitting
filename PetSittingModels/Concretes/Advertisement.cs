using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPetSitting.Concretes
{
    /// <summary>
    /// Advertissement issu de la BLL
    /// </summary>
    public sealed class Advertisement
    {
        /// <summary>
        /// Identifiant de l'annonce
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Identifiant du propriétaire
        /// </summary>
        public int? Id_Owner { get; set; }
        /// <summary>
        /// Identifiant de la prestation
        /// </summary>
        public int? Id_Prestation { get; set; }
        /// <summary>
        /// Titre de l'annonce
        /// </summary>
        private string _title;
        /// <summary>
        /// Description de l'annonce
        /// </summary>
        private string _description;
        /// <summary>
        /// L'autheur de l'annonce 
        /// </summary>
        private Owner _author;
        /// <summary>
        /// Le lieu associé à cette annonce
        /// </summary>
        private string _region;
        private string _city;
        /// <summary>
        /// Date de début de la prestation
        /// </summary>
        private DateTime _dateStart;
        /// <summary>
        /// Date de fin de la prestation
        /// </summary>
        private DateTime _dateEnd;
        ///// <summary>
        ///// Date de création de l'annonce
        ///// </summary>
        //private DateTime _createdAt;

        public string Title { get { return _title; } set { _title = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public Owner Author { get { return _author; } set { _author = value; } } // peut-être il faudra remplacer par ID_Owner
        public string Region { get { return _region; } set { _region = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public DateTime DateStart { get { return _dateStart; } set { _dateStart = value; } }
        public DateTime DateEnd { get { return _dateEnd; } set { _dateEnd = value; } }
        //public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = value; } }
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public Advertisement(int? id, string title, string description, string region, string city, DateTime dateStart, DateTime dateEnd, DateTime createAt)
        {
            this.Id = id;
            this._title = title;
            this._description = description;
            this._region = region;
            this._city = city;
            //this._author = author;
            this.CreateAt = createAt;
            try
            {
                this._dateStart = dateStart;
                this._dateEnd = dateEnd;
                ValidateDates(_dateStart, _dateEnd);
            } 
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Méthode validant les dates sélectionnées pour la réservation
        /// L'année de publication de l'annonce doit correspondre à l'année à laquelle celle-ci a été publiée
        /// La presation doit durer au moins 2 jours et  pas plus de 2 mois
        /// </summary>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <exception cref="ArgumentException"></exception>
        private void ValidateDates(DateTime dateStart, DateTime dateEnd)
        {
            dateStart = this.DateStart;
            dateEnd = this.DateEnd;

            if(dateStart.Year != DateTime.Now.Year || dateEnd.Year!=DateTime.Now.Year)
            {
                throw new ArgumentException("L'année fournie est incorrecte.");
            }
            else if((dateStart.DayOfYear)+2 > dateEnd.DayOfYear)
            {
                throw new ArgumentException("La réservation doit durer minimum deux jours");
            }
            else if((GetMonthDifference(dateStart, dateEnd)) >= 2)
            {
                throw new ArgumentException("La réservation ne peut pas durer plus de 2 mois");
            }
        }

        /// <summary>
        /// Méthode calculant le nombre de mois séparant la date de début de la date de fin
        /// </summary>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public int GetMonthDifference(DateTime dateStart, DateTime dateEnd)
        {
            int monthsApart = 12 * (dateStart.Year - dateEnd.Year) + dateStart.Month - dateEnd.Month;
            return Math.Abs(monthsApart);
        }
    }
}
