using Microsoft.Data.SqlClient;
using AutoParts.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class EstadoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public EstadoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Estado> SelectAll()
        {
            List<Estado> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spEstadoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Estado>();

                        while (dr.Read())
                        {
                            Estado entity = new Estado();

                            entity.EstadoId = dr.GetInt32(0);
                            entity.Nombre = dr.GetString(1);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(Estado entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spEstadoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}