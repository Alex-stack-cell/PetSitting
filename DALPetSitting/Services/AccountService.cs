using DALPetSitting.Entities;
using DALPetSitting.Infra;
using DALPetSitting.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
