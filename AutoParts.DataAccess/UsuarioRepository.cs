using Microsoft.Data.SqlClient;
using AutoParts.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class UsuarioRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public UsuarioRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Usuario> SelectAll()
        {
            List<Usuario> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spUsuarioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Usuario>();

                        while (dr.Read())
                        {
                            Usuario entity = new Usuario();

                            entity.UsuarioId = dr.GetInt32(0);
                            entity.EmpleadoId = dr.GetInt32(1);
                            entity.RolId = dr.GetInt32(2);
                            entity.NombreUsuario = dr.GetString(3);
                            entity.Contrasena = dr.GetString(4);
                            entity.EstadoId = dr.IsDBNull(5) ? null : dr.GetInt32(5);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(Usuario entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spUsuarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    cmd.Parameters.AddWithValue("@NombreUsuario", entity.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contrasena", entity.Contrasena);
                    cmd.Parameters.AddWithValue("@EstadoId", (object)entity.EstadoId ?? DBNull.Value);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}