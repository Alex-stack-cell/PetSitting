
namespace DALPetSitting.Infra
{
    /// <summary>
    /// Classe permettant de créer une instance enregistrant 
    /// la connection string
    /// </summary>
    public class ConnectionString
    {
        public string Value { get; set; }
        public ConnectionString(string value)
        {
            this.Value = value;
        }
    }
}
