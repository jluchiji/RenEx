using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using libWyvernzora.Utilities;
using libWyvernzora.Xml;

namespace RenEx.Clone
{
    static partial class Program
    {
        private static void Scan(String directory, XmlWriter result)
        {
            using (new ActionLock(result.WriteStartDocument, result.WriteEndDocument))
            {
                using (new XmlElementActionLock(result, "renex_clone"))
                {
                    WriteDirectory(directory, result);
                }
            }
        }

        private static void WriteDirectory(String directory, XmlWriter result)
        {
            using (new XmlElementActionLock(result, "directory"))
            {
                result.WriteAttributeString("name", Path.GetFileName(directory));
                Console.WriteLine("Added DIR : {0}", Path.GetFileName(directory));

                // Write Files
                foreach (var f in Directory.GetFiles(directory))
                {
                    using (new XmlElementActionLock(result, "file"))
                    {
                        result.WriteAttributeString("name", Path.GetFileName(f));
                        Console.WriteLine("Added FILE: {0}", Path.GetFileName(f));
                    }
                }

                // Write SubDirs
                foreach (var d in Directory.GetDirectories(directory))
                    WriteDirectory(d, result);
            }
        }
    }
}
