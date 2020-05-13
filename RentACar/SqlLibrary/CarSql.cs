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
    public class CarSql
    {
        public static List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Cars";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cars.Add(new Car(reader[0].ToString(),
                                         (Int64)reader[1],
                                         (int)reader[2],
                                         (Int64)reader[3],
                                         (int)reader[4],
                                         (int)reader[5],
                                         reader[6].ToString()));
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return cars;
        }
        public static int AddCar(Car car)
        {
            int count = 0;
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "AddCar";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@RegistrationN", string.IsNullOrEmpty(car.NRegistation) ? Convert.DBNull : car.NRegistation);
                    command.Parameters.AddWithValue("@CarOwner", string.IsNullOrEmpty(car.CarOwner.ToString()) ? Convert.DBNull : car.CarOwner);
                    command.Parameters.AddWithValue("@Model", string.IsNullOrEmpty(car.Brand.ToString()) ? Convert.DBNull : car.Brand);
                    command.Parameters.AddWithValue("@Insurance", string.IsNullOrEmpty(car.Insurance.ToString()) ? Convert.DBNull : car.Insurance);
                    command.Parameters.AddWithValue("@Mileage", car.Mileage);
                    command.Parameters.AddWithValue("@YearOfIssue", car.YaerOfIssue);
                    command.Parameters.AddWithValue("@Color", car.Color);
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static string DeleteCar(Car car)
        {
            string message;
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command=new SqlCommand())
                {
                    command.CommandText = "DeleteCar";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@RegistrationN", string.IsNullOrEmpty(car.NRegistation) ? Convert.DBNull : car.NRegistation);
                    command.Parameters.Add("@Tag", SqlDbType.Int);
                    command.Parameters["@Tag"].Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    if (Convert.ToInt32(command.Parameters["@Tag"].Value) == 0)
                        message = "Удаление невозможно из-за наличия связанных записей в подчинённой таблице";
                    else message = "Удаление прошло успешно";
                }
                connection.Close();
            }
            return message;
        }
        public static int UpdateCar(Car car)
        {
            int count = 0;
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using(SqlCommand command=new SqlCommand())
                {
                    command.CommandText = "UpdateCar";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@RegistrationN", string.IsNullOrEmpty(car.NRegistation) ? Convert.DBNull : car.NRegistation);
                    command.Parameters.AddWithValue("@CarOwnerNew", string.IsNullOrEmpty(car.CarOwner.ToString()) ? Convert.DBNull : car.CarOwner);
                    command.Parameters.AddWithValue("@ModelNew", string.IsNullOrEmpty(car.Brand.ToString()) ? Convert.DBNull : car.Brand);
                    command.Parameters.AddWithValue("@InsuranceNew", string.IsNullOrEmpty(car.Insurance.ToString()) ? Convert.DBNull : car.Insurance);
                    command.Parameters.AddWithValue("@MileageNew", car.Mileage);
                    command.Parameters.AddWithValue("@YearOfIssueNew", car.YaerOfIssue);
                    command.Parameters.AddWithValue("@ColorNew", car.Color);
                    count = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return count;
        }
        public static List<Car> GetFreeNowCars()
        {
            List<Car> freeCars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Config"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "GetFreeNowCars";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        freeCars.Add(new Car(reader[0].ToString(),
                                         (Int64)reader[1],
                                         (int)reader[2],
                                         (Int64)reader[3],
                                         (int)reader[4],
                                         (int)reader[5],
                                         reader[6].ToString()));
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return freeCars;
        }
    }
}
