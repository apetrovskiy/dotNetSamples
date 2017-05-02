namespace AutoMapperTest001
{
    using AutoMapper;

    class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Class1, Class2>();
        }
    }
}
