using BLLPetSitting.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPetSitting.Concretes
{
    /// <summary>
    /// Prestation côté BLL
    /// </summary>
    public class Prestation
    {
        public int? Id { get; set; }
        public int? Id_PetSitter { get; set; }

        private DateTime _dateStart;
        private DateTime _dateEnd;

        public DateTime DateStart { get { return _dateStart; } set { _dateStart = value; } }
        public DateTime DateEnd { get { return _dateEnd; } set { _dateEnd = value;} }

        public Prestation(int? id, int? idPetSitter, DateTime dateStart, DateTime dateEnd)
        {
            this.Id = id;
            this.Id_PetSitter = idPetSitter;
            this._dateStart = dateStart;
            this._dateEnd = dateEnd;

            ValidateDate(dateStart, dateEnd);
        }
        /// <summary>
        /// Évaluation de la durée de la prestation
        /// Critère : doit être associée à l'année courante, min. 2 jours, et max 2 mois
        /// </summary>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <exception cref="CustomException"></exception>
        public void ValidateDate(DateTime dateStart, DateTime dateEnd) 
        {

            int currentYear = DateTime.Now.Year;

            if ((dateStart.DayOfYear)+2> dateEnd.DayOfYear)
            {
                throw new CustomException("La prestation doit durer minimum deux jours");
            }
            else if ((GetMonthDifference(dateStart, dateEnd)) >= 2)
            {
                throw new CustomException("La prestation ne peut pas durer plus de 2 mois");
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
