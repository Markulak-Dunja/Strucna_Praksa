using Autofac;
using Hotels.Repository.Common;

namespace Hotels.Repository
{
    public class DIRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HotelRepository>().As<IHotelRepository>();

        }
    }
}

