using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Entities
{
    /// <summary>
    /// Entité Advertissement en base de données
    /// </summary>
    public class Advertisement
    {
        public int? ID { get; set; }
        
        public int? ID_Owner { get; set; }
        public int? ID_Prestation { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
