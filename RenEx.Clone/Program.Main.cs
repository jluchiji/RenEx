using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using libWyvernzora.Core;
using libWyvernzora.Utilities;

namespace RenEx.Clone
{
    static partial class Program
    {
        static void Main()
        {
            // Command Line Arguments
            CommandLine args = new CommandLine();

            // Test
            String dir = @"\\192.168.2.9\Anime";
            XmlWriter xw = XmlWriter.Create(
                "dump.xml",
                new XmlWriterSettings {Indent = true});

            Scan(dir, xw);

            xw.Close();

            String xml = File.ReadAllText("dump.xml");
            XDocument doc = XDocument.Parse(xml);
            

            Apply("debug_apply", doc);
        }
    }
}
