namespace testNancyPagePosting
{
    using System;
    using System.Dynamic;
    using Nancy;
    using Nancy.ModelBinding;

    public class The2Module : NancyModule
    {
        public The2Module () : base("/2222")
        {
            Get ["/{fileName}"] = parameters => {
                return View[parameters.fileName];
            };

            Post["/{fileName}"] = parameters => {
                dynamic data01 = new ExpandoObject();
                string loadedParams = string.Empty;
                if (null != Request.Form && 0 < Request.Form.Count) {
                    foreach(var param in Request.Form) {
                        loadedParams += param;
                        loadedParams += " ";
                        loadedParams += Request.Form[param];
                        loadedParams += "<br>";
                    }
                }
                data01.Info = loadedParams;

                // var testRun = new TestRun(); // with workflow fileName
                // start test run

                return View[parameters.fileName, data01];
            };
        }
    }
}

