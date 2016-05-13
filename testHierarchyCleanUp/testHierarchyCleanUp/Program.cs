/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 17/12/2015
 * Time: 10:47 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testHierarchyCleanUp
{
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var suites = new List<Suite> {
                new Suite { Name = "s01", Id = "01", Scenarios = new List<Scenario> {
                        new Scenario { Name = "sc01", Id = "01", Results = new List<Result> {
                                new Result { Name = "r01", Id = "01" },
                                new Result { Name = "r02", Id = "02" },
                                new Result { Name = "r03", Id = "03" }
                            },
                        },
                        new Scenario { Name = "sc02", Id = "02", Results = new List<Result> {
                                new Result { Name = "r01", Id = "01" },
                                new Result { Name = "r02", Id = "02" },
                                new Result { Name = "r03", Id = "03" }
                            }
                        },
                        new Scenario { Name = "sc03", Id = "03", Results = new List<Result> {
                                new Result { Name = "r01", Id = "01" },
                                new Result { Name = "r02", Id = "02" },
                                new Result { Name = "r03", Id = "03" }
                            }
                        }
                    }
                },
                    new Suite { Name = "s02", Id = "02", Scenarios = new List<Scenario> {
                            new Scenario { Name = "sc01", Id = "01", Results = new List<Result> {
                                new Result { Name = "r01", Id = "01" },
                                new Result { Name = "r02", Id = "02" },
                                new Result { Name = "r03", Id = "03" }
                            },
                        },
                        new Scenario { Name = "sc02", Id = "02", Results = new List<Result> {
                                new Result { Name = "r01", Id = "01" },
                                new Result { Name = "r02", Id = "02" },
                                new Result { Name = "r03", Id = "03" }
                            }
                        },
                        new Scenario { Name = "sc03", Id = "03", Results = new List<Result> {
                                new Result { Name = "r01", Id = "01" },
                                new Result { Name = "r02", Id = "02" },
                                new Result { Name = "r03", Id = "03" }
                            }
                        }
                    }
                }
            };
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}