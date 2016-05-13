namespace testFileAttrs
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            var rootPath = @".\";
            SetAttribute(rootPath + "ro.txt", FileAttributes.ReadOnly);
            SetAttribute(rootPath + "arc.txt", FileAttributes.Archive);

            SetAttribute(rootPath + "comp.txt", FileAttributes.Compressed);
            SetAttribute(rootPath + "dev.txt", FileAttributes.Device);
            SetAttribute(rootPath + "dir.txt", FileAttributes.Directory);
            SetAttribute(rootPath + "enc.txt", FileAttributes.Encrypted);
            SetAttribute(rootPath + "h.txt", FileAttributes.Hidden);
            SetAttribute(rootPath + "int.txt", FileAttributes.IntegrityStream);
            SetAttribute(rootPath + "norm.txt", FileAttributes.Normal);
            SetAttribute(rootPath + "noScrub.txt", FileAttributes.NoScrubData);

            SetAttribute(rootPath + "ind.txt", FileAttributes.NotContentIndexed);
            SetAttribute(rootPath + "off.txt", FileAttributes.Offline);
            SetAttribute(rootPath + "rep.txt", FileAttributes.ReparsePoint);
            SetAttribute(rootPath + "spa.txt", FileAttributes.SparseFile);
            SetAttribute(rootPath + "s.txt", FileAttributes.System);
            SetAttribute(rootPath + "temp.txt", FileAttributes.Temporary);
        }

        static void SetAttribute(string path, FileAttributes attribute)
        {
            File.Create(path);
            var attributes = File.GetAttributes(path);
            attributes |= attribute;
            File.SetAttributes(path, attributes);
        }
    }
}
