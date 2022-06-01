using DALPetSitting.Entities;
using DALPetSitting.Infra;
using DALPetSitting.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DALPetSitting.Services
{
    /// <summary>
    /// Opérations DML et DDL pour l'entité Prestation en BDD 
    /// </summary>
    public class AdvertisementService : IAdvertisementRepository
    {
        private string _cnnstring;
        public AdvertisementService(ConnectionString cnstr)
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
        /// Création d'une annonce
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Create(Advertisement type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Advertisement (ID_Owner, ID_Prestation, Title, Description, CreatedAt, Region, City, DateStart, DateEnd) VALUES (@ID_Owner, @ID_Prestation, @Title, @Description, @CreatedAt, @Region, @City, @DateStart, @DateEnd)";
                        
                        // Requêtes paramétrées >< Injection Sql
                        cmd.Parameters.AddRange(new[]
                        {
                            new SqlParameter("@ID_Owner",type.ID_Owner),
                            new SqlParameter("@ID_Prestation",type.ID_Prestation),
                            new SqlParameter("@Title",type.Title),
                            new SqlParameter("@Description", type.Description),
                            new SqlParameter("@CreatedAt", type.CreatedAt),
                            new SqlParameter("@Region",type.Region),
                            new SqlParameter("@City",type.City),
                            new SqlParameter("@DateStart",type.DateStart),
                            new SqlParameter("@DateEnd",type.DateEnd),
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
        /// Supression d'une annonce sur base de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                        cmd.CommandText = "DELETE FROM Advertisement WHERE ID = @ID";

                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.SqlDbType = SqlDbType.Int;
                        PId.Value = id;

                        cmd.Parameters.Add(PId);

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
        /// Sélectionne toutes les prestations
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Advertisement> GetAll()
        {
            List<Advertisement> list = new List<Advertisement>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Advertisement";

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Advertisement 
                                { 
                                    ID = (int)reader["ID"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    ID_Prestation = (int)reader["ID_Prestation"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    Region = (string)reader["Region"],
                                    City = (string)reader["City"],
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
        /// Sélectionne les info des annonces selon leur région
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Advertisement> GetByCity(string city)
        {
            List<Advertisement> list = new List<Advertisement>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Advertisement WHERE City = @City";

                        SqlParameter PRegion = new SqlParameter();
                        PRegion.ParameterName = "City";                       
                        PRegion.IsNullable = false;
                        PRegion.Value = city;
                        PRegion.SqlDbType = SqlDbType.NVarChar;

                        cmd.Parameters.Add(PRegion);

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Advertisement
                                {
                                    ID = (int)reader["ID"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    ID_Prestation = (int)reader["ID_Prestation"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    Region = (string)reader["Region"],
                                    City = (string)reader["City"],
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
        /// Sélectionne les info d'une annonce selon leur identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Advertisement> GetById(int id)
        {
            List<Advertisement> list = new List<Advertisement>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Advertisement WHERE ID = @ID";

                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.Value = id;
                        PId.SqlDbType = SqlDbType.Int;

                        cmd.Parameters.Add(PId);

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Advertisement
                                {
                                    ID = (int)reader["ID"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    ID_Prestation = (int)reader["ID_Prestation"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    Region = (string)reader["Region"],
                                    City = (string)reader["City"],
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
        /// Sélectionne les info d'une annonce selon l'identifiant du propriétaire
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Advertisement> GetByOwner(int id)
        {
            List<Advertisement> list = new List<Advertisement>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Advertisement WHERE ID_Owner = @ID_Owner";

                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID_Owner";
                        PId.IsNullable = false;
                        PId.Value = id;
                        PId.SqlDbType = SqlDbType.Int;

                        cmd.Parameters.Add(PId);

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Advertisement
                                {
                                    ID = (int)reader["ID"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    ID_Prestation = (int)reader["ID_Prestation"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    Region = (string)reader["Region"],
                                    City = (string)reader["City"],
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
        /// Sélectionne les info d'une annonce selon leur région
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Advertisement> GetByRegion(string region)
        {
            List<Advertisement> list = new List<Advertisement>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Advertisement WHERE Region = @Region";

                        SqlParameter PRegion = new SqlParameter();
                        PRegion.ParameterName = "Region";
                        PRegion.IsNullable = false;
                        PRegion.Value = region;
                        PRegion.SqlDbType = SqlDbType.NVarChar;

                        cmd.Parameters.Add(PRegion);

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Advertisement
                                {
                                    ID = (int)reader["ID"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    ID_Prestation = (int)reader["ID_Prestation"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    Region = (string)reader["Region"],
                                    City = (string)reader["City"],
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
        /// Mis à jour d'une annonce
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Update(Advertisement type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Advertisement SET ID_Owner = @ID_Owner, ID_Prestation = @ID_Prestation, Title = @Title, Description = @Description, CreatedAt = @CreatedAt, Region = @Region, City = @City, DateStart = @DateStart, DateEnd = @DateEnd WHERE ID = @ID";                        

                        cmd.Parameters.AddRange(new[]
                        {
                        new SqlParameter("ID", type.ID),
                        new SqlParameter("ID_Owner",type.ID_Owner),
                        new SqlParameter("ID_Prestation",type.ID_Prestation),
                        new SqlParameter("Title",type.Title),
                        new SqlParameter("Description",type.Description),
                        new SqlParameter("CreatedAt",type.CreatedAt),
                        new SqlParameter("Region",type.Region),
                        new SqlParameter("City",type.City),
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
