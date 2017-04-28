namespace AutoMapperTest003
{
    using System;
    using AutoMapper;

    class MyProfile : Profile
    {
        public MyProfile()
        {
            //this.CreateMap<Class1, Class2>()
            //    .ForMember("FirstName", d => d.UseValue("AAA"))
            //    ; // .ForMember(d => d.FirstName = "Aaa");
        }

        protected override void Configure()
        {
            this.CreateMap<Class1, Class2>()
                .ForMember("FirstName", d => d.UseValue("AAA"))
                ; // .ForMember(d => d.FirstName = "Aaa");
        }
    }
}
