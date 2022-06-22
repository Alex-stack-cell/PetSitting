using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Repositories
{
    /// <summary>
    /// Répository pour la récupération des données de l'utilisateur a affiché dans son 
    /// tableau de bord (score compris)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDashboard<T> where T : class
    {
        public T GetDashboard(int id);
    }
}
