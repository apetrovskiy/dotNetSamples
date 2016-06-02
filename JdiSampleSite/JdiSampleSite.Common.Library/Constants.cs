namespace JdiSampleSite.Common.Library
{
    public class FrameworkPath
    {
        Frameworks _framework;
        public FrameworkPath(Frameworks framework)
        {
            _framework = framework;
        }

        // public static void SetFramework

        public string FrameworkRoot
        {
            get
            {
                switch (_framework)
                {
                    case Frameworks.Bootstrap:
                        return Constants.BootstrapRootUrl;
                    case Frameworks.Foundation:
                        return Constants.FoundationRootUrl;
                    default:
                        return string.Empty;
                }
            }
        }
    }
}