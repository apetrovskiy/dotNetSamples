namespace testNancyPagePosting
{
    using System;
    using Nancy;
    using Nancy.ModelBinding;
    
    public class DataModule : NancyModule
    {
        public DataModule () // : base("/data")
        {
            dynamic data = null;

            Post ["/data"] = parameters => {
                // data = parameters;
                string loadedParams = string.Empty;
                var result = this.Bind();
                if (null != parameters) {
                    foreach(var param in parameters.Keys) {
                        loadedParams += param;
                        loadedParams += @"\r\n";
                        loadedParams += parameters[param];
                        loadedParams += @"\r\n";
                    }
                }
                data = loadedParams;
                System.Windows.Forms.MessageBox.Show(loadedParams);

                return View["data.htm", loadedParams];
            };

            Get ["/data"] = parameters => {
                // return data;
                return View["data", data];
            };
        }
    }
}

