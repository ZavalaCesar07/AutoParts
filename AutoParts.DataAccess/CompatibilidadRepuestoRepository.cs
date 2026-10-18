using Microsoft.Data.SqlClient;
using AutoParts.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class CompatibilidadRepuestoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public CompatibilidadRepuestoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<CompatibilidadRepuesto> SelectAll()
        {
            List<CompatibilidadRepuesto> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spCompatibilidadRepuestoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<CompatibilidadRepuesto>();

                        while (dr.Read())
                        {
                            CompatibilidadRepuesto entity = new CompatibilidadRepuesto();

                            entity.CompatibilidadRepuestoId = dr.GetInt32(0);
                            entity.ProductoId = dr.GetInt32(1);
                            entity.VehiculoId = dr.GetInt32(2);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(CompatibilidadRepuesto entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spCompatibilidadRepuestoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@VehiculoId", entity.VehiculoId);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}