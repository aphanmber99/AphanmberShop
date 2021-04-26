using AutoMapper;

namespace BackEnd.Test
{
    public class MapperMock
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
             {
                 cfg.AddMaps(typeof(MapperConfig));
             });
            return new Mapper(config);
        }
    }
}