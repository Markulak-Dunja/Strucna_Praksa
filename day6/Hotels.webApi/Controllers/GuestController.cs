using Autofac;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hotels.Service.Common;
using Hotels.Model;
using AutoMapper;
using System.Threading.Tasks;

namespace Hotels.webApi.Controllers
{
    public class GuestController : ApiController
    {
        private static IContainer Container { get; set; }

        public GuestController(IHotelsService service)
        {
            this.TempServiceHotels = service;
        }
        protected IHotelsService TempServiceHotels { get;  set; }

        //HotelService TempServiceHotels = new HotelService();

        //POST:Guest
        [Route("api/newGuest")]
        public async Task <HttpResponseMessage> NewGuest([FromBody] GuestRest guest)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<GuestRest, Guest>()
                );
            var mapper = new Mapper(config);
            Guest newGuest = mapper.Map<Guest>(guest);

            if (await TempServiceHotels.NewGuest(newGuest))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Guest Added");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        //PUT:Guest
        [HttpPut]
        [Route("api/UpdateGuestContact")]
        public async Task <HttpResponseMessage> UpdateGuestContact([FromBody] GuestRestContact guest)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<GuestRestContact, Guest>()
                );
            var mapper = new Mapper(config);
            Guest newGuest = mapper.Map<Guest>(guest);

            if (await TempServiceHotels.UpdateGuestContact(newGuest,guest.Phone))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Contact for "+guest.FirstName +" " + guest.LastName + " has been updated");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        // GET: GuestPerHotel
        [HttpGet]
        [Route("api/VisitsInHotel")]
        public async Task <HttpResponseMessage> GetVisitForHotel([FromUri] string hotelName)
        {
            //Initialize the mapperList
            var configList = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Guest, GuestRestBasicInfo>()
                );
            List<Guest> GuestsInHotel = new List<Guest>();
            GuestsInHotel=await TempServiceHotels.GetVisitForHotel(hotelName);

            List<GuestRestBasicInfo> PrintGuests = new List<GuestRestBasicInfo>();
            if (GuestsInHotel.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There are no Hotels");
            }
            var mapper = new Mapper(configList);
            //ostavljen foreach jer mi se u automapp gubi info pronadem rijesenje za vikend
            foreach(Guest guest in GuestsInHotel)
            {
                GuestRestBasicInfo guestBasic = mapper.Map<GuestRestBasicInfo>(guest);
                PrintGuests.Add(guestBasic);
            }

            //List<GuestRestBasicInfo> printGuest = mapper.Map<List<GuestRestBasicInfo>>(TempServiceHotels.GetVisitForHotel(hotelName));


            return Request.CreateResponse(HttpStatusCode.OK,PrintGuests);

        }


        //DELETE:Guest
        [Route("api/deleteGuest")]
        public async Task <HttpResponseMessage> DeleteGuest([FromBody] GuestRestBasicInfo guest)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<GuestRestBasicInfo, Guest>()
                );
            var mapper = new Mapper(config);
            Guest newGuest = mapper.Map<Guest>(guest);

            if (await TempServiceHotels.DeleteGuest(newGuest))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Guest Deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
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
        public GuestRest(string firstName, string lastName, string birthday, string fullAddress, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            FullAddress = fullAddress;
            Phone = phone;
        }
    }
    public class GuestRestBasicInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public GuestRestBasicInfo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public class GuestRestContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public GuestRestContact(string firstName, string lastName,string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }


}