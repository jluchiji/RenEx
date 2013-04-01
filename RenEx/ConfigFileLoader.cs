using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using libWyvernzora.IO;
using libWyvernzora.Utilities;
using libWyvernzora.Xml;

// ReSharper disable PossibleNullReferenceException
namespace RenEx
{
    public static class ConfigFileLoader
    {
        public static RenamingRule ReadRule(XmlNode ruleNode)
        {
            if (ruleNode.Name != "Rule") throw new ArgumentException();

            RenamingRule rule = new RenamingRule();
            rule.Name = ruleNode.Attributes["name"].InnerText;
            rule.RegularExpression = ruleNode.SelectSingleNode("RegExp").InnerText;
            rule.ReplacementExpression = ruleNode.SelectSingleNode("RepExp").InnerText;
            rule.Type = (RenamingRule.RuleType) Int32.Parse(ruleNode.Attributes["type"].InnerText);

            return rule;
        }

        public static Configuration LoadConfiguration(XmlDocument doc)
        {
            var config = new Configuration();
            
            // Load Extension Configurations
            foreach (XmlNode node in doc.SelectNodes("RenExConfig/ExtensionConfig"))
            {
                Configuration.ExtensionConfig extCfg = new Configuration.ExtensionConfig
                    {
                        Name = node.Attributes["name"].InnerText,
                        MaximumExtensions = Int32.Parse(node.Attributes["maxExt"].InnerText)
                    };

                XmlNode validatorNode = node.SelectSingleNode("FileExtLenValidator");
                if (validatorNode != null)
                {
                    extCfg.Validator = new FileExtLengthValidator(
                        Int32.Parse(validatorNode.Attributes["min"].InnerText),
                        Int32.Parse(validatorNode.Attributes["max"].InnerText));
                }
                validatorNode = node.SelectSingleNode("FileExtListValidator");
                if (validatorNode != null)
                {
                    String[] exts = validatorNode.InnerText.Split(';');
                    for (int i = 0; i < exts.Length; i++)
                        exts[i] = exts[i].Trim(' ');

                    extCfg.Validator = new FileExtListValidator(exts);
                }

                config.ExtensionConfigs[extCfg.Name] = extCfg;
            }


            // Load Saved Rules
            foreach (RenamingRule rule in from XmlNode node in doc.SelectNodes("RenExConfig/Rule") select ReadRule(node))
            {
                config.Rules[rule.Name] = rule;
            }

            // Load Regex Templates
            foreach (XmlNode node in doc.SelectNodes("RenExConfig/RegexTemplate"))
            {
                String name = node.Attributes["name"].InnerText;
                String template = node.InnerText;

                config.RegexTemplates[name] = template;
            }

            return config;
        }
    
        public static void SaveConfiguration(Configuration cfg, XmlWriter writer)
        {
            writer.WriteStartDocument();

            using (new XmlElementActionLock(writer, "RenExConfig"))
            {
                // Write Extension Configs
                foreach (var extcfg in cfg.ExtensionConfigs.Values)
                {
                    using (new XmlElementActionLock(writer, "ExtensionConfig"))
                    {
                        writer.WriteAttributeString("name", extcfg.Name);
                        writer.WriteAttributeString("maxExt", extcfg.MaximumExtensions.ToString(CultureInfo.InvariantCulture));

                        if (extcfg.Validator is FileExtLengthValidator)
                        {
                            var validator = (FileExtLengthValidator) extcfg.Validator;
                            using (new XmlElementActionLock(writer, "FileExtLenValidator"))
                            {
                                writer.WriteAttributeString("min",
                                                            validator.MinimumLength.ToString(
                                                                CultureInfo.InvariantCulture));
                                writer.WriteAttributeString("max",
                                                            validator.MaximumLength.ToString(
                                                                CultureInfo.InvariantCulture));
                            }
                        }
                        else
                        {
                            var validator = (FileExtListValidator)extcfg.Validator;
                            using (new XmlElementActionLock(writer, "FileExtListValidator"))
                            {
                                writer.WriteString(String.Join(";", validator.Extensions));
                            }
                        }
                    }
                }

                // Write Rules
                foreach (var rule in cfg.Rules.Values)
                {
                    using (new XmlElementActionLock(writer, "Rule"))
                    {
                        writer.WriteAttributeString("name", rule.Name);
                        writer.WriteAttributeString("type", ((Int32)rule.Type).ToString(CultureInfo.InvariantCulture));
                        writer.WriteElementString("RegExp", rule.RegularExpression);
                        writer.WriteElementString("RepExp", rule.ReplacementExpression);
                    }
                }

                // Write Regex Templates
                foreach (var v in cfg.RegexTemplates)
                {
                    using (new XmlElementActionLock(writer, "RegexTemplate"))
                    {
                        writer.WriteAttributeString("name", v.Key);
                        writer.WriteString(v.Value);
                    }
                }
            }
        }
    }
}
