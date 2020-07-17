using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hotels.Service;
using Hotels.Model;
using AutoMapper;
using System.Threading.Tasks;

namespace Hotels.webApi.Controllers
{
    public class VisitController : ApiController
    {
        HotelService TempServiceHotels = new HotelService();


        //DELETE:Visit
       [Route("api/delVisit")]
              public async Task<HttpResponseMessage> DeleteVisit([FromBody] VisitRest visit)
              {
                  //Initialize the mapper
                  var config = new MapperConfiguration(cfg =>
                          cfg.CreateMap<VisitRest, Visit>()
                      );
                  var mapper = new Mapper(config);
                  Visit newVisit = mapper.Map<Visit>(visit);

                  
                if (await TempServiceHotels.DeleteVisit(newVisit))
                  {
                      return Request.CreateResponse(HttpStatusCode.OK);
                  }

                  return Request.CreateResponse(HttpStatusCode.BadRequest);
          }

  
    }

    public class VisitRest
        {
    public string CheckIn { get; set; } 
    public string HotelName { get; set; }
    public string GuestFirstName { get; set; }
    public string GuestLastName { get; set; }

        public VisitRest(string checkIn, string personFirstName,string personLastName, string hotelName)
        {
            CheckIn = checkIn;
            HotelName = hotelName;
            GuestFirstName = personFirstName;
            GuestLastName = personLastName;
        }

    }
}