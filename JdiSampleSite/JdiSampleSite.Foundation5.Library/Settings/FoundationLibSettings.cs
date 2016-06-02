namespace JdiSampleSite.Foundation5.Library.Settings
{
    using Common.Library;
    using Common.Library.Abstract;
    public class FoundationLibSettings : ILibrarySettings
    {
        public void Apply()
        {
            Path = new FrameworkPath(Frameworks.Foundation);
        }

        public static FrameworkPath Path { get; set; }
    }
}