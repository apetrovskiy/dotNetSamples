namespace CommonTestAccessLibrary
{
    using System;
    using System.IO;
    using System.Security.AccessControl;
    using System.Text;

    public class FileSystemDriver
    {
        public void CreateFile(string path)
        {
            using (var fileStream = File.Create(path))
            {
                var content = new UTF8Encoding(true).GetBytes("aaa");
                fileStream.Write(content, 0, content.Length);
            }
            Console.WriteLine("CreateFile {0}", path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
            Console.WriteLine("CreateDirectory {0}", path);
        }

        public void SetPermission(string path, string accountName, FileSystemRights fileSystemRights)
        {
            try
            {
                var rule = new FileSystemAccessRule(accountName, fileSystemRights, AccessControlType.Deny);
                var fileSecurity = File.GetAccessControl(path);
                fileSecurity.AddAccessRule(rule);
                File.SetAccessControl(path, fileSecurity);
                Console.WriteLine("SetPermission {0} to {1}", fileSystemRights, path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read file {0} with error {1}", path, e.Message);
            }
        }

        public void SetPermissionWithInheritance(string path, string accountName, FileSystemRights fileSystemRights)
        {
            try
            {
                var rule = new FileSystemAccessRule(accountName, fileSystemRights, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly,  AccessControlType.Deny);
                var directorySecurity = Directory.GetAccessControl(path);
                directorySecurity.AddAccessRule(rule);
                Directory.SetAccessControl(path, directorySecurity);
                Console.WriteLine("SetPermission {0} to {1}", fileSystemRights, path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read file {0} with error {1}", path, e.Message);
            }
        }

        public string ReadFile(string path)
        {
            try
            {
                File.ReadAllBytes(path);
                // return string.Format("ReadFile {0} {1}", path, DateTime.Now);
                return string.Empty;
            }
            catch (Exception e)
            {
                return string.Format("Failed to read file {0} with error {1} {2} {3}", path, e.Message, e.GetType().Name, DateTime.Now);
            }
        }

        public string WriteToFile(string path)
        {
            try
            {
                File.WriteAllText(path, "aaa");
                // return string.Format("WriteToFile {0} {1}", path, DateTime.Now);
                return string.Empty;
            }
            catch (Exception e)
            {
                return string.Format("Failed to write to file {0} with error {1} {2} {3}", path, e.Message, e.GetType().Name, DateTime.Now);
            }
        }

        public string ChangePermissionsOfFile(string path)
        {
            try
            {
                var rule = new FileSystemAccessRule("S-1-5-7", // FileSystemRights.Synchronize,
                    FileSystemRights.Read,
                    AccessControlType.Allow);
                var fileSecurity = File.GetAccessControl(path);
                fileSecurity.AddAccessRule(rule);
                File.SetAccessControl(path, fileSecurity);
                // return string.Format("ChangePermissionsOfFile {0} {1}", path, DateTime.Now);
                return string.Empty;
            }
            catch (Exception e)
            {
                return string.Format("Failed to set permission to file {0} with error {1} {2} {3}", path, e.Message, e.GetType().Name, DateTime.Now);
            }
        }

        public string DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
                // return string.Format("DeleteFile {0} {1}", path, DateTime.Now);
                return string.Empty;
            }
            catch (Exception e)
            {
                return string.Format("Failed to delete file {0} with error {1} {2} {3}", path, e.Message, e.GetType().Name, DateTime.Now);
            }
        }
    }
}