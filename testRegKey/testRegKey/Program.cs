namespace testRegKey
{
    using Microsoft.Win32;

    class Program
    {
        static void Main(string[] args)
        {
            var worker = new RegistryWorker();
            worker.BaseKey = Registry.CurrentUser;
            worker.CreateKey(@"aaa\bbb\ccc1", "ddd");
            worker.BaseKey = Registry.LocalMachine;
            worker.CreateKey(@"system\currentcontrolset\ccc", "ddd");
            worker.BaseKey = Registry.LocalMachine;
            worker.CreateKey(@"system\ccc", "ddd");
            worker.BaseKey = Registry.LocalMachine;
            worker.CreateKey(@"software\ccc", "ddd");
        }
    }
}
