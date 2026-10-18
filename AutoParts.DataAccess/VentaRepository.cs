using Microsoft.Data.SqlClient;
using AutoParts.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class VentaRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public VentaRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Venta> SelectAll()
        {
            List<Venta> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spVentaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Venta>();

                        while (dr.Read())
                        {
                            Venta entity = new Venta();

                            entity.VentaId = dr.GetInt32(0);
                            entity.ClienteId = dr.GetInt32(1);
                            entity.EmpleadoId = dr.GetInt32(2);
                            entity.NumeroFactura = dr.GetString(3);
                            entity.FechaVenta = dr.GetDateTime(4);
                            entity.Total = dr.GetDecimal(5);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(Venta entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spVentaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@NumeroFactura", entity.NumeroFactura);
                    cmd.Parameters.AddWithValue("@FechaVenta", entity.FechaVenta);
                    cmd.Parameters.AddWithValue("@Total", entity.Total);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}