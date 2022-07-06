using DALPetSitting.Infra;
using DALPetSitting.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DALPetSitting.Helpers;
using DALPetSitting.Abstracts;
using DALPetSitting.Entities.Users;
using DALPetSitting.Entities.Dashboards;
using DALPetSitting.Entities.Users.Updates;

namespace DALPetSitting.Services
{
    /// <summary>
    /// Opérations DML et DDL pour l'entité Owner en BDD 
    /// </summary>
    public class OwnerService : IOwnerRepository, IDashboard<DashboardOwner>
    {
        private string _cnnstring;
        public OwnerService(ConnectionString cnstr)
        {
            _cnnstring = cnstr.Value;
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
        /// Ajouter un propriétaire dans la base de données
        /// Renvoie le nombre de lignes affectées
        /// </summary>
        /// <param name="type">Un propriétaire issu de la BLL</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Create(Owner type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {                    
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text; 

                        byte[] salt = Crypto.GenerateSalt();
                        string clearPassword = type.Passwd;
                        string hashedPassword = Crypto.HashPassword(salt, clearPassword);

                        cmd.CommandText = "INSERT INTO Owner (LastName, FirstName, BirthDate, Email, HashPasswd, Salt) VALUES (@LastName, @FirstName, @BirthDate, @Email, @HashPasswd, @Salt)";

                        // Requêtes paramétrées >< Injection Sql
                        cmd.AddParameters(
                            new SqlParameter("@LastName",type.LastName),
                            new SqlParameter("@FirstName",type.FirstName),
                            new SqlParameter("@BirthDate",type.BirthDate),
                            new SqlParameter("@Email", type.Email),
                            new SqlParameter("@HashPasswd", hashedPassword),
                            new SqlParameter("@Salt", salt)
                        );

                        sqlConnection.Open();
                        int rows= cmd.ExecuteNonQuery();
                        return rows;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }            
        }

        /// <summary>
        /// Supprime un propriétaire dans la base de données
        /// sur base de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Renvoie le nombre de lignes affectées</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM Owner WHERE ID = @ID";
                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.SqlDbType = SqlDbType.Int;
                        PId.Value = id;
                        // Ajout du paramètre dans la commande
                        cmd.Parameters.Add(PId);

                        sqlConnection.Open();
                        int row = cmd.ExecuteNonQuery();
                        return row;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Sélectionner les informations des propriétaires
        /// </summary>
        /// <returns>Renvoie le nombre de lignes affectées</returns>
        public IEnumerable<Owner> GetAll()
        {
            List<Owner> list = new List<Owner>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {                   
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT ID, LastName, FirstName, Email, BirthDate FROM Owner";

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Owner() {
                                    ID = (int)reader["ID"],
                                    LastName = (string)reader["LastName"],
                                    FirstName = (string)reader["FirstName"],
                                    Email = (string)reader["Email"],
                                    BirthDate = (DateTime)reader["BirthDate"],
                                    //Score = reader["Score"] as int?
                                    //Score = reader["Score"] == DBNull.Value ? null : (int)reader["Score"]
                                });
                            }
                            return list;
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
        /// Sélectionner les info d'un propriétaire 
        /// sur base de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns>String LastName</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Owner> GetById(int id)
        {
            List<Owner> list = new List<Owner>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        // Requête paramétrée >< Injection Sql
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT ID, LastName, FirstName, Email, BirthDate FROM Owner WHERE ID = @ID";

                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.SqlDbType = SqlDbType.Int;
                        PId.Value = id;
                        // Ajout du paramètre dans la commande
                        cmd.Parameters.Add(PId);

                        sqlConnection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader() )
                        {
                            while (reader.Read())
                            {
                                list.Add(new Owner()
                                {
                                    ID = (int)reader["ID"],
                                    LastName = (string)reader["LastName"],
                                    FirstName = (string)reader["FirstName"],
                                    Email = (string)reader["Email"],
                                    BirthDate = (DateTime)reader["BirthDate"]
                                });
                            }
                            return list;
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
        /// Sélectionner les données de l'utilisateur pour le tableau de bord
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DashboardOwner GetDashboard(int userId)
        {
            try
            {
                DashboardOwner ownerDashboard = new DashboardOwner();
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * FROM V_Owner WHERE Id = @ID";

                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.Value = userId;
                        PId.SqlDbType = SqlDbType.Int;

                        cmd.AddParameters(PId);

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ownerDashboard = new DashboardOwner()
                                {
                                    ID = (int)reader["ID"],
                                    LastName = (string)reader["LastName"],
                                    FirstName = (string)reader["FirstName"],
                                    BirthDate = (DateTime)reader["BirthDate"],
                                    Email = (string)reader["Email"],
                                    Score = reader["Score"] == DBNull.Value ? null : (float)         reader["Score"]
                                };                                
                            }
                        }
                        return ownerDashboard;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Met à jour un propriétaire dans la base de données 
        /// sur base de son identifiant
        /// </summary>
        /// <param name="type">Un propriétaire issu de la BLL</param>
        /// <returns>Renvoie le nombre de ligne affectée</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int UpdatePassword(UpdatePassword type)
        {
            try
            {

                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Owner SET HashPasswd = @HashPasswd, Salt = @Salt WHERE ID = @ID";

                        byte[] salt = Crypto.GenerateSalt();
                        string clearPassword = type.newPassword;
                        string hashedPassword = Crypto.HashPassword(salt, clearPassword);

                        cmd.AddParameters(
                            
                            new SqlParameter("@ID",type.id),
                            new SqlParameter("@HashPasswd", hashedPassword),
                            new SqlParameter("@Salt", salt)
                        );
                        
                        sqlConnection.Open();


                        int row = cmd.ExecuteNonQuery();

                        return row;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }                    
        }

        public int UpdateOwnerInfo(UpdateOwnerInfo type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Owner SET LastName = @LastName, FirstName = @FirstName, Email = @Email WHERE ID = @ID";


                        cmd.AddParameters(

                            new SqlParameter("@ID", type.Id),
                            new SqlParameter("@LastName", type.LastName),
                            new SqlParameter("@FirstName", type.FirstName),
                            new SqlParameter("@Email", type.Email)
                        );

                        sqlConnection.Open();
                        int row = cmd.ExecuteNonQuery();

                        return row;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int Update(Owner type)
        {
            throw new NotImplementedException();
        }
    }
}
