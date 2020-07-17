using AutoMapper;


namespace Hotels.webApi.Models
{
    public class Methods
    {
        public Mapper ConfigMapper(object fromMap, object inMap)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<object, object>());

            return new Mapper(config);
        }
    }
}