using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hotels.Service;
using Hotels.Model;
using AutoMapper;

namespace Hotels.webApi.Controllers
{
    public class HotelsController : ApiController
    {
        HotelService TempServiceHotels = new HotelService();

        // GET: Hotels
        [Route("api/getHotels")]
        public HttpResponseMessage GetHotels()
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Hotel, HotelRest>()
                );

            List<Hotel> AllHotels = new List<Hotel>(TempServiceHotels.GetAllHotels());

            List<HotelRest> PrintHotels = new List<HotelRest>();
            if (AllHotels.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There are no Hotels");
            }
            var mapper = new Mapper(config);


            foreach (Hotel hotel in AllHotels)
            {
                HotelRest AllHotelsBasicInfo = mapper.Map<HotelRest>(hotel);
                PrintHotels.Add(AllHotelsBasicInfo);
            }
            return Request.CreateResponse(HttpStatusCode.OK, PrintHotels);
        }

        //POST:Guest
        [Route("api/newGuest")]
        public HttpResponseMessage NewGuest([FromBody] GuestRest guest)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<GuestRest, Guest>()
                );
            var mapper = new Mapper(config);
            Guest newGuest = mapper.Map<Guest>(guest);

            if (TempServiceHotels.NewGuest(newGuest))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Guest Added");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }


        //Delete:Guest
        [Route("api/deleteGuest")]
        public HttpResponseMessage DeleteGuest([FromBody] GuestRestForDelete guest)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<GuestRestForDelete, Guest>()
                );
            var mapper = new Mapper(config);
            Guest newGuest = mapper.Map<Guest>(guest);

            if (TempServiceHotels.DeleteGuest(newGuest))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Guest Deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }
    }



public class HotelRest
    {
        public string HotelName { get; set; }
        public string FullAddress { get; set; }
        public decimal NightPrice { get; set; }

        public HotelRest(string hotelName, string fullAddress, int nightPrice)
        {
            HotelName = hotelName;
            FullAddress = fullAddress;
            NightPrice = nightPrice;
        }
    }

    public class GuestRest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string FullAddress { get; set; }
        public string Phone { get; set; }
    public GuestRest( string firstName, string lastName, string birthday, string fullAddress, string phone)
    {   FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        FullAddress = fullAddress;
        Phone = phone;
    }
}
    public class GuestRestForDelete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public GuestRestForDelete(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }




}


