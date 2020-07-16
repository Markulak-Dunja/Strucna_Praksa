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
    public class VisitController : ApiController
    {
        HotelService TempServiceHotels = new HotelService();

        // GET: Visit
        //id->imena Guest/Hotel ?   





        //POST:Visit
        /*[Route("api/newVisit")]
        public HttpResponseMessage NewVisit([FromUri] int guestId, [FromUri] int hotelId,[FromBody]VisitCheck visit)
        {
            Visit newVisit = new Visit(visit.CheckIn, visit.CheckOut, guestId, hotelId);
            
            if (TempServiceHotels.NewVisit(newVisit))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }*/
   
        //DELETE:Visit
        [Route("api/delVisit")]
            public HttpResponseMessage DeleteVisit([FromUri] VisitRestDelete visit)
            {
                //Initialize the mapper
                var config = new MapperConfiguration(cfg =>
                        cfg.CreateMap<VisitRestDelete, Visit>()
                    );
                var mapper = new Mapper(config);
                Visit newVisit = mapper.Map<Visit>(visit);

                if (TempServiceHotels.DeleteVisit(newVisit))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }



    public class VisitCheck
    {
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }

        public VisitCheck(string checkIn, string checkOut)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
    }
        public class VisitRestDelete
    {
        public string CheckIn { get; set; } 
        public int HotelId { get; set; }
        public int GuestId { get; set; }

        public VisitRestDelete(string checkIn, int personName, int hotelName)
        {
            CheckIn = checkIn;
            HotelId = hotelName;
            GuestId = personName;
        }

    }
}