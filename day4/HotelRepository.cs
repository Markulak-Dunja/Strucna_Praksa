using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Hotels.Repository.Common;
using Hotels.Model;

namespace Hotels.Repository
{
    public class HotelRepository : IHotelRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hotels;Integrated Security=True";
        List<Hotel> AllHotells = new List<Hotel>();

        public List<Hotel> GetAllHotels()
        {

            string sqlString = "SELECT* FROM Hotel;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(sqlString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    AllHotells.Add(new Hotel(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), Convert.ToInt32(reader[5]), reader[6].ToString(), reader[7].ToString(), Convert.ToDecimal(reader[8])));
                }

                reader.Close();
            }
            return AllHotells;
        }


        public bool NewGuest(Guest guest)
        {
            string sqlString =
            "INSERT INTO Guest VALUES (@GuestId ,@FirstName,@LastName ,@Birthday,@FullAddress,@Phone);";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlString, connection))
                {
                    command.Parameters.AddWithValue("@GuestId", guest.GuestId);
                    command.Parameters.AddWithValue("@FirstName", guest.FirstName);
                    command.Parameters.AddWithValue("@LastName", guest.LastName);
                    command.Parameters.AddWithValue("@Birthday", Convert.ToDateTime(guest.Birthday));
                    command.Parameters.AddWithValue("@FullAddress", guest.FullAddress);
                    command.Parameters.AddWithValue("@Phone", guest.Phone);
                    command.ExecuteNonQuery();

                    return true;
                }
            }
        }

        public bool DeleteGuest(Guest guest)
        {
            string sqlString =
                "DELETE FROM Guest WHERE FirstName=@firstName AND LastName=@lastName";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlString, connection))
                {
                    command.Parameters.AddWithValue("@firstName", guest.FirstName);
                    command.Parameters.AddWithValue("@lastName", guest.LastName);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }




    }
}



