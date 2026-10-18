
using Microsoft.Data.SqlClient;
using AutoParts.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class InventarioRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public InventarioRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Inventario> SelectAll()
        {
            List<Inventario> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spInventarioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Inventario>();

                        while (dr.Read())
                        {
                            Inventario entity = new Inventario();

                            entity.InventarioId = dr.GetInt32(0);
                            entity.StockActual = dr.GetInt32(1);
                            entity.StockMinimo = dr.GetInt32(2);
                            entity.StockMaximo = dr.GetInt32(3);
                            entity.ProductoId = dr.GetInt32(4);
                            entity.EstadoId = dr.GetInt32(5);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(Inventario entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spInventarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StockActual", entity.StockActual);
                    cmd.Parameters.AddWithValue("@StockMinimo", entity.StockMinimo);
                    cmd.Parameters.AddWithValue("@StockMaximo", entity.StockMaximo);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}
