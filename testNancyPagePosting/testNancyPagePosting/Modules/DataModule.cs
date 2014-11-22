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
                // if (null != parameters) {
                if (null != Request.Form && 0 < Request.Form.Count) {
                    // foreach(var param in parameters.Keys) {
                    foreach(var param in Request.Form) {
                        loadedParams += param;
                        loadedParams += "\r\n";
                        // loadedParams += parameters[param];
                        loadedParams += Request.Form[param];
                        loadedParams += "\r\n";
                    }
                }
                try { loadedParams += Request.Form.GetType().Name; } catch (Exception ee) { loadedParams += ee.Message; }
                loadedParams += "\r\nRequest.Form parameters:\r\n";
                try { loadedParams += result.ToString(); } catch (Exception ee) { loadedParams += ee.Message; }
                /*
                if (null != result) {
                    foreach(var param in result) {
                        loadedParams += param;
                        loadedParams += @"\r\n";
                        loadedParams += parameters[param];
                        loadedParams += @"\r\n";
                    }
                }
                */
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

