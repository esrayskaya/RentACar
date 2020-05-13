using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Common;

namespace SqlLibrary
{
    public class InsuerenceAgencySql
    {
        public static List<InsuranceAgency> GetAllInsuerenceAgency()
        {
            List<InsuranceAgency> insuranceAgencies = new List<InsuranceAgency>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM InsuranceAgency";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        InsuranceAgency agency = new InsuranceAgency((int)reader[0], reader[1].ToString());
                        insuranceAgencies.Add(agency);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return insuranceAgencies;
        }
        public static int AddInsuerenceAgency(InsuranceAgency insuranceAgencies)
        {
            int count = 0;
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "AddIncuerenceAgency";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(insuranceAgencies.Code.ToString()) ? Convert.DBNull : insuranceAgencies.Code);
                    command.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(insuranceAgencies.Name) ? Convert.DBNull : insuranceAgencies.Name);
                    command.Connection = connection;
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static int DeleteInsuerenceAgency(InsuranceAgency insuranceAgencies)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DeleteIncuerenceAgency";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(insuranceAgencies.Code.ToString()) ? Convert.DBNull : insuranceAgencies.Code);
                    command.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(insuranceAgencies.Name) ? Convert.DBNull : insuranceAgencies.Name);
                    command.Connection = connection;
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static void UpdateInsuerenceAgency(InsuranceAgency insuranceAgencies)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "UpdateInsuranceAgency";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(insuranceAgencies.Code.ToString()) ? Convert.DBNull : insuranceAgencies.Code);
                    command.Parameters.AddWithValue("@NameNew", string.IsNullOrEmpty(insuranceAgencies.Name) ? Convert.DBNull : insuranceAgencies.Name);
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
