using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testDateTimeTricks
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateString01 = "2016-02-20T12:21:53.2576545Z";
            var dateString02 = "2016-02-20T04:22:27.4475218-08:00";

            var date001 = DateTime.Parse(dateString01).ToUniversalTime();
            var date002 = DateTime.Parse(dateString02).ToUniversalTime();
            Console.WriteLine("== as is ==");
            Console.WriteLine(date001);
            Console.WriteLine(date002);
            Console.WriteLine(date001.Kind);
            Console.WriteLine(date002.Kind);

            Console.WriteLine("== to local ==");
            DateTime.SpecifyKind(date001, DateTimeKind.Local);
            DateTime.SpecifyKind(date002, DateTimeKind.Local);
            Console.WriteLine(date001);
            Console.WriteLine(date002);

            Console.WriteLine("== to UTC ==");
            DateTime.SpecifyKind(date001, DateTimeKind.Utc);
            DateTime.SpecifyKind(date002, DateTimeKind.Utc);
            Console.WriteLine(date001);
            Console.WriteLine(date002);

            const long oneSecond = 10000000;
            var timeDifferenceAllowed = 20*oneSecond;
            Console.WriteLine("== dates comparison ==");
            Console.WriteLine(CompareDateTimeData(date001, date002));
            Console.WriteLine(CompareDateTimeData(date001, DateTime.Parse("2016-02-20T04:22:07.4475218-08:00").ToUniversalTime()));

            var dateLocal = DateTime.Now;
            Console.WriteLine("Local {0} {1} {2}", dateLocal, dateLocal.Kind, dateLocal.ToUniversalTime());
            var dateUtc = DateTime.UtcNow;
            Console.WriteLine("UTC {0} {1} {2}", dateUtc, dateUtc.Kind, dateUtc.ToUniversalTime());
            DateTime.SpecifyKind(dateLocal, DateTimeKind.Local);
            Console.WriteLine("Local (to local) {0} {1} {2}", dateLocal, dateLocal.Kind, dateLocal.ToUniversalTime());
            DateTime.SpecifyKind(dateLocal, DateTimeKind.Utc);
            Console.WriteLine("Local (to UTC) {0} {1} {2}", dateLocal, dateLocal.Kind, dateLocal.ToUniversalTime());
            DateTime.SpecifyKind(dateLocal, DateTimeKind.Unspecified);
            Console.WriteLine("Local (to unspecified) {0} {1} {2}", dateLocal, dateLocal.Kind, dateLocal.ToUniversalTime());

            DateTime.SpecifyKind(dateUtc, DateTimeKind.Local);
            Console.WriteLine("UTC (to local) {0} {1} {2}", dateUtc, dateUtc.Kind, dateUtc.ToUniversalTime());
            DateTime.SpecifyKind(dateUtc, DateTimeKind.Utc);
            Console.WriteLine("UTC (to UTC) {0} {1} {2}", dateUtc, dateUtc.Kind, dateUtc.ToUniversalTime());
            DateTime.SpecifyKind(dateUtc, DateTimeKind.Unspecified);
            Console.WriteLine("UTC (to unspecified) {0} {1} {2}", dateUtc, dateUtc.Kind, dateUtc.ToUniversalTime());

            Console.WriteLine("====================");
            Console.WriteLine("Now = {0}", DateTime.Now);
            Console.WriteLine("Now = {0}", DateTime.Now.Kind);
            Console.WriteLine("UtcNow = {0}", DateTime.UtcNow);
            Console.WriteLine("UtcNow = {0}", DateTime.UtcNow.Kind);
            Console.WriteLine("Now to = {0}", DateTime.Now.ToUniversalTime());
            Console.WriteLine("Now to = {0}", DateTime.Now.ToUniversalTime().Kind);
            Console.WriteLine("UtcNow to = {0}", DateTime.UtcNow.ToUniversalTime());
            Console.WriteLine("UtcNow to = {0}", DateTime.UtcNow.ToUniversalTime().Kind);

            Console.ReadKey();
        }

        public static bool CompareDateTimeData(DateTime? actualData, DateTime? expectedData) // , AuditedSystems collectorType)
        {
            const long oneSecond = 10000000;
            var timeDifferenceAllowed = 20*oneSecond;


            // var timeDifferenceAllowed = GetTimeDifferenceAllowed(collectorType);

            //var result = null != actualData && 
            //    (actualData < expectedData + new TimeSpan(timeDifferenceAllowed) &&
            //    actualData > expectedData - new TimeSpan(timeDifferenceAllowed));
            //var result = null != actualData &&
            //    (actualData.Value.ToUniversalTime() < expectedData.Value.ToUniversalTime() + new TimeSpan(timeDifferenceAllowed) &&
            //    actualData.Value.ToUniversalTime() > expectedData.Value.ToUniversalTime() - new TimeSpan(timeDifferenceAllowed));
            //var result = null != actualData &&
            //    (actualData.Value < expectedData.Value + new TimeSpan(timeDifferenceAllowed) &&
            //    actualData.Value > expectedData.Value - new TimeSpan(timeDifferenceAllowed));
            var result = null != actualData &&
                (actualData < expectedData + new TimeSpan(timeDifferenceAllowed) &&
                actualData > expectedData - new TimeSpan(timeDifferenceAllowed));
            return result;
        }
    }
}
