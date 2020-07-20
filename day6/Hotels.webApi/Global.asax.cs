using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Hotels.Service;
using Hotels.Service.Common;
using Hotels.Repository;
using Hotels.Repository.Common;
using Autofac.Integration.WebApi;
using Hotels.webApi.Controllers;

namespace Hotels.webApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            builder.RegisterType<HotelsController>();
            builder.RegisterType<GuestController>();
            builder.RegisterType<VisitController>();

            builder.RegisterType<HotelService>().As<IHotelsService>();
            builder.RegisterType<HotelRepository>().As<IHotelRepository>();


            var container = builder.Build();

        }
    }
    }

