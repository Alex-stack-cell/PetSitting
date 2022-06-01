using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Infra
{
    /// <summary>
    /// Interface décrivant le comportement du UnitOfWork.
    /// Il implémente la méthode IDisposable pour pouvoir être supprimé de la mémoire au besoin
    /// ou dans le bloc d'instruction using. 
    /// Cela permet d'éviter de maintenir les connections ouvertes
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbConnection
    {
        /// <summary>
        /// Récupère la classe de base pour se connecter à la bdd
        /// </summary>
        TContext DbConnection { get; }
        
    }
}
