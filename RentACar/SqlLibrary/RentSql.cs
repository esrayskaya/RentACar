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
    public class RentSql
    {
        public static List<Rent> GetAllRents()
        {
            List<Rent> rents = new List<Rent>();
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command=new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Rent";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        rents.Add(new Rent(reader[0].ToString(),
                                           (Int64)reader[1],
                                           (int)reader[2],
                                           DateTime.Parse(reader[3].ToString()),
                                           DateTime.Parse(reader[4].ToString()),
                                           (int)reader[5]));
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return rents;
        }
        public static int AddRent(Rent rent)
        {
            int count = 0;
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command=new SqlCommand())
                {
                    command.CommandText = "AddRent";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Car", string.IsNullOrEmpty(rent.Car) ? Convert.DBNull : rent.Car);
                    command.Parameters.AddWithValue("@Client", string.IsNullOrEmpty(rent.Client.ToString()) ? Convert.DBNull : rent.Client);
                    command.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(rent.Price.ToString()) ? Convert.DBNull : rent.Price);
                    command.Parameters.AddWithValue("@StartDate", rent.StartDate);
                    command.Parameters.AddWithValue("@EndDate", rent.EndDate);
                    command.Parameters.AddWithValue("@N", string.IsNullOrEmpty(rent.N.ToString()) ? Convert.DBNull : rent.N);
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static int UpdateRent(Rent rent)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "UpdateRent";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@CarNew", string.IsNullOrEmpty(rent.Car) ? Convert.DBNull : rent.Car);
                    command.Parameters.AddWithValue("@ClientNew", string.IsNullOrEmpty(rent.Client.ToString()) ? Convert.DBNull : rent.Client);
                    command.Parameters.AddWithValue("@PriceNew", string.IsNullOrEmpty(rent.Price.ToString()) ? Convert.DBNull : rent.Price);
                    command.Parameters.AddWithValue("@StartDateNew", rent.StartDate);
                    command.Parameters.AddWithValue("@EndDateNew", rent.EndDate);
                    command.Parameters.AddWithValue("@N", string.IsNullOrEmpty(rent.N.ToString()) ? Convert.DBNull : rent.N);
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static int DeleteRent(Rent rent)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DeleteRent";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@N", string.IsNullOrEmpty(rent.N.ToString()) ? Convert.DBNull : rent.N);
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static List<Rent> FindRent(int n)
        {
            List<Rent> rents = new List<Rent>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "FindRent";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@N", n);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        rents.Add(new Rent(reader[0].ToString(),
                                           (Int64)reader[1],
                                           (int)reader[2],
                                           DateTime.Parse(reader[3].ToString()),
                                           DateTime.Parse(reader[4].ToString()),
                                           (int)reader[5]));
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return rents;
        }
        public static void ReducePrice()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "ReducePrices";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public static void IncreasePrice()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "IncreasePrices";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
