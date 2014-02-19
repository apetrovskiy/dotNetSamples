using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rshpLingTest
{
    class TestProcStatic
    {
        public static TestProcImpl[] GetObjects(int id)
        {
            return new[]
                {
                    new TestProcImpl() {Id = id},
                    new TestProcImpl() {Id = id},
                    new TestProcImpl() {Id = id}
                };
        }
    }
}
