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
    public class InsueranceSql
    {
        public static List<Insurance> GettAllInsurances()
        {
            List<Insurance> insurances = new List<Insurance>();
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Incurence";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        insurances.Add(new Insurance((Int64)reader[0],
                                                     (int)reader[1],
                                                     (Decimal)reader[2],
                                                     DateTime.Parse(reader[3].ToString()),
                                                     DateTime.Parse(reader[4].ToString()),
                                                     (Int64)reader[5]));
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return insurances;
        }
        public static int AddInsurance(Insurance insurance)
        {
            int count = 0;
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "AddIncurence";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@CarOwner", string.IsNullOrEmpty(insurance.CarOwner.ToString()) ? Convert.DBNull : insurance.CarOwner);
                    command.Parameters.AddWithValue("@InsuranceAgency", string.IsNullOrEmpty(insurance.InsuranceAgency.ToString()) ? Convert.DBNull : insurance.InsuranceAgency);
                    command.Parameters.Add("@Prise", SqlDbType.Money).Value = insurance.Price;
                    command.Parameters.AddWithValue("@StartDate", string.IsNullOrEmpty(insurance.StartDate.ToString()) ? Convert.DBNull : insurance.StartDate);
                    command.Parameters.AddWithValue("@EndDate", string.IsNullOrEmpty(insurance.EndDate.ToString()) ? Convert.DBNull : insurance.EndDate);
                    command.Parameters.AddWithValue("@N", string.IsNullOrEmpty(insurance.Number.ToString()) ? Convert.DBNull : insurance.Number);
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static int UpdateInsurance(Insurance insurance)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "UpdateIncurence";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@CarOwner", string.IsNullOrEmpty(insurance.CarOwner.ToString()) ? Convert.DBNull : insurance.CarOwner);
                    command.Parameters.AddWithValue("@InsuranceAgencyNew", string.IsNullOrEmpty(insurance.InsuranceAgency.ToString()) ? Convert.DBNull : insurance.InsuranceAgency);
                    command.Parameters.Add("@PriseNew", SqlDbType.Money).Value = insurance.Price;
                    command.Parameters.AddWithValue("@StartDateNew", string.IsNullOrEmpty(insurance.StartDate.ToString()) ? Convert.DBNull : insurance.StartDate);
                    command.Parameters.AddWithValue("@EndDateNew", string.IsNullOrEmpty(insurance.EndDate.ToString()) ? Convert.DBNull : insurance.EndDate);
                    command.Parameters.AddWithValue("@N", string.IsNullOrEmpty(insurance.Number.ToString()) ? Convert.DBNull : insurance.Number);
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static string DeleteInsurance(Insurance insurance)
        {
            string message;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DeleteIncurence";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@N", string.IsNullOrEmpty(insurance.Number.ToString()) ? Convert.DBNull : insurance.Number);
                    command.Parameters.Add("@Tag", SqlDbType.BigInt);
                    command.Parameters["@Tag"].Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    switch (Convert.ToInt32(command.Parameters["@Tag"].Value))
                    {
                        case 0:
                            message = "Удаление невозможно из-за наличия связанных записей в подчинённой таблице";
                            break;
                        case 1:
                            message = "Удаление прошло успешно";
                            break;
                        default:
                            message = "Прочее сообщение";
                            break;
                    }
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return message;
        }
    }
}
