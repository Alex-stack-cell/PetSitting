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
    /// Opérations DML et DDL pour l'entité Pet en BDD 
    /// </summary>
    public class PetService : IPetRepository
    {
        private string _cnnstring;
        public PetService(ConnectionString cnstr)
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
        /// Ajoute un animal dans la base de données
        /// Renvoie le nombre de lignes affectées
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Create(Pet type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Pet(ID_Owner, NickName, Type, Breed, BirthDate) VALUES(@ID_Owner, @NickName, @Type, @Breed, @BirthDate)";

                        cmd.Parameters.AddRange(new[]
                        {
                            new SqlParameter("@ID_Owner",type.ID_Owner),
                            new SqlParameter("@NickName",type.NickName),
                            new SqlParameter("@Type",type.Type),
                            new SqlParameter("@Breed",type.Breed),
                            new SqlParameter("@BirthDate",type.BirthDate),
                        });
                        sqlConnection.Open();
                        int row = (int)cmd.ExecuteNonQuery();
                        return row;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Supprimer un animal dans la base de données
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
                        cmd.CommandText = "DELETE FROM Pet WHERE ID = @ID";

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
        /// Sélectionne tout les enregistrements dans la table Pet
        /// </summary>
        /// <returns>Renvoie le nombre de lignes affectées</returns>
        public IEnumerable<Pet> GetAll()
        {
            List<Pet> list = new List<Pet>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Pet";
                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Pet()
                                {
                                    ID = (int)reader["ID"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    NickName = (string)reader["NickName"],
                                    Type = (string)reader["Type"],
                                    Breed = (string)reader["Breed"],
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
        /// Sélectionne tous les animaux appartenant à un propriétaire donné (ID_Owner)        
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Pet> GetByOwner(int id)
        {
            List<Pet> list = new List<Pet>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Pet WHERE ID_Owner = @ID_Owner";
                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID_Owner";                       
                        PId.IsNullable = false;
                        PId.SqlDbType = SqlDbType.Int;
                        PId.Value = id;

                        cmd.Parameters.Add(PId);
                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Pet() 
                                {
                                    ID = (int)reader["ID"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    NickName = (string)reader["NickName"],
                                    Type = (string)reader["Type"],
                                    Breed = (string)reader["Breed"],
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
        /// Sélectionner les info d'un animal sur base de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string NickName</returns>
        public IEnumerable<Pet> GetById(int id)
        {
            List<Pet> list = new List<Pet>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    sqlConnection.ConnectionString = this._cnnstring;
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT ID, ID_Owner, NickName, Type, Breed, BirthDate FROM Pet WHERE ID = @ID";

                        // Requête paramétrée
                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.SqlDbType = SqlDbType.Int;
                        PId.Value = id;

                        //Ajout du paramètre
                        cmd.Parameters.Add(PId);

                        sqlConnection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Pet()
                                {
                                    ID = (int)reader["ID"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    NickName = (string)reader["NickName"],
                                    Type = (string)reader["Type"],
                                    Breed = (string)reader["Breed"],
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
        /// Met à jour un animal dans la base de données
        /// sur base de son identifiant
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Renvoie le nombre de lignes affectées</returns>
        public int Update(Pet type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    sqlConnection.ConnectionString = this._cnnstring;
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Pet SET ID_Owner = @ID_Owner, NickName = @NickName, Type = @Type, Breed = @Breed, BirthDate = @BirthDate WHERE ID = @ID";


                        cmd.Parameters.AddRange(new[]
                            {
                            new SqlParameter("@ID",type.ID),
                            new SqlParameter("@ID_Owner",type.ID_Owner),
                            new SqlParameter("@NickName",type.NickName),
                            new SqlParameter("@Type",type.Type),
                            new SqlParameter("@Breed", type.Breed),
                            new SqlParameter("@BirthDate", type.BirthDate),
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
