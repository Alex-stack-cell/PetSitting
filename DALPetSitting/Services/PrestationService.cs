using DALPetSitting.Entities;
using DALPetSitting.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DALPetSitting.Infra;

namespace DALPetSitting.Services
{
    /// <summary>
    /// Opérations DML et DDL pour l'entité Prestation en BDD 
    /// </summary>
    public class PrestationService : IPrestationRepository
    {
        private string _cnnstring;
        public PrestationService(ConnectionString cnstr)
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
        /// Ajouter une prestation dans la base de données
        /// Renvoie le nombre de lignes affectées
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Create(Prestation type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Prestation (ID_PetSitter, DateStart, DateEnd) VALUES (@ID_PetSitter, @DateStart, @DateEnd)";

                        // Requêtes paramétrées >< Injection Sql
                        cmd.Parameters.AddRange(new[]
                        {
                            new SqlParameter("@ID_PetSitter",type.ID_PetSitter),
                            new SqlParameter("@DateStart",type.DateStart),
                            new SqlParameter("@DateEnd",type.DateEnd)
                        });

                        sqlConnection.Open();
                        int rows = cmd.ExecuteNonQuery();
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
        /// Supprime une prestation dans la base de données
        /// Renvoie le nombre de lignes affectées
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
                        cmd.CommandText = "DELETE FROM Prestation WHERE ID = @ID";
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
        /// Sélectionne les info. du prestation
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Prestation> GetAll()
        {
            List<Prestation> list = new List<Prestation>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Prestation";

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Prestation
                                {
                                    ID = (int)reader["ID"],
                                    ID_PetSitter = (int)reader["ID_PetSitter"],
                                    DateStart = (DateTime)reader["DateStart"],
                                    DateEnd = (DateTime)reader["DateEnd"]
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
        /// Sélectionne les info. d'une prestation sur base de son identifiant unique
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Prestation> GetById(int id)
        {
            List<Prestation> list = new List<Prestation>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    sqlConnection.ConnectionString = this._cnnstring;
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Prestation WHERE ID = @ID";

                        // Requête préparée >< Injection Sql
                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.Value = id;

                        // Ajout du paramètre
                        cmd.Parameters.Add(PId);

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Prestation 
                                { 
                                    ID = (int)reader["ID"],
                                    ID_PetSitter = (int)reader["ID_PetSitter"],
                                    DateStart = (DateTime)reader["DateStart"],
                                    DateEnd = (DateTime)reader["DateEnd"],
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
        /// Met à jour une prestation dans la base de données
        /// Renvoie le nombre de lignes affectées
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Update(Prestation type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Prestation SET ID_PetSitter = @ID_PetSitter, DateStart = @DateStart, DateEnd = @DateEnd WHERE ID = @ID";


                        cmd.Parameters.AddRange(new[]
                        {
                            new SqlParameter("ID",type.ID),
                            new SqlParameter("ID_PetSitter",type.ID_PetSitter),
                            new SqlParameter("DateStart",type.DateStart),
                            new SqlParameter("DateEnd",type.DateEnd),
                        });

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
    }
}
