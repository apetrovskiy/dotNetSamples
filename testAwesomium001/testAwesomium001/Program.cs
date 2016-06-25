using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testAwesomium001
{
    class Program
    {
        static void Main(string[] args)
        {
            IntPtr ptr = IntPtr.Zero;
            var awesomium = new Awesomium.Core.WebView(ptr);
            awesomium.LoadHTML
        }
    }
}
