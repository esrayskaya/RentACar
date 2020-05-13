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
    public class ClientSql
    {
        public static List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "GetAllClients";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        clients.Add(new Client((Int64)reader[0], reader[1].ToString(),
                                                reader[2].ToString(), reader[3].ToString(),
                                                (Int64)reader[4], DateTime.Parse(reader[5].ToString()),
                                                (int)reader[6], (int)reader[7]));
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return clients;
        }
        public static int AddClient(Client client)
        {
            int count = 0;
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command=new SqlCommand())
                {
                    command.CommandText = "AddClients";
                    command.CommandType = CommandType.StoredProcedure;                    
                    command.Parameters.AddWithValue("@DrivenCertificate", string.IsNullOrEmpty(client.DrivenCertificate.ToString())?Convert.DBNull:client.DrivenCertificate);
                    command.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(client.LastName) ? Convert.DBNull : client.LastName);
                    command.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(client.FirstName) ? Convert.DBNull : client.FirstName);
                    command.Parameters.AddWithValue("@Patronymic", string.IsNullOrEmpty(client.Patronymic) ? Convert.DBNull : client.Patronymic);
                    command.Parameters.AddWithValue("@Passport", string.IsNullOrEmpty(client.Passport.ToString()) ? Convert.DBNull : client.Passport);
                    command.Parameters.AddWithValue("@BirthDay", string.IsNullOrEmpty(client.BirtDay.ToString()) ? Convert.DBNull : client.BirtDay);
                    command.Parameters.AddWithValue("@Settlements", string.IsNullOrEmpty(client.CityLife.ToString()) ? Convert.DBNull : client.CityLife);
                    command.Parameters.AddWithValue("@TownRent", string.IsNullOrEmpty(client.CityRent.ToString()) ? Convert.DBNull : client.CityRent);
                    command.Connection = connection;
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static int DeleteClient(Client client)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DeleteClients";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DrivenCertificate", string.IsNullOrEmpty(client.DrivenCertificate.ToString()) ? Convert.DBNull : client.DrivenCertificate);
                    command.Connection = connection;
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static int UpdateClient(Client client)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "UpdateClients";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DrivenCertificate", string.IsNullOrEmpty(client.DrivenCertificate.ToString()) ? Convert.DBNull : client.DrivenCertificate);
                    command.Parameters.AddWithValue("@LastNameNew", string.IsNullOrEmpty(client.LastName) ? Convert.DBNull : client.LastName);
                    command.Parameters.AddWithValue("@FirstNameNew", string.IsNullOrEmpty(client.FirstName) ? Convert.DBNull : client.FirstName);
                    command.Parameters.AddWithValue("@PatronymicNew", string.IsNullOrEmpty(client.Patronymic) ? Convert.DBNull : client.Patronymic);
                    command.Parameters.AddWithValue("@PassportNew", string.IsNullOrEmpty(client.Passport.ToString()) ? Convert.DBNull : client.Passport);
                    command.Parameters.AddWithValue("@BirthDayNew", string.IsNullOrEmpty(client.BirtDay.ToString()) ? Convert.DBNull : client.BirtDay);
                    command.Parameters.AddWithValue("@SettlementsNew", string.IsNullOrEmpty(client.CityLife.ToString()) ? Convert.DBNull : client.CityLife);
                    command.Parameters.AddWithValue("@TownRentNew", string.IsNullOrEmpty(client.CityRent.ToString()) ? Convert.DBNull : client.CityRent);
                    command.Connection = connection;
                    count=command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
    }
}
