using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testOfTimeDirrerence
{
    class Program
    {
        static void Main(string[] args)
        {
            Enum.GetValues(typeof(AuditedSystems)).Cast<AuditedSystems>().ToList().ForEach(val => Console.WriteLine("{0} {1} {2} {3} {4}", val, GetTimeDifferenceAllowed(val) / 10000000, GetTimeDifferenceAllowed(val) / 10000000 / 60, GetTimeDifferenceAllowed(val) / 10000000 / 60 / 60, new TimeSpan(GetTimeDifferenceAllowed(val))));
            Console.ReadKey();
        }

        static long GetTimeDifferenceAllowed(AuditedSystems collectorType)
        {
            const long oneSecond = 10000000;
            var timeDifferenceAllowed = 20 * oneSecond;
            switch (collectorType)
            {
                case AuditedSystems.ActiveDirectory:
                case AuditedSystems.Exchange:
                case AuditedSystems.GroupPolicy:
                case AuditedSystems.Sharepoint:
                // TODO: set to the right value
                case AuditedSystems.NetworkLogons:
                    timeDifferenceAllowed = 5 * oneSecond;
                    break;
                case AuditedSystems.ExchangeOnline:
                // TODO: NOMBA Online
                case AuditedSystems.UserActivity:
                    timeDifferenceAllowed = 5 * oneSecond;
                    break;
                case AuditedSystems.FileServer:
                case AuditedSystems.SqlServer:
                    timeDifferenceAllowed = 5 * oneSecond;
                    break;
                case AuditedSystems.WindowsServer:
                    timeDifferenceAllowed = 5 * oneSecond;
                    break;
                case AuditedSystems.Vmware:
                    timeDifferenceAllowed = 2 * 60 * oneSecond;
                    break;
            }
            return timeDifferenceAllowed;
        }

#region commented
        //static long GetTimeDifferenceAllowed(AuditedSystems collectorType)
        //{
        //    const long oneSecond = 10000000;
        //    // var timeDifferenceAllowed = 10*oneSecond;
        //    // 20150827
        //    var timeDifferenceAllowed = 20 * oneSecond;
        //    // 20160223
        //    // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    // 20160229
        //    // timeDifferenceAllowed = 5 * 60 * oneSecond;

        //    // var timeDifferenceAllowed = 2*60*60*oneSecond;
        //    // never used
        //    // var timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    switch (collectorType)
        //    {
        //        case AuditedSystems.ActiveDirectory:
        //        case AuditedSystems.Exchange:
        //        case AuditedSystems.GroupPolicy:
        //        // 20160223
        //        // case AuditedSystems.FileServer:
        //        case AuditedSystems.Sharepoint:
        //        // 20160225
        //        // case AuditedSystems.SqlServer:
        //        // 20151204
        //        // TODO: set to the right value
        //        case AuditedSystems.NetworkLogons:
        //            // 20160223
        //            // timeDifferenceAllowed = 3 * oneSecond;
        //            // 20160226
        //            // 20160229
        //            // timeDifferenceAllowed = 4 * oneSecond;
        //            timeDifferenceAllowed = 5 * oneSecond;
        //            // 20160223
        //            break;
        //        case AuditedSystems.ExchangeOnline:
        //        // TODO: NOMBA Online
        //        // 20151229
        //        case AuditedSystems.UserActivity:
        //            // 20160223
        //            // 20160229
        //            // timeDifferenceAllowed = 2 * oneSecond;
        //            timeDifferenceAllowed = 5 * oneSecond;
        //            break;
        //        // 20160223
        //        case AuditedSystems.FileServer:
        //        // 20160225
        //        case AuditedSystems.SqlServer:
        //            // 20160229
        //            // timeDifferenceAllowed = 5 * 60 * oneSecond;
        //            timeDifferenceAllowed = 5 * oneSecond;
        //            break;
        //        case AuditedSystems.WindowsServer:
        //            // timeDifferenceAllowed = 10*60*oneSecond;
        //            // 20150827
        //            // timeDifferenceAllowed = 20*60*oneSecond;
        //            // 20160223
        //            // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //            // 20160229
        //            // timeDifferenceAllowed = 20 * 60 * oneSecond;
        //            timeDifferenceAllowed = 5 * oneSecond;
        //            break;
        //        case AuditedSystems.Vmware:
        //            timeDifferenceAllowed = 2 * 60 * oneSecond;
        //            break;
        //    }
        //    return timeDifferenceAllowed;
        //}

        //static long GetTimeDifferenceAllowed(AuditedSystems collectorType)
        //{
        //    const long oneSecond = 10000000;
        //    // var timeDifferenceAllowed = 10*oneSecond;
        //    // 20150827
        //    var timeDifferenceAllowed = 20 * oneSecond;
        //    // 20160223
        //    // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    // 20160229
        //    // timeDifferenceAllowed = 5 * 60 * oneSecond;

        //    // var timeDifferenceAllowed = 2*60*60*oneSecond;
        //    // never used
        //    // var timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    switch (collectorType)
        //    {
        //        case AuditedSystems.ActiveDirectory:
        //        case AuditedSystems.Exchange:
        //        case AuditedSystems.GroupPolicy:
        //        // 20160223
        //        // case AuditedSystems.FileServer:
        //        case AuditedSystems.Sharepoint:
        //        // 20160225
        //        // case AuditedSystems.SqlServer:
        //        // 20151204
        //        // TODO: set to the right value
        //        case AuditedSystems.NetworkLogons:
        //            // 20160223
        //            // timeDifferenceAllowed = 3 * oneSecond;
        //            // 20160226
        //            // 20160229
        //            // timeDifferenceAllowed = 4 * oneSecond;
        //            timeDifferenceAllowed = 5 * oneSecond;
        //            // 20160223
        //            break;
        //        case AuditedSystems.ExchangeOnline:
        //        // TODO: NOMBA Online
        //        // 20151229
        //        case AuditedSystems.UserActivity:
        //            // 20160223
        //            timeDifferenceAllowed = 2 * oneSecond;
        //            break;
        //        // 20160223
        //        case AuditedSystems.FileServer:
        //        // 20160225
        //        case AuditedSystems.SqlServer:
        //            // 20160229
        //            // timeDifferenceAllowed = 5 * 60 * oneSecond;
        //            timeDifferenceAllowed = 5 * oneSecond;
        //            break;
        //        case AuditedSystems.WindowsServer:
        //            // timeDifferenceAllowed = 10*60*oneSecond;
        //            // 20150827
        //            // timeDifferenceAllowed = 20*60*oneSecond;
        //            // 20160223
        //            // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //            // 20160229
        //            // timeDifferenceAllowed = 20 * 60 * oneSecond;
        //            timeDifferenceAllowed = 5 * oneSecond;
        //            break;
        //        case AuditedSystems.Vmware:
        //            timeDifferenceAllowed = 2 * 60 * oneSecond;
        //            break;
        //    }
        //    return timeDifferenceAllowed;
        //}

        //static long GetTimeDifferenceAllowed(AuditedSystems collectorType)
        //{
        //    const long oneSecond = 10000000;
        //    // var timeDifferenceAllowed = 10*oneSecond;
        //    // 20150827
        //    var timeDifferenceAllowed = 20 * oneSecond;
        //    // 20160223
        //    // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    timeDifferenceAllowed = 5 * 60 * oneSecond;
        //    // var timeDifferenceAllowed = 2*60*60*oneSecond;
        //    // never used
        //    // var timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    switch (collectorType)
        //    {
        //        case AuditedSystems.ActiveDirectory:
        //        case AuditedSystems.Exchange:
        //        case AuditedSystems.GroupPolicy:
        //        // 20160223
        //        // case AuditedSystems.FileServer:
        //        case AuditedSystems.Sharepoint:
        //        // 20160225
        //        // case AuditedSystems.SqlServer:
        //        // 20151204
        //        // TODO: set to the right value
        //        case AuditedSystems.NetworkLogons:
        //            // 20160223
        //            // timeDifferenceAllowed = 3 * oneSecond;
        //            // 20160226
        //            timeDifferenceAllowed = 4 * oneSecond;
        //            // 20160223
        //            break;
        //        case AuditedSystems.ExchangeOnline:
        //        // TODO: NOMBA Online
        //        // 20151229
        //        case AuditedSystems.UserActivity:
        //            // 20160223
        //            timeDifferenceAllowed = 2 * oneSecond;
        //            break;
        //        // 20160223
        //        case AuditedSystems.FileServer:
        //        // 20160225
        //        case AuditedSystems.SqlServer:
        //            timeDifferenceAllowed = 5 * 60 * oneSecond;
        //            break;
        //        case AuditedSystems.WindowsServer:
        //            // timeDifferenceAllowed = 10*60*oneSecond;
        //            // 20150827
        //            // timeDifferenceAllowed = 20*60*oneSecond;
        //            // 20160223
        //            // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //            timeDifferenceAllowed = 20 * 60 * oneSecond;
        //            break;
        //        case AuditedSystems.Vmware:
        //            timeDifferenceAllowed = 2 * 60 * oneSecond;
        //            break;
        //    }
        //    return timeDifferenceAllowed;
        //}

        //static long GetTimeDifferenceAllowed(AuditedSystems collectorType)
        //{
        //    const long oneSecond = 10000000;
        //    // var timeDifferenceAllowed = 10*oneSecond;
        //    // 20150827
        //    var timeDifferenceAllowed = 20 * oneSecond;
        //    // 20160223
        //    // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    timeDifferenceAllowed = 5 * 60 * oneSecond;
        //    // var timeDifferenceAllowed = 2*60*60*oneSecond;
        //    // never used
        //    // var timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    switch (collectorType)
        //    {
        //        case AuditedSystems.ActiveDirectory:
        //        case AuditedSystems.Exchange:
        //        case AuditedSystems.GroupPolicy:
        //        // 20160223
        //        // case AuditedSystems.FileServer:
        //        case AuditedSystems.Sharepoint:
        //        // 20160225
        //        // case AuditedSystems.SqlServer:
        //        // 20151204
        //        // TODO: set to the right value
        //        case AuditedSystems.NetworkLogons:
        //            // 20160223
        //            timeDifferenceAllowed = 3 * oneSecond;
        //            // 20160223
        //            break;
        //        case AuditedSystems.ExchangeOnline:
        //        // TODO: NOMBA Online
        //        // 20151229
        //        case AuditedSystems.UserActivity:
        //            // 20160223
        //            timeDifferenceAllowed = 2 * oneSecond;
        //            break;
        //        // 20160223
        //        case AuditedSystems.FileServer:
        //        // 20160225
        //        case AuditedSystems.SqlServer:
        //            timeDifferenceAllowed = 5 * 60 * oneSecond;
        //            break;
        //        case AuditedSystems.WindowsServer:
        //            // timeDifferenceAllowed = 10*60*oneSecond;
        //            // 20150827
        //            // timeDifferenceAllowed = 20*60*oneSecond;
        //            // 20160223
        //            // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //            timeDifferenceAllowed = 20 * 60 * oneSecond;
        //            break;
        //        case AuditedSystems.Vmware:
        //            timeDifferenceAllowed = 2 * 60 * oneSecond;
        //            break;
        //    }
        //    return timeDifferenceAllowed;
        //}

        //static long GetTimeDifferenceAllowed(AuditedSystems collectorType)
        //{
        //    const long oneSecond = 10000000;
        //    // var timeDifferenceAllowed = 10*oneSecond;
        //    // 20150827
        //    var timeDifferenceAllowed = 20 * oneSecond;
        //    // 20160223
        //    // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    timeDifferenceAllowed = 5 * 60 * oneSecond;
        //    // var timeDifferenceAllowed = 2*60*60*oneSecond;
        //    // never used
        //    // var timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    switch (collectorType)
        //    {
        //        case AuditedSystems.ActiveDirectory:
        //        case AuditedSystems.Exchange:
        //        case AuditedSystems.GroupPolicy:
        //        // 20160223
        //        // case AuditedSystems.FileServer:
        //        case AuditedSystems.Sharepoint:
        //        case AuditedSystems.SqlServer:
        //        // 20151204
        //        // TODO: set to the right value
        //        case AuditedSystems.NetworkLogons:
        //            // 20160223
        //            timeDifferenceAllowed = 3 * oneSecond;
        //            // 20160223
        //            break;
        //        case AuditedSystems.ExchangeOnline:
        //        // TODO: NOMBA Online
        //        // 20151229
        //        case AuditedSystems.UserActivity:
        //            // 20160223
        //            timeDifferenceAllowed = 2 * oneSecond;
        //            break;
        //        // 20160223
        //        case AuditedSystems.FileServer:
        //            timeDifferenceAllowed = 5 * 60 * oneSecond;
        //            break;
        //        case AuditedSystems.WindowsServer:
        //            // timeDifferenceAllowed = 10*60*oneSecond;
        //            // 20150827
        //            // timeDifferenceAllowed = 20*60*oneSecond;
        //            // 20160223
        //            // timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //            timeDifferenceAllowed = 20 * 60 * oneSecond;
        //            break;
        //        case AuditedSystems.Vmware:
        //            timeDifferenceAllowed = 2 * 60 * oneSecond;
        //            break;
        //    }
        //    return timeDifferenceAllowed;
        //}

        //static long GetTimeDifferenceAllowed(AuditedSystems collectorType)
        //{
        //    const long oneSecond = 10000000;
        //    // var timeDifferenceAllowed = 10*oneSecond;
        //    // 20150827
        //    var timeDifferenceAllowed = 20 * oneSecond;
        //    timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    // var timeDifferenceAllowed = 2*60*60*oneSecond;
        //    // never used
        //    // var timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //    switch (collectorType)
        //    {
        //        case AuditedSystems.ActiveDirectory:
        //        case AuditedSystems.Exchange:
        //        case AuditedSystems.GroupPolicy:
        //        case AuditedSystems.FileServer:
        //        case AuditedSystems.Sharepoint:
        //        case AuditedSystems.SqlServer:
        //        // 20151204
        //        // TODO: set to the right value
        //        case AuditedSystems.NetworkLogons:
        //        case AuditedSystems.ExchangeOnline:
        //        // TODO: NOMBA Online
        //        // 20151229
        //        case AuditedSystems.UserActivity:
        //            break;
        //        case AuditedSystems.WindowsServer:
        //            // timeDifferenceAllowed = 10*60*oneSecond;
        //            // 20150827
        //            // timeDifferenceAllowed = 20*60*oneSecond;
        //            timeDifferenceAllowed = 4 * 60 * 60 * oneSecond;
        //            break;
        //        case AuditedSystems.Vmware:
        //            timeDifferenceAllowed = 2 * 60 * oneSecond;
        //            break;
        //    }
        //    return timeDifferenceAllowed;
        //}
#endregion
    }

    public enum AuditedSystems
    {
        ActiveDirectory = 1,
        Exchange = 7,
        GroupPolicy = 3,
        FileServer = 4,
        WindowsServer = 8,
        Eventlog = 70,
        InactiveUsersTracking = -1,
        PasswordExpirationAlerting = -2, // -1,
        Sharepoint = 13,
        Vmware = 2,
        SqlServer = 5,
        NetworkLogons = 20,
        // ExchangeOnline = 24,
        ExchangeOnline = 50,
        NombaOnline = 51,
        UserActivity = 30,
        ManagementConsole = 26, // 13,
        NonOwnerMailboxAccess = 27, // 14
        Api = 40
    }
}
