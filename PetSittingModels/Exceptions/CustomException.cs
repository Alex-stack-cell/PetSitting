using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPetSitting.Exceptions
{
    /// <summary>
    /// Gestion d'erreur : Capture une erreur dans le cas ou une personne fournit une donnée invalide
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException(string errorMsg) : base(string.Format(errorMsg))
        {

        }
    }
}
