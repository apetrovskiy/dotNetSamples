namespace testOverriding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            var baseClass = new BaseClass();
            var childClass = new ChildClass();

            baseClass.SetIntData(3);
            Console.WriteLine("base class int data = {0}", baseClass.GetIntData());
            baseClass.SetStringData("aaa");
            Console.WriteLine("base class string data = {0}", baseClass.StringData);

            childClass.SetIntData(3);
            Console.WriteLine("child class int data = {0}", childClass.GetIntData());
            childClass.SetStringData("aaa");
            Console.WriteLine("child class string data = {0}", childClass.GetStringData());

            ((BaseClass)childClass).SetIntData(3);
            Console.WriteLine("child class int data now = {0}", childClass.GetIntData());
            ((BaseClass)childClass).SetStringData("aaa");
            Console.WriteLine("child class string data now = {0}", childClass.GetStringData());

            Console.ReadKey();
        }
    }
}
