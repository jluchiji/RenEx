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

            // Print Prompts
            Console.WriteLine(Constants.HeadPrompt);

            if (args.Count == 0)
            {
                Console.WriteLine(Constants.UsagePrompt);
                return;
            }

            // Check Arguments
            CommandLine.Argument command = args[0];

            StringComparer comparer = StringComparer.InvariantCultureIgnoreCase;
            if (comparer.Equals(command.Name, "scan"))
            {
                String dir = args.GetOptionSrting("dir", String.Empty);
                String dump = args.GetOptionSrting("dump", "dump.xml");

                using (var writer = XmlWriter.Create(dump, new XmlWriterSettings {Indent = true}))
                {
                    Scan(dir, writer);
                    writer.Flush();
                }
            }
            else if (comparer.Equals(command.Name, "apply"))
            {
                String dir = args.GetOptionSrting("dir", String.Empty);
                String dump = args.GetOptionSrting("dump", "dump.xml");

                XDocument doc = XDocument.Parse(File.ReadAllText(dump));
                Apply(dir, doc);
            }
            else if (comparer.Equals(command.Name, "clone"))
            {
                String origin = args.GetOptionSrting("origin", "");
                String destination = args.GetOptionSrting("destination");

                if (destination == null)
                {
                    Console.Error.WriteLine("ERROR: You must specify a clone destination!");
                    return;
                }

                using (var stream = new MemoryStream())
                {
                    var writer = new XmlTextWriter(stream, Encoding.UTF8);
                    Scan(origin, writer);
                    writer.Flush();

                    stream.Position = 0;
                    var reader = new StreamReader(stream, Encoding.UTF8);
                    String xml = reader.ReadToEnd();
                    XDocument doc = XDocument.Parse(xml);
                    Apply(destination, doc);
                }

            }
            else
            {
                Console.Error.WriteLine("ERROR: RenEx.Clone could not recognize the command \"{0}\".", command.Name);
            }

        }
    }
}
