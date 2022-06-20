using DALPetSitting.Entities;
using DALPetSitting.Infra;
using DALPetSitting.Repositories;
using System.Data;
using System.Data.SqlClient;
using DALPetSitting.Helpers;

namespace DALPetSitting.Services
{
    public class AccountService : IAccount
    {
        private string _cnnstring;
        public AccountService(ConnectionString cnstr)
        {
            this._cnnstring = cnstr.Value;
        }
        /// <summary>
        /// Méthode permettant de se connecter à la base de données
        /// sur base de la connection string fournie
        /// </summary>
        /// <returns>Instance DbConnection</returns>
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_cnnstring);
        }
        /// <summary>
        /// Sélectionne les emails des owners
        /// </summary>
        /// <returns></returns>
        public string GetEmailOwner(string emailToVerify)
        {
            try
            {

                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select Email FROM Owner WHERE Email  = @Email";
                        SqlParameter PEmail = new SqlParameter();
                        PEmail.ParameterName = "Email";
                        PEmail.IsNullable = false;
                        PEmail.Value = emailToVerify;

                        cmd.Parameters.Add(PEmail);

                        sqlConnection.Open();
                        
                        string emailOwner = (string)cmd.ExecuteScalar();
                        return emailOwner;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Sélectionnes les emails des pet-sitters
        /// </summary>
        /// <returns></returns>
        public string GetEmailPetSitter(string emailToVerify)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select Email FROM PetSitter WHERE Email = @Email";

                        SqlParameter PEmail = new SqlParameter();
                        PEmail.ParameterName = "Email";
                        PEmail.IsNullable = false;
                        PEmail.Value = emailToVerify;

                        cmd.Parameters.Add(PEmail);

                        sqlConnection.Open();

                        string emailOwner = (string)cmd.ExecuteScalar();
                        return emailOwner;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Authentifie le mdp du owner
        /// </summary>
        /// <param name="ownerEmail"></param>
        /// <param name="passwdToVerify"></param>
        /// <returns></returns>
        public bool isOwnerPasswordValid(string ownerEmail, string passwdToVerify)
        {
            try
            {
                Account accountToVerify = new Account();
                byte[] salt;
                string hashedPasswordToVerify;
                string expectedHashedPassword;

                bool isPasswordValid = false;

                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        SqlParameter PEmail = new SqlParameter();

                        PEmail.ParameterName = "Email";
                        PEmail.IsNullable = false;
                        PEmail.Value = ownerEmail;

                        cmd.AddParameters(PEmail);
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT HashPasswd, Salt FROM Owner WHERE Email = @Email";
                        

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                accountToVerify = new Account()
                                {
                                    HashPasswd = (string)reader["HashPasswd"],
                                    Salt = (byte[])reader["Salt"],
                                };
                            }

                            salt = accountToVerify.Salt;
                            expectedHashedPassword = accountToVerify.HashPasswd;
                            hashedPasswordToVerify = Crypto.HashPassword(salt, passwdToVerify);
                            // si le mdp fournit en claire une fois haché match avec celui en db => Ok
                            if(expectedHashedPassword == hashedPasswordToVerify)
                            {
                                isPasswordValid = true;
                            }
                            return isPasswordValid;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Authentifie le mdp du petSitter
        /// </summary>
        /// <param name="sitterEmail"></param>
        /// <param name="passwdToVerify"></param>
        /// <returns></returns>
        public bool isPetSitterPasswordValid(string sitterEmail, string passwdToVerify)
        {            
            try
            {
                Account accountToVerify = new Account();
                byte[] salt;
                string hashedPasswordToVerify;
                string expectedHashedPassword;
                bool isPasswordValid = false;

                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {                                          
                        SqlParameter PEmail = new SqlParameter();
                        PEmail.ParameterName = "Email";
                        PEmail.IsNullable = false;
                        PEmail.Value = sitterEmail;

                        cmd.AddParameters(PEmail);

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT HashPasswd, Salt FROM PetSitter WHERE Email = @Email";

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                accountToVerify = new Account()
                                {
                                    HashPasswd = (string)reader["HashPasswd"],
                                    Salt = (byte[])reader["Salt"]
                                };
                            }
                            expectedHashedPassword = accountToVerify.HashPasswd;
                            salt = accountToVerify.Salt;
                            hashedPasswordToVerify = Crypto.HashPassword(salt,passwdToVerify);

                            if(expectedHashedPassword == hashedPasswordToVerify)
                            {
                                isPasswordValid = true;
                            }

                            return isPasswordValid;
                        }
                    }
                }                
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Récupère les info du proprio. nécessaire pour les claims (Token)
        /// </summary>
        /// <param name="credentialToVerify"></param>
        /// <returns></returns>
        public Account GetOwnerCredentials(string credentialToVerify)
        {
            try
            {
                Account ownerAccount = new Account();
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT ID, FirstName, Email FROM Owner WHERE Email = @Email";

                        SqlParameter PEmail = new SqlParameter();
                        PEmail.ParameterName = "Email";
                        PEmail.IsNullable = false;
                        PEmail.Value = credentialToVerify;
                        cmd.AddParameters(PEmail);

                        sqlConnection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ownerAccount = (new Account
                                {
                                    ID = (int)reader["ID"],
                                    FirstName = (string)reader["FirstName"],
                                    Email = (string)reader["Email"],
                                }) ; 
                            }
                            return ownerAccount;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Récupère les info du sitter. nécessaire pour les claims (Token)
        /// </summary>
        /// <param name="credentialToVerify"></param>
        /// <returns></returns>

        public Account GetPetSitterCredentials(string credentialToVerify)
        {
            try
            {
                Account petSitterAccount = new Account();
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT ID, FirstName, Email FROM PetSitter WHERE Email = @Email";

                        SqlParameter PEmail = new SqlParameter();
                        PEmail.ParameterName = "Email";
                        PEmail.IsNullable = false;
                        PEmail.Value = credentialToVerify;
                        cmd.AddParameters(PEmail);

                        sqlConnection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                petSitterAccount = (new Account
                                {
                                    ID = (int)reader["ID"],
                                    FirstName = (string)reader["FirstName"],
                                    Email = (string)reader["Email"],
                                });
                            }
                            return petSitterAccount;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
