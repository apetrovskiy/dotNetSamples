namespace testAwesomium002
{
    using System;
    using System.Threading;
    using Awesomium.Core;

    // using Awesomium.Core;

    class Program
    {
        static void Main(string[] args)
        {
            TestAwesomium(@"http://lenta.ru");


            Console.WriteLine("===================================================================================================");
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("ALL!");
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("===================================================================================================");
            Console.ReadKey();
        }

        private static void TestAwesomium(string url)
        {
            var html = string.Empty;
            var finishedLoading = false;

            using (var webView = WebCore.CreateWebView(1920, 10800))
            {
                webView.Source = new Uri(url);
                webView.LoadingFrameComplete += (s, e) =>
                {
                    if (!e.IsMainFrame)
                        return;
                    finishedLoading = true;

                    html = webView.HTML;
                    
                };

                while (!finishedLoading)
                {
                    Thread.Sleep(100);
                    //WebCore.Update();
                    WebCore.Update();
                    // WebCore.Run();
                }
                WebCore.Shutdown();
            }

            Console.WriteLine(html);
        }
    }
}
