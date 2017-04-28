namespace AutoMapperTest001
{
    using System;
    using AutoMapper;

    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyProfile>();
            });

            var cl1Obj = new Class1 {Id = 1, Name = "2", Surname = "3"};
            var cl2Obj = config.CreateMapper().Map<Class1, Class2>(cl1Obj);

            Console.WriteLine(cl2Obj.Id + " " +cl2Obj.FirstName + " " + cl2Obj.LastName);

            Console.ReadKey();
        }
    }
}
