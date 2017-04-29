namespace AutoMapperTest001
{
    using AutoMapper;
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Class1, Class2>();
        }
    }
}