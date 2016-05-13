namespace CommonTestAccessLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Threading;

    public class AccessChecker
    {
        FileSystemDriver _driver;
        string _basePath;
        const string fileNamePrefix = "file_";
        const string dirNamePrefix = "dir_";
        const int sleepInterval = 1200;
        StreamWriter _writer;

        public AccessChecker(string basePath)
        {
            _driver = new FileSystemDriver();
            _basePath = basePath;
            AccountName = "NT AUTHORITY\\SELF";
        }

        public string AccountName { get; set; }

        public void TestAccess(string path)
        {
            _writer.WriteLine(_driver.ReadFile(path));
            Thread.Sleep(sleepInterval);
            _writer.WriteLine(_driver.WriteToFile(path));
            Thread.Sleep(sleepInterval);
            _writer.WriteLine(_driver.ChangePermissionsOfFile(path));
            Thread.Sleep(sleepInterval);
            _writer.WriteLine(_driver.DeleteFile(path));
            Thread.Sleep(sleepInterval);
        }

        public void RunGeneration()
        {
            var fileSystemRights = Enum.GetValues(typeof (FileSystemRights));
            fileSystemRights.Cast<FileSystemRights>().ToList().ForEach(right =>
            {
                var filePath = _basePath + @"\" + fileNamePrefix + right;
                var dirPath = _basePath + @"\" + dirNamePrefix + right;
                _driver.CreateFile(filePath);
                _driver.SetPermission(filePath, AccountName, right);
                _driver.CreateDirectory(dirPath);
                _driver.CreateFile(dirPath + @"\" + fileNamePrefix);
                _driver.SetPermissionWithInheritance(dirPath, AccountName, right);
            });
        }

        public void RunTest()
        {
            var filePathsList = new List<string>();
            filePathsList.AddRange(GetFilePathsFromDirectory(_basePath));
            _writer = new StreamWriter(@".\my.log");
            _writer.AutoFlush = true;
            filePathsList.ForEach(TestAccess);
            _writer.Close();
        }

        IEnumerable<string> GetFilePathsFromDirectory(string path)
        {
            var files = new List<string>();
            files.AddRange(Directory.GetFiles(path));
            files.AddRange(Directory.GetDirectories(path).ToList().SelectMany(Directory.GetFiles));
            return files;
        }
    }
}