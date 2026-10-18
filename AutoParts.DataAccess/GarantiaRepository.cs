using Microsoft.Data.SqlClient;
using AutoParts.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class GarantiaRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public GarantiaRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Garantia> SelectAll()
        {
            List<Garantia> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spGarantiaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Garantia>();

                        while (dr.Read())
                        {
                            Garantia entity = new Garantia();

                            entity.GarantiaId = dr.GetInt32(0);
                            entity.DetalleVentaId = dr.GetInt32(1);
                            entity.EmpleadoId = dr.GetInt32(2);
                            entity.FechaSolicitud = dr.GetDateTime(3);
                            entity.CantidadReclamada = dr.GetInt32(4);
                            entity.DescripcionFalla = dr.GetString(5);
                            entity.ResultadoEvaluacion = dr.IsDBNull(6) ? null : dr.GetString(6);
                            entity.FechaResolucion = dr.IsDBNull(7) ? (DateTime?)null : dr.GetDateTime(7);
                            entity.Observaciones = dr.IsDBNull(8) ? null : dr.GetString(8);
                            entity.EstadoId = dr.GetInt32(9);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(Garantia entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spGarantiaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DetalleVentaId", entity.DetalleVentaId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@FechaSolicitud", entity.FechaSolicitud);
                    cmd.Parameters.AddWithValue("@CantidadReclamada", entity.CantidadReclamada);
                    cmd.Parameters.AddWithValue("@DescripcionFalla", entity.DescripcionFalla);
                    cmd.Parameters.AddWithValue("@ResultadoEvaluacion", (object)entity.ResultadoEvaluacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaResolucion", (object)entity.FechaResolucion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Observaciones", (object)entity.Observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}