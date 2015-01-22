using System;

namespace testWcfMono01
{
    public class MyService : IMyService
    {
        public String GetData()
        {
            return "Hello WCF over Mono";
        }
    }
}

