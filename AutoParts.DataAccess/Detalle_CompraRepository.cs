
using Microsoft.Data.SqlClient;
using AutoParts.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class Detalle_CompraRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public Detalle_CompraRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Detalle_Compra> SelectAll()
        {
            List<Detalle_Compra> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spDetalle_CompraSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Detalle_Compra>();

                        while (dr.Read())
                        {
                            Detalle_Compra entity = new Detalle_Compra();

                            entity.DetalleCompraId = dr.GetInt32(0);
                            entity.Cantidad = dr.GetInt32(1);
                            entity.PrecioCosto = dr.GetDecimal(2);
                            entity.Subtotal = dr.GetDecimal(3);
                            entity.CompraId = dr.GetInt32(4);
                            entity.ProductoId = dr.GetInt32(5);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(Detalle_Compra entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spDetalle_CompraInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioCosto", entity.PrecioCosto);
                    cmd.Parameters.AddWithValue("@Subtotal", entity.Subtotal);
                    cmd.Parameters.AddWithValue("@CompraId", entity.CompraId);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}
