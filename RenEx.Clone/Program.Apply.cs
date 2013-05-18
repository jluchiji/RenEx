using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RenEx.Clone
{
    static partial class Program
    {
        // Restores the dir dump into a parent directory
        private static void Apply(String parentdir, XDocument dump)
        {
            XElement dir = dump.XPathSelectElement("renex_clone/directory");
            ApplyDir(dir, parentdir);
        }

        private static void ApplyDir(XElement dirElement, String path)
        {
            path = Path.Combine(path, dirElement.Attribute("name").Value);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            foreach (var file in dirElement.XPathSelectElements("file"))
                File.Create(Path.Combine(path, file.Attribute("name").Value)).Close();

            foreach (var dir in dirElement.XPathSelectElements("directory"))
                ApplyDir(dir, path);
        }
    }
}
