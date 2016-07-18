using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGenProp001
{
    class Program
    {
        static void Main(string[] args)
        {

            var probe001 = new Probe001 { Holder = Holder.Set(new List<string>())};
        }
    }
}
