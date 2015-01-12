using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConstructorInitializer
{
    public class Test
    {
        private int result, other;
        public Test()
            : this(PrepareArgument())
        {
            // Do some other stuff.        
            other = 2;
        }
        public Test(int number)
        {
            // Assign inner variables.        
            result = number;
        }
        private static int PrepareArgument()
        {
            int argument = 1;
            // whatever you want to do to prepare the argument
            return argument;
        }
    }

    //public class Test
    //{
    //    private int result, other;
    //    public Test()
    //        : this(1)
    //    {
    //        // Do some other stuff.        
    //        other = 2;
    //    }
    //    public Test(int number)
    //    {
    //        // Assign inner variables.        
    //        result = number;
    //    }
    //}
}
