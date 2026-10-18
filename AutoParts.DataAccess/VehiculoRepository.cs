using Microsoft.Data.SqlClient;
using AutoParts.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace AutoParts.DataAccess
{
    public class VehiculoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public VehiculoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Vehiculo> SelectAll()
        {
            List<Vehiculo> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spVehiculoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Vehiculo>();

                        while (dr.Read())
                        {
                            Vehiculo entity = new Vehiculo();

                            entity.VehiculoId = dr.GetInt32(0);
                            entity.Anio = dr.GetString(1);
                            entity.Cilindrada = dr.GetString(2);
                            entity.TipoMotor = dr.GetString(3);
                            entity.ModeloId = dr.GetInt32(4);

                            result.Add(entity);
                        }
                    }
                }
            }

            return result;
        }

        public int Insert(Vehiculo entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spVehiculoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Anio", entity.Anio);
                    cmd.Parameters.AddWithValue("@Cilindrada", entity.Cilindrada);
                    cmd.Parameters.AddWithValue("@TipoMotor", entity.TipoMotor);
                    cmd.Parameters.AddWithValue("@ModeloId", entity.ModeloId);

                    conn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }
    }
}