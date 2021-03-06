using DALPetSitting.Abstracts;
using DALPetSitting.Entities.Dashboards;
using DALPetSitting.Entities.Users;
using DALPetSitting.Entities.Users.Updates;
using DALPetSitting.Helpers;
using DALPetSitting.Infra;
using DALPetSitting.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DALPetSitting.Services
{
    /// <summary>
    /// Opérations DML et DDL pour l'entité PetSitter en BDD 
    /// </summary>
    public class PetSitterService : IPetSitterRepository, IDashboard<DashboardPetSitter>
    {
        private string _cnnstring;
        public PetSitterService(ConnectionString cnstr)
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
        /// Ajouter un pet-sitter dans la base de données
        /// Renvoie le nombre de lignes affectées
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Create(PetSitter type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using(SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;

                        byte[] salt = Crypto.GenerateSalt();
                        string clearPassword = type.Passwd;
                        string hashedPassword = Crypto.HashPassword(salt, clearPassword);

                        cmd.CommandText = "INSERT INTO PetSitter (LastName, FirstName, BirthDate, Email,HashPasswd, Salt, PetPreference) VALUES (@LastName, @FirstName,  @BirthDate, @Email, @HashPasswd, @Salt, @PetPreference)";

                        cmd.AddParameters(
                            new SqlParameter("LastName",type.LastName),
                            new SqlParameter("FirstName",type.FirstName),
                            new SqlParameter("BirthDate",type.BirthDate),
                            new SqlParameter("Email",type.Email),
                            new SqlParameter("HashPasswd", hashedPassword),
                            new SqlParameter("Salt", salt),
                            new SqlParameter("PetPreference",type.PetPreference)
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
        /// <summary>
        /// Supprime un pet-sitter dans la base de données
        /// sur base de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM PetSitter WHERE ID = @ID";
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
        /// Sélectionner les informations des pet-sitters
        /// </summary>
        /// <returns>Renvoie le nombre de lignes affectées</returns>
        public IEnumerable<PetSitter> GetAll()
        {
            List<PetSitter> list = new List<PetSitter>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT ID, LastName, FirstName, BirthDate, Email, PetPreference FROM PetSitter";
                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new PetSitter 
                                {
                                    ID = (int)reader["ID"],
                                    LastName = (string)reader["LastName"],
                                    FirstName = (string)reader["FirstName"],
                                    BirthDate = (DateTime)reader["BirthDate"],
                                    Email = (string)reader["Email"],
                                    //Score = reader["Score"] as int?,
                                    PetPreference = reader["PetPreference"] == DBNull.Value ? null : (string)reader["PetPreference"]
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
        /// Sélectionner les info d'un pet-sitter 
        /// sur base de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<PetSitter> GetById(int id)
        {
            List<PetSitter> list = new List<PetSitter>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        // Requête paramétrée >< Injection Sql
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT ID, LastName, FirstName, BirthDate, Email, PetPreference FROM PetSitter WHERE ID = @ID";
                        
                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.SqlDbType = SqlDbType.Int;
                        PId.Value = id;
                        // Ajout du paramètre dans la commande
                        cmd.Parameters.Add(PId);

                        sqlConnection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new PetSitter
                                {
                                    ID = (int)reader["ID"],
                                    LastName = (string)reader["LastName"],
                                    FirstName = (string)reader["FirstName"],
                                    BirthDate = (DateTime)reader["BirthDate"],
                                    Email = (string)reader["Email"],
                                    PetPreference = reader["PetPreference"] == DBNull.Value ? null : (string)reader["PetPreference"]
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
        /// Sélectionner les info d'un pet-sitter sur base de ses préférences (chien, chat, lapin)
        /// </summary>
        /// <param name="petPreference"></param>
        /// <returns></returns>
        public IEnumerable<PetSitter> GetByPreference(string petPreference)
        {
            List<PetSitter> list = new List<PetSitter>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using(SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType=CommandType.Text;
                        cmd.CommandText = "SELECT ID, LastName, FirstName, BirthDate, Email, PetPreference FROM PetSitter WHERE PetPreference = @petPreference";

                        SqlParameter PPreference = new SqlParameter();
                        PPreference.ParameterName = "petPreference";
                        PPreference.IsNullable = false;
                        PPreference.Value = petPreference;

                        cmd.Parameters.Add(PPreference);
                        sqlConnection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new PetSitter
                                {
                                    ID = (int)reader["ID"],
                                    LastName = (string)reader["LastName"],
                                    FirstName = (string)reader["FirstName"],
                                    BirthDate = (DateTime)reader["BirthDate"],
                                    Email = (string)reader["Email"],
                                    Passwd = (string)reader["Passwd"],
                                    //Score = reader["Score"] as int?,
                                    PetPreference = reader["PetPreference"] == DBNull.Value ? null : (string)reader["PetPreference"]
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
        /// Récupère les info pour le tableau de bord du petsitter
        /// </summary>
        /// <param name="petSitterId"></param>
        /// <returns></returns>
        public DashboardPetSitter GetDashboard(int petSitterId)
        {
            try
            {
                DashboardPetSitter petSitterDashboard = new DashboardPetSitter();
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM V_PetSitter WHERE Id = @ID";

                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.Value = petSitterId;

                        cmd.Parameters.Add(PId);
                        sqlConnection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                petSitterDashboard = new DashboardPetSitter()
                                {
                                    ID = (int)reader["Id"],
                                    LastName = (string)reader["LastName"],
                                    FirstName = (string)reader["FirstName"],
                                    BirthDate = (DateTime)reader["BirthDate"],
                                    Email = (string)reader["Email"],
                                    PetPreference = (string)reader["PetPreference"],
                                    Score = reader["Score"] == DBNull.Value ? null : (float)reader["Score"]
                                };
                            }                         
                        }
                        return petSitterDashboard;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Met à jour le mdp d'un pet-sitter dans la base de données 
        /// sur base de son identifiant
        /// </summary>
        /// <param name="type"></param>
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
                        cmd.CommandText = "UPDATE PetSitter SET HashPasswd = @HashPasswd, Salt = @Salt WHERE ID = @ID";

                        byte[] salt = Crypto.GenerateSalt();
                        string clearPassword = type.currentPassword;
                        string hashedPassword = Crypto.HashPassword(salt, clearPassword);

                        cmd.AddParameters(     
                           new SqlParameter("@ID",type.id),
                           new SqlParameter("@HashPasswd",hashedPassword),
                           new SqlParameter("@Salt",salt)
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
        /// <summary>
        /// Met à jour les info d'un pet sitter en bdd
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UpdateInfo(UpdatePetSitterInfo type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE PetSitter SET LastName = @LastName, FirstName = @FirstName, Email = @Email, PetPreference = @PetPreference WHERE ID = @ID";

                        cmd.AddParameters(
                            new SqlParameter("@ID", type.Id),
                            new SqlParameter("@LastName", type.LastName),
                            new SqlParameter("@FirstName", type.FirstName),
                            new SqlParameter("@Email", type.Email),
                            new SqlParameter("@PetPreference",type.PetPreference )
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

        public int Update(PetSitter type)
        {
            throw new NotImplementedException();
        }
    }
}
