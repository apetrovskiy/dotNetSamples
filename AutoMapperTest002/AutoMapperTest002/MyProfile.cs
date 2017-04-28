using AutoMapper;

namespace AutoMapperTest002
{
    class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Class1, Class2>(); // .ForMember(d => d.FirstName = "Aaa");
        }
    }
}
