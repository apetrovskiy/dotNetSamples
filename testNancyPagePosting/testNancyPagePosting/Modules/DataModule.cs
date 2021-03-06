namespace testNancyPagePosting
{
    using System;
    using System.Dynamic;
    using Nancy;
    using Nancy.ModelBinding;
    
    public class DataModule : NancyModule
    {
        static string _path;
        static string _colors;

        public DataModule () // : base("/data")
        {
            dynamic data = null;

            Post ["/data"] = parameters => {
                dynamic data01 = new ExpandoObject();
                string loadedParams = string.Empty;
                var result = this.Bind();
                if (null != Request.Form && 0 < Request.Form.Count) {
                    foreach(var param in Request.Form) {
                        loadedParams += param;
                        loadedParams += " ";
                        loadedParams += Request.Form[param];
                        loadedParams += "<br>";
                    }
                }
                data01.Info = loadedParams;
                data01.Path = "/2222/" + Request.Form.workflow_name;
                return View["data.htm", data01];
            };

            Get ["/data"] = parameters => {
                dynamic data01 = new ExpandoObject();
                data01.Path = _path;
                data01.Colors = _colors;
                return View["data.htm"]; //, data01];
            };
        }
    }
}

