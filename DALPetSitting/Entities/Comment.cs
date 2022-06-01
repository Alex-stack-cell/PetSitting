using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Entities
{
    /// <summary>
    /// Entité Comment en base de données
    /// </summary>
    public class Comment
    {
        public int? ID { get; set; }
        public int? ID_Prestation { get; set; }
        public int? ID_Owner { get; set; }
        public int? ID_PetSitter { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Score { get; set; }
    }
}
