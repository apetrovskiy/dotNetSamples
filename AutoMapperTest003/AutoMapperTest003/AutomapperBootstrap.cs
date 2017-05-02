namespace AutoMapperTest003
{
    using AutoMapper;

    public class AutomapperBootstrap
    {
        public static IMapper Mapper;

        public static void ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyProfile>();
            });

            Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }
}