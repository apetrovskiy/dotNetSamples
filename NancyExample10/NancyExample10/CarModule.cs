
namespace NancyExample10
{
	using System;
	using System.Collections.Generic;
	using Nancy;
	using Nancy.ModelBinding;
	
    public class CarModule : NancyModule
    {
		// private readonly ICarRepository _repository;
		readonly ICarRepository _repository;

    	public CarModule(ICarRepository repository)
    	{
			_repository = repository;
			Get["/"] = _ => HttpStatusCode.OK;
    		Get["/status"] = _ => "Hello World";
	        Get["/car/{id}"] = parameters =>
	                                {
	                                    int id = parameters.id;
	                                    
	                                    var car = _repository.GetById(id);
	                                    
	                                    if (321 == id)
	                                    	throw new CarNotFoundException();
	                                    
	                                    return Negotiate
	                                        .WithStatusCode(HttpStatusCode.OK)
	                                        .WithModel(id);
	                                };
	        Get["/{make}/{model}"] = parameters =>
	        {
	        	var carQuery = this.Bind<CarQuery>();
	        	
	        	var listOfCars = new List<Car>()
	        	{
	        		new Car
	        		{
	        			Id = 1,
	        			Make = carQuery.Make,
	        			Model = carQuery.Model
	        		},
	        		new Car
	        		{
	        			Id = 2,
	        			Make = carQuery.Make,
	        			Model = carQuery.Model
	        		},
	        		new Car
	        		{
	        			Id = 3,
	        			Make = carQuery.Make,
	        			Model = carQuery.Model
	        		}
	        	};
	        	
	        	return Negotiate
	        		.WithStatusCode(HttpStatusCode.OK)
	        		.WithModel(listOfCars);
	        };
    	}
    }
 }