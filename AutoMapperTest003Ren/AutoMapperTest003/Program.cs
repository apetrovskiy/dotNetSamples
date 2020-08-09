﻿namespace AutoMapperTest003
{
    using AutoMapper;
    using System;

    

    class Program
    {
        // static Mapper = AutomapperBootstrap.Mapper;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<MyProfile>();
            //});

            AutomapperBootstrap.ConfigureAutoMapper();

            var cl1Obj = new Class1 { Id = 1, Name = "NNN", Surname = "SSS" };
            // var cl2Obj = config.CreateMapper().Map<Class1, Class2>(cl1Obj);
            var cl2Obj = AutomapperBootstrap.Mapper.Map<Class1, Class2>(cl1Obj);

            Console.WriteLine(cl2Obj.Id + " " + cl2Obj.FirstName + " " + cl2Obj.LastName);

            Console.ReadKey();
        }
    }
}