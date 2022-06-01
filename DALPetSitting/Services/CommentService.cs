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
    /// <summary>
    /// Opérations DML et DDL pour l'entité Comment en BDD 
    /// </summary>
    public class CommentService : ICommentRepository
    {
        private string _cnnstring;
        public CommentService(ConnectionString cnstr)
        {
            this._cnnstring = cnstr.Value;
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(this._cnnstring);
        }
        /// <summary>
        /// Ajouté un commentaire en base de données
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Create(Comment type)
        {
            using (SqlConnection sqlConnection = CreateConnection())
            {
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Comment (ID_Prestation, ID_Owner, ID_PetSitter, Title, Description, CreatedAt, Score) VALUES (@ID_Prestation, @ID_Owner, @ID_PetSitter, @Title, @Description, @CreatedAt, @Score)";

                    cmd.Parameters.AddRange(new[]
                        {
                            new SqlParameter("ID_Prestation",type.ID_Prestation),
                            new SqlParameter("ID_Owner",type.ID_Owner),
                            new SqlParameter("ID_PetSitter",type.ID_PetSitter),
                            new SqlParameter("Title",type.Title),
                            new SqlParameter("Description",type.Description),
                            new SqlParameter("CreatedAt",type.CreatedAt),
                            new SqlParameter("Score",type.Score),
                        });

                    sqlConnection.Open();
                    int row = cmd.ExecuteNonQuery();

                    return row;
                }
            }
        }
        /// <summary>
        /// Supprimer un commentaire en base de données
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
                        cmd.CommandText = "DELETE FROM Comment WHERE ID = @ID";

                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.SqlDbType = SqlDbType.Int;
                        PId.Value = id;

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
        /// Sélectionne toutes les informations des commentaires 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Comment> GetAll()
        {
            List<Comment> list = new List<Comment>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Comment";

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Comment 
                                {
                                    ID = (int)reader["ID"],
                                    ID_Prestation = (int)reader["ID_Prestation"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    ID_PetSitter= (int)reader["ID_PetSitter"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    Score = (int)reader["Score"],
                                    IsOwner = (bool)reader["isOwner"]
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
        /// Sélectionne toutes les info d'un commentaire sur base de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Comment> GetById(int id)
        {
            List<Comment> list = new List<Comment>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {                    
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Comment WHERE ID = @ID";

                        SqlParameter PId = new SqlParameter();
                        PId.ParameterName = "ID";
                        PId.IsNullable = false;
                        PId.SqlDbType = SqlDbType.Int;
                        PId.Value = id;

                        cmd.Parameters.Add(PId);

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Comment
                                {
                                    ID = (int)reader["ID"],
                                    ID_Prestation = (int)reader["ID_Prestation"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    ID_PetSitter = (int)reader["ID_PetSitter"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    Score = (int)reader["Score"],
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
        /// Renvoie la liste des commentaires par ordre croissant des scores 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Comment> GetCommentByScoreAsc()
        {
            List<Comment> list = new List<Comment>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Comment ORDER BY Score ASC";

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Comment
                                {
                                    ID = (int)reader["ID"],
                                    ID_Prestation = (int)reader["ID_Prestation"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    ID_PetSitter = (int)reader["ID_PetSitter"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    Score = (int)reader["Score"]
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
        /// Renvoie la liste des commentaires par ordre décroissant des scores 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Comment> GetCommentByScoreDesc()
        {
            List<Comment> list = new List<Comment>();
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {                    
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Comment ORDER BY Score DESC";

                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Comment
                                {
                                    ID = (int)reader["ID"],
                                    ID_Prestation = (int)reader["ID_Prestation"],
                                    ID_Owner = (int)reader["ID_Owner"],
                                    ID_PetSitter = (int)reader["ID_PetSitter"],
                                    Title = (string)reader["Title"],
                                    Description = (string)reader["Description"],
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    Score = (int)reader["Score"]
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
        /// Mettre à jour un commentaire en base de données
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Update(Comment type)
        {
            try
            {
                using (SqlConnection sqlConnection = CreateConnection())
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Comment SET ID_Prestation = @ID_Prestation, ID_Owner = @ID_Owner, ID_PetSitter = @ID_PetSitter, Title = @Title, Description = @Description, CreatedAt = @CreatedAt, Score = @Score WHERE ID = @ID";


                        cmd.Parameters.AddRange(new[] 
                        {
                            new SqlParameter("ID", type.ID),
                            new SqlParameter("ID_Prestation",type.ID_Prestation),
                            new SqlParameter("ID_Owner",type.ID_Owner),
                            new SqlParameter("ID_PetSitter",type.ID_PetSitter),
                            new SqlParameter("Title",type.Title),
                            new SqlParameter("Description",type.Description),
                            new SqlParameter("CreatedAt",type.CreatedAt),
                            new SqlParameter("Score",type.Score),
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
