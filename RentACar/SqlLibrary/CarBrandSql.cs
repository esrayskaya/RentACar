using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Common;

namespace SqlLibrary
{
    public class CarBrandSql
    {
        public static List<CarBrand> GetAllCarBrand()
        {
            List<CarBrand> carBrands = new List<CarBrand>();
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM CarBrands";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        carBrands.Add(new CarBrand((int)reader[0], reader[1].ToString(), reader[2].ToString()));
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return carBrands;
        }
        public static int AddCarBrand(CarBrand carBrand)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "AddCarBrand";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(carBrand.Code.ToString()) ? Convert.DBNull : carBrand.Code);
                    command.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(carBrand.Name) ? Convert.DBNull : carBrand.Name);
                    command.Parameters.AddWithValue("@Model", string.IsNullOrEmpty(carBrand.Model) ? Convert.DBNull : carBrand.Model);
                    command.Connection = connection;
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static void UpdateCarBrand(CarBrand carBrand)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "UpdateCarBrand";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(carBrand.Code.ToString()) ? Convert.DBNull : carBrand.Code);
                    command.Parameters.AddWithValue("@NameNew", string.IsNullOrEmpty(carBrand.Name) ? Convert.DBNull : carBrand.Name);
                    command.Parameters.AddWithValue("@ModelNew", string.IsNullOrEmpty(carBrand.Model) ? Convert.DBNull : carBrand.Model);
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public static int DeleteCarBrand(CarBrand carBrand)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DeleteCarBrand";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(carBrand.Code.ToString()) ? Convert.DBNull : carBrand.Code);
                    command.Connection = connection;
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
    }
}
