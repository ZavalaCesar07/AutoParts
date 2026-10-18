using Microsoft.Data.SqlClient;
using AutoParts.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class Detalle_VentaRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public Detalle_VentaRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Detalle_Venta> SelectAll()
        {
            List<Detalle_Venta> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spDetalle_VentaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Detalle_Venta>();

                        while (dr.Read())
                        {
                            Detalle_Venta entity = new Detalle_Venta();

                            entity.DetalleVentaId = dr.GetInt32(0);
                            entity.VentaId = dr.GetInt32(1);
                            entity.ProductoId = dr.GetInt32(2);
                            entity.Cantidad = dr.GetInt32(3);
                            entity.PrecioUnitario = dr.GetDecimal(4);
                            entity.Descuento = dr.GetDecimal(5);
                            entity.SubTotal = dr.GetDecimal(6);
                            entity.DiasGarantiaVenta = dr.GetInt32(7);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(Detalle_Venta entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spDetalle_VentaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@VentaId", entity.VentaId);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", entity.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Descuento", entity.Descuento);
                    cmd.Parameters.AddWithValue("@SubTotal", entity.SubTotal);
                    cmd.Parameters.AddWithValue("@DiasGarantiaVenta", entity.DiasGarantiaVenta);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}