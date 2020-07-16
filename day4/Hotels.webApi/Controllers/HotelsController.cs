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




    
}


