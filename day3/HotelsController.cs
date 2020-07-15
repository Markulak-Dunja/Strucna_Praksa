using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.Design;
using System.Configuration;

namespace HotlsDay3.webapi.Controllers
{
    public class Hotel
    {   
        public int HotelId { get; set; }
        public string HotelName, FullAddress, Phone, Email;
        public int NumberOfRooms;
        public string CanCheckIn, MustCheckOut;
        public decimal NightPrice;
        
        public Hotel(int hotelId,string hotelName,string address,string phoneNumber,string email, int numOfRooms,string canCheckIn,string mustCheckOut,decimal nightPrice)
        {
            HotelId = hotelId;
            HotelName = hotelName;
            FullAddress = address;
            Phone = phoneNumber;
            Email = email;
            NumberOfRooms = numOfRooms;
            CanCheckIn = canCheckIn;
            MustCheckOut = mustCheckOut;
            NightPrice = nightPrice;
        }
    
    }
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName, LastName, Birthday, FullAddress, Phone;

        public Guest(int guestId,string firstName,string lastName, string birthday, string fullAddress, string phone)
        {
            GuestId = guestId;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            FullAddress = fullAddress;
            Phone = phone; 

        }
    }

    public class Visit
    {
        public string CheckIn , CheckOut, HotelName, PersonName;

        public Visit (string checkIn, string checkOut,string personName, string hotelName)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            HotelName = hotelName;
            PersonName = personName;
        }

     }


    public class HotelsController : ApiController
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hotels;Integrated Security=True";
        static List<Hotel> AllHotells = new List<Hotel>();
        static List<Guest> AllGuests = new List<Guest>();
        static List<Visit> AllVisits = new List<Visit>();


        // GET: Hotels
        [Route("api/getHotels")]
        public HttpResponseMessage GetHotels()
        {
            string sqlString =
                "SELECT* FROM Hotel;";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
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

                // Call Close when done reading.
                reader.Close();

                if (AllHotells.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There are no Hotels");
                }
                return Request.CreateResponse(HttpStatusCode.OK, AllHotells);
            }
        }

        // GET: Guest
        [Route("api/getGuests")]
        public HttpResponseMessage GetGuests()
        {
            string sqlString =
                "SELECT * FROM Guest;";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(sqlString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    AllGuests.Add(new Guest(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
                }

                // Call Close when done reading.
                reader.Close();

                if (AllGuests.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There are no Guests");
                }

                return Request.CreateResponse(HttpStatusCode.OK, AllGuests);
            }
        }


        // GET: Visits
        [Route("api/getVisits")]
        public HttpResponseMessage GetVisits()
        {
            string sqlString =
                "SELECT HotelName,FirstName, LastName,CheckIn,CheckOut FROM Guest g INNER JOIN Visit v ON g.GuestId=v.GuestId INNER JOIN Hotel h ON h.HotelId=v.HotelId;";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(sqlString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    AllVisits.Add(new Visit(reader[3].ToString(), reader[4].ToString(), reader[1].ToString() + ' ' + reader[2].ToString(), reader[0].ToString()));
                }

                // Call Close when done reading.
                reader.Close();

                if (AllVisits.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There are no Visits");
                }
                return Request.CreateResponse(HttpStatusCode.OK, AllVisits);
            }
        }



        //POST:Hotel
        [Route("api/newHotel")]
        public HttpResponseMessage NewHotel([FromBody] Hotel hotel)
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
                    command.ExecuteNonQuery();
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        //POST:Guest
        [Route("api/newGuest")]
        public HttpResponseMessage NewGuest([FromBody] Guest guest)
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
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        
        //PUT:Hotel
        [Route("api/putHotel")]
        public HttpResponseMessage PutHotel([FromUri] int hotelId, [FromBody] Hotel hotel)
        {
            string sqlString =
                "UPDATE Hotel SET hotelName = @hotelName ,CanCheckIn=@canCheckIn, MustCheckOut=@mustCheckOut, NightPrice=@nightPrice WHERE Hotelid = @hotelId;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlString, connection))
                {
                    command.Parameters.AddWithValue("@hotelName", hotel.HotelName);
                    command.Parameters.AddWithValue("@canCheckIn", hotel.CanCheckIn);
                    command.Parameters.AddWithValue("@mustCheckOut", hotel.MustCheckOut);
                    command.Parameters.AddWithValue("@nightPrice", hotel.NightPrice);
                    command.Parameters.AddWithValue("@hotelid", hotelId);

                    command.ExecuteNonQuery();
                }
            return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        //Delete:Visit
        [Route("api/delVisit")]
        public HttpResponseMessage DeleteVisit([FromUri] int hotelId,[FromUri] int guestId, [FromBody] Visit visited)
        {
            string sqlString =
                "DELETE FROM Visit WHERE HotelId=@hotelId AND guestId=@guestId AND CheckIn=@checkIn";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlString, connection))
                {
                    command.Parameters.AddWithValue("@hotelId", hotelId);
                    command.Parameters.AddWithValue("@guestId", guestId);
                    command.Parameters.AddWithValue("@checkIn",Convert.ToDateTime( visited.CheckIn));
                    command.ExecuteNonQuery();
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

//TO DO: Popunit sve CRUD metode za sve klase






    }

}
