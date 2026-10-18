using Microsoft.Data.SqlClient;
using AutoParts.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class ReemplazoGarantiaRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public ReemplazoGarantiaRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<ReemplazoGarantia> SelectAll()
        {
            List<ReemplazoGarantia> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spReemplazoGarantiaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<ReemplazoGarantia>();

                        while (dr.Read())
                        {
                            ReemplazoGarantia entity = new ReemplazoGarantia();

                            entity.ReemplazoId = dr.GetInt32(0);
                            entity.GarantiaId = dr.GetInt32(1);
                            entity.EmpleadoId = dr.GetInt32(2);
                            entity.FechaReemplazo = dr.GetDateTime(3);
                            entity.Cantidad = dr.GetInt32(4);
                            entity.Observaciones = dr.IsDBNull(5) ? null : dr.GetString(5);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(ReemplazoGarantia entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spReemplazoGarantiaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GarantiaId", entity.GarantiaId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@FechaReemplazo", entity.FechaReemplazo);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@Observaciones", (object)entity.Observaciones ?? DBNull.Value);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}