using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rshpLingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var testProcImplObjects =
                new[]
                {
                    new TestProcImpl() {Id = 1},
                    new TestProcImpl() {Id = 2},
                    new TestProcImpl() {Id = 1000},
                    new TestProcImpl() {Id = 100},
                    new TestProcImpl() {Id = 999}
                };

            var ids = (from testProcImplObject in testProcImplObjects where null != testProcImplObject && 0 != testProcImplObject.Id select testProcImplObject.Id).ToList();

            /*
            foreach (var testProcImplObject in testProcImplObjects)
            {
                if (null != testProcImplObject && 0 != testProcImplObject.Id)
                {
                    ids.Add(testProcImplObject.Id);
                }
            }
            */

            // var list = TestProcStatic.GetObjects(3).ToList();

            /*
            foreach (var testObject in TestProcStatic.GetObjects(3))
            {
                list.Add(testObject);
            }
            */

            var idList = new[] {1, 3, 5};
            var list = idList.SelectMany(i => TestProcStatic.GetObjects(i)).ToList();
            /*
            var list = new List<TestProcImpl>();
            var idList = new[] {1, 3, 5};
            foreach (int i in idList)
            {
                foreach (var testproc in TestProcStatic.GetObjects(i))
                {
                    list.Add(testproc);
                }
            }
            */
        }
    }
}
