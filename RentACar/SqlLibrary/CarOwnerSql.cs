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
    public class CarOwnerSql
    {
        public static List<CarOwner> GetAllCarOwners()
        {
            List<CarOwner> carOwners = new List<CarOwner>();
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command =new SqlCommand())
                {
                    command.CommandText = "GetAllCarOwners";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        carOwners.Add(new CarOwner((Int64)reader[0],
                                                    reader[1].ToString(),
                                                    reader[2].ToString(),
                                                    reader[3].ToString(),
                                                    (Int64)reader[4],
                                                    DateTime.Parse(reader[5].ToString()),
                                                    (int)reader[6]));
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return carOwners;
        }
        public static int AddCarOwner(CarOwner carOwner)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "AddCarOwner";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DrivenCertificate", string.IsNullOrEmpty(carOwner.DrivenCertificate.ToString()) ? Convert.DBNull : carOwner.DrivenCertificate);
                    command.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(carOwner.LastName) ? Convert.DBNull : carOwner.LastName);
                    command.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(carOwner.FirstName) ? Convert.DBNull : carOwner.FirstName);
                    command.Parameters.AddWithValue("@Patronymic", string.IsNullOrEmpty(carOwner.Patronymic) ? Convert.DBNull : carOwner.Patronymic);
                    command.Parameters.AddWithValue("@Passport", string.IsNullOrEmpty(carOwner.Passport.ToString()) ? Convert.DBNull : carOwner.Passport);
                    command.Parameters.AddWithValue("@BirthDay", string.IsNullOrEmpty(carOwner.BirtDay.ToString()) ? Convert.DBNull : carOwner.BirtDay);
                    command.Parameters.AddWithValue("@Settlements", string.IsNullOrEmpty(carOwner.CityLife.ToString()) ? Convert.DBNull : carOwner.CityLife);
                    command.Connection = connection;
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static string DeleteCarOwner(CarOwner carOwner)
        {
            string message;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DeleteCarOwner";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DrivenCertificate", string.IsNullOrEmpty(carOwner.DrivenCertificate.ToString()) ? Convert.DBNull : carOwner.DrivenCertificate);
                    command.Parameters.Add("@Tag", SqlDbType.Int);
                    command.Parameters["@Tag"].Direction = ParameterDirection.ReturnValue;
                    command.Connection = connection;
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
                }
                connection.Close();
            }
            return message;
        }
        public static int UpdateCarOwner(CarOwner carOwner)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "UpdateCarOwner";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DrivenCertificate", string.IsNullOrEmpty(carOwner.DrivenCertificate.ToString()) ? Convert.DBNull : carOwner.DrivenCertificate);
                    command.Parameters.AddWithValue("@LastNameNew", string.IsNullOrEmpty(carOwner.LastName) ? Convert.DBNull : carOwner.LastName);
                    command.Parameters.AddWithValue("@FirstNameNew", string.IsNullOrEmpty(carOwner.FirstName) ? Convert.DBNull : carOwner.FirstName);
                    command.Parameters.AddWithValue("@PatronymicNew", string.IsNullOrEmpty(carOwner.Patronymic) ? Convert.DBNull : carOwner.Patronymic);
                    command.Parameters.AddWithValue("@PassportNew", string.IsNullOrEmpty(carOwner.Passport.ToString()) ? Convert.DBNull : carOwner.Passport);
                    command.Parameters.AddWithValue("@BirthDayNew", string.IsNullOrEmpty(carOwner.BirtDay.ToString()) ? Convert.DBNull : carOwner.BirtDay);
                    command.Parameters.AddWithValue("@SettlementsNew", string.IsNullOrEmpty(carOwner.CityLife.ToString()) ? Convert.DBNull : carOwner.CityLife);
                    command.Connection = connection;
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
    }
}
