namespace testRegKey
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Win32;

    public class RegistryWorker
    {
        public string RegistryPath { get; set; }
        public RegistryKey BaseKey { get; set; }

        public RegistryWorker()
        {
            // Category = Categories.RegistryOtherSettings;
            if (null == BaseKey)
                BaseKey = Registry.LocalMachine;
        }

        public virtual void CreateKey(string path, string name)
        {
            // var key = Registry.CurrentUser.CreateSubKey(name);
            // var key = BaseKey.CreateSubKey(name);
            var pathLevels = SplitPath(path);
            // var key = BaseKey.OpenSubKey(path).CreateSubKey(name);
            var key = CreateKey(pathLevels, name);
            //key.SetValue("Name", "Isabella");
            key.Close();
        }

        public virtual RegistryKey CreateKey(IEnumerable<string> path, string name)
        {
            var currentKey = BaseKey;
            path.ToList().ForEach(pathPart => { currentKey = currentKey.CreateSubKey(pathPart); });
            currentKey.CreateSubKey(name);
            return currentKey;
        }

        private string[] SplitPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return new [] { path };
            if (!path.Contains(@"\"))
                return new[] { path };
            return path.Split('\\');
        }

        public virtual void DeleteKey(string path, string name)
        {

        }
    }
}