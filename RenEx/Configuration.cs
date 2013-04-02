using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using libWyvernzora.IO;

namespace RenEx
{
    public class Configuration
    {
        #region Nested Types

        public class ExtensionConfig
        {
            public static ExtensionConfig Default
            { get { return new ExtensionConfig {Name="Default",MaximumExtensions = 2, Validator = new FileExtLengthValidator(0, 4)}; } }

            public String Name { get; set; }

            public Int32 MaximumExtensions { get; set; }

            public IFileExtValidator Validator { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        #endregion

        #region Global Stuff

        static Configuration()
        {
            Random = new Random();
        }

        public static Random Random { get; private set; }

        public static StringComparer StringComparer
        { get { return StringComparer.CurrentCultureIgnoreCase; } }

        #endregion

        #region Singleton

        private static Configuration instance;

        public static Configuration Instance
        {
            get { return instance ?? (instance = new Configuration()); }
        }

        public static void LoadConfiguration(String file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            instance = ConfigFileLoader.LoadConfiguration(doc);
        }

        #endregion

        public Configuration()
        {
            ExtensionConfigs = new Dictionary<string, ExtensionConfig>(StringComparer.InvariantCultureIgnoreCase);
            ExtensionConfigs.Add("Default", ExtensionConfig.Default);
            CurrentExtensionSettings = "Default";

            Rules = new Dictionary<string, RenamingRule>();

            RegexTemplates = new Dictionary<String, String>(StringComparer.InvariantCultureIgnoreCase);
        }

        #region Current Settings

        public String CurrentExtensionSettings { get; set; }

        public ExtensionConfig GetCurrentExtensionSettings()
        {
            return ExtensionConfigs[CurrentExtensionSettings];
        }

        #endregion

        #region Extension Analysis

        public Dictionary<String, ExtensionConfig> ExtensionConfigs 
        { get; private set; }

        #endregion

        #region Automagical Analysis

        // TODO Implement

        #endregion

        #region Saved Rules

        public Dictionary<String, RenamingRule> Rules
        { get; private set; }

        #endregion

        #region Regex Templates

        public Dictionary<String, String> RegexTemplates
        { get; private set; }

        #endregion
    }
}
