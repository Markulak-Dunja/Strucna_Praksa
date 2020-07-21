using Autofac;
using Hotels.Service.Common;

namespace Hotels.Service
{
    public class DIServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HotelService>().As<IHotelsService>();

        }
    }
}
