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

    public class HotelsController : ApiController
    {
        public HotelsController(IHotelsService service)
        {
            this.TempServiceHotels = service;
        }
        protected IHotelsService TempServiceHotels { get; set; }
        //HotelService TempServiceHotels = new HotelService();

        // GET: Hotels
        [HttpGet]
        [Route("api/getHotels")]
         public async Task <HttpResponseMessage> GetHotels()
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Hotel, HotelRest>()
                );

            List<Hotel> AllHotels = new List<Hotel>();
            AllHotels = await TempServiceHotels.GetAllHotels();

            List<HotelRest> PrintHotels = new List<HotelRest>();
            if (AllHotels.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There are no Hotels");
            }
            var mapper = new Mapper(config);

            //ostavljen foreach jer mi se u automapp gubi info pronadem rijesenje za vikend
            foreach (Hotel hotel in AllHotels)
            {
                HotelRest AllHotelsBasicInfo = mapper.Map<HotelRest>(hotel);
                PrintHotels.Add(AllHotelsBasicInfo);
            }
            return Request.CreateResponse(HttpStatusCode.OK, PrintHotels);
        }
        


        [Route("api/newHotel")]

        public async Task <HttpResponseMessage> NewHotel([FromBody] HotelRestAllInfo hotel)
        {
            //Initialize the mapperList
            var configList = new MapperConfiguration(cfg =>
                    cfg.CreateMap<HotelRestAllInfo, Hotel>()
                );

            var mapper = new Mapper(configList);
            Hotel HotelInfo = mapper.Map<Hotel>(hotel);
            if (await TempServiceHotels.NewHotel(HotelInfo))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Hotel Added");
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
        public class HotelRestAllInfo
        {
             public string HotelName { get; set; }
            public string FullAddress { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public int NumberOfRooms { get; set; }
            public string CanCheckIn { get; set; }
            public string MustCheckOut { get; set; }
            public decimal NightPrice { get; set; }

        public HotelRestAllInfo( string hotelName, string address, string phoneNumber, string email, int numOfRooms, string canCheckIn, string mustCheckOut, decimal nightPrice)
            {
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



}


