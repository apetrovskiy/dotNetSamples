namespace testAutoMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using One;
    using Two;

    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User01, User02>());
            // var config = new MapperConfiguration(cfg => cfg.CreateMap<User01, User02>());
            var user01 = new User01 { FirstName = "John", LastName = "Smith", SameBool = true, SameInt = 5, SameString = "aaa" };
            var user02 = Mapper.Map<User02>(user01);
            // var mapper = config.CreateMapper();
            // var user02 = mapper.Map<User02>(user01);
            Console.WriteLine(user02.First);
            Console.WriteLine(user02.Surname);
            Console.WriteLine(user02.SameBool);
            Console.WriteLine(user02.SameInt);
            Console.WriteLine(user02.SameString);

            Console.ReadKey();
        }
    }
}
