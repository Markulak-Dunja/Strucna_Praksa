using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Hotels.Repository.Common;
using Hotels.Model;
using Microsoft.SqlServer.Server;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Hotels.Repository
{
    public class HotelRepository : IHotelRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hotels;Integrated Security=True";

        public async Task<List<Hotel>> GetAllHotels()
        {
            List<Hotel> AllHotells = new List<Hotel>();

            string sqlString = "SELECT* FROM Hotel;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(sqlString, connection);
                connection.Open();

                SqlDataReader reader =await Task.Run(() => command.ExecuteReader());

                // Call Read before accessing data.
                while (reader.Read())
                {
                    AllHotells.Add(new Hotel(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), Convert.ToInt32(reader[5]), reader[6].ToString(), reader[7].ToString(), Convert.ToDecimal(reader[8])));
                }

                reader.Close();
                connection.Close();

            }
            return AllHotells;
        }


        public async Task<bool> NewHotel(Hotel hotel)
        {
            string sqlString =
                "INSERT INTO HOTEL VALUES(@HotelId,@HotelName,@FullAddress,@Phone,@Email,@NumberOfRooms,@CanCheckIn,@MustCheckOut,@NightPrice);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlString, connection))
                {
                    command.Parameters.AddWithValue("@HotelId", hotel.HotelId);
                    command.Parameters.AddWithValue("@HotelName", hotel.HotelName);
                    command.Parameters.AddWithValue("@FullAddress", hotel.FullAddress);
                    command.Parameters.AddWithValue("@Phone", hotel.Phone);
                    command.Parameters.AddWithValue("@Email", hotel.Email);
                    command.Parameters.AddWithValue("@NumberOfRooms", hotel.NumberOfRooms);
                    command.Parameters.AddWithValue("@CanCheckIn", hotel.CanCheckIn);
                    command.Parameters.AddWithValue("@MustCheckOut", hotel.MustCheckOut);
                    command.Parameters.AddWithValue("@NightPrice", hotel.NightPrice);
                    await Task.Run(() => command.ExecuteNonQuery());

                    return true;
                }
            }
        }

        public async Task<bool> NewGuest(Guest guest)
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
                    await Task.Run(() => command.ExecuteNonQuery());


                    return true;
                }
            }
        }

        public async Task<bool> UpdateGuestContact(Guest guest, string phone)
        {
            string sqlString =
               "UPDATE Guest SET Phone=@phone WHERE FirstName=@firstName AND LastName=@lastName";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlString, connection))
                {
                    command.Parameters.AddWithValue("@firstName", guest.FirstName);
                    command.Parameters.AddWithValue("@lastName", guest.LastName);
                    command.Parameters.AddWithValue("@phone", phone);

                    await Task.Run(() => command.ExecuteNonQuery());

                    return true;
                }
            }

        }
        public async Task<List<Guest>> GetVisitForHotel(string hotel)
        {
            List<Guest> GuestInAHotel = new List<Guest>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlCommand = String.Format("SELECT * FROM Guest WHERE FirstName IN (SELECT FirstName FROM GUEST g INNER JOIN VISIT v ON (g.GuestId = v.GuestId) INNER JOIN Hotel h ON (v.HotelId = h.HotelId) " +
                    " WHERE HotelName = '{0}' ) AND  LastName IN ( SELECT LastName FROM GUEST g INNER JOIN VISIT v ON (g.GuestId = v.GuestId) INNER JOIN Hotel h ON (v.HotelId = h.HotelId) " +
                    "WHERE HotelName = '{0}' ); ", hotel);

                using (SqlCommand command =
                    new SqlCommand(sqlCommand, connection))
                {
                    SqlDataReader reader = await Task.Run(() => command.ExecuteReader());
                    ;

                    while (reader.Read())
                    {
                        GuestInAHotel.Add(new Guest(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
                    }

                    reader.Close();
                }
            }
            return GuestInAHotel;
        }

        public async Task<bool> DeleteGuest(Guest guest)
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
                    await Task.Run(() => command.ExecuteNonQuery());

                    return true;
                }
            }
        }
        public async Task<bool> DeleteVisit(Visit visit)
        {
            string sqlString =
                   "DELETE FROM Visit WHERE HotelId=(SELECT HotelId FROM Hotel WHERE HotelName=@hotel) AND guestId=(SELECT GuestId FROM GUEST WHERE FirstName=@firstName AND LastName=@lastName) AND CheckIn=@checkIn";
            using ( SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlString, connection))
                {
                    command.Parameters.AddWithValue("@firstName", visit.GuestFirstName);
                    command.Parameters.AddWithValue("@lastName", visit.GuestLastName);
                    command.Parameters.AddWithValue("@checkIn", Convert.ToDateTime(visit.CheckIn));
                    await Task.Run(() => command.ExecuteNonQuery());

                    connection.Close();
 
                    return true;
                }
            }
        }






    }
}




