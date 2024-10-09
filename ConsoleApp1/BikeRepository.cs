using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BikeRepository

    {
        private string connectionString = "Server=DESKTOP-ISB4679;Database=BikeRentalManagement;Trusted_Connection=True"; 

        public void CreateBike(Bike bike)
        {
            string query = "INSERT INTO BikesData (Brand, Model, RentalPrice) VALUES (@Brand, @Model, @RentalPrice)";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Brand", CapitalizeBrand(bike.Brand));
                    command.Parameters.AddWithValue("@Model", bike.Model);
                    command.Parameters.AddWithValue("@RentalPrice", bike.RentalPrice);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Bike Added Succefully");
                }
            }
        }

        public List<Bike> ReadBikes()
        {
            List<Bike> bikes = new List<Bike>();
            string query = "SELECT * FROM BikesData";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bikes.Add(new Bike(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDecimal(3)
                            ));
                        }
                    }
                }
            }
            return bikes;
        }

        public void UpdateBike(int bikeId, Bike bike)
        {
            string query = "UPDATE BikesData SET Brand = @Brand, Model = @Model, RentalPrice = @RentalPrice WHERE BikeId = @BikeId";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BikeId", bikeId);
                    command.Parameters.AddWithValue("@Brand", bike.Brand);
                    command.Parameters.AddWithValue("@Model", bike.Model);
                    command.Parameters.AddWithValue("@RentalPrice", bike.RentalPrice);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Bike Update Succefully");
                }
            }
        }

        public void DeleteBike(int bikeId)
        {
            string query = "DELETE FROM BikesData WHERE BikeId = @BikeId";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BikeId", bikeId);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Bike Deleted Succefully");
                }
            }
        }

        public string CapitalizeBrand(string brand)
        {
            // Capitalize the first letter of each word
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(brand.ToLower());
        }
    }
}
