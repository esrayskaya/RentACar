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
    public class SettlementsSql
    {
        public static List<Settlement> GetAllSettlements()
        {
            List<Settlement> settlements = new List<Settlement>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Settlements";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        settlements.Add(new Settlement((int)reader[0], reader[1].ToString()));
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return settlements;
        }
        public static int AddSettlements(Settlement settlement)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "AddSettlements";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(settlement.CodeCity.ToString()) ? Convert.DBNull : settlement.CodeCity);
                    command.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(settlement.NameCity) ? Convert.DBNull : settlement.NameCity);
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static int DeleteSettlements(Settlement settlement)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DeleteSettlements";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(settlement.CodeCity.ToString()) ? Convert.DBNull : settlement.CodeCity);
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static void UpdateSettlements(Settlement settlement)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "UpdateSettlements";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(settlement.CodeCity.ToString()) ? Convert.DBNull : settlement.CodeCity);
                    command.Parameters.AddWithValue("@NameNew", string.IsNullOrEmpty(settlement.NameCity) ? Convert.DBNull : settlement.NameCity);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
