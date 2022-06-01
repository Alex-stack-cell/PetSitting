using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Entities
{
    /// <summary>
    /// Entité Pet en base de données
    /// </summary>
    public class Pet
    {
        public int? ID { get; set; }
        public int? ID_Owner { get; set; }
        public string NickName { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
