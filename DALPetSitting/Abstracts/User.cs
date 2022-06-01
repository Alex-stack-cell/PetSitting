﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Abstracts
{
    /// <summary>
    /// Représente une entité utilisateur
    /// et définit l'ensemble de ses propriétés
    /// Classe non instanciable
    /// </summary>
    public abstract class User
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }       
        public string Passwd { get; set; }
        public int Score { get; set; }
    }
}