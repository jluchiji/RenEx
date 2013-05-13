// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// RenEx/RenamingRuleCollection.cs
// --------------------------------------------------------------------------------
// Copyright (c) 2013, Jieni Luchijinzhou a.k.a Aragorn Wyvernzora
// 
// This file is a part of RenEx.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal 
// in the Software without restriction, including without limitation the rights 
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
// of the Software, and to permit persons to whom the Software is furnished to do 
// so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using libWyvernzora.IO;

namespace RenEx
{
    /// <summary>
    ///     Collection of renaming rules.
    /// </summary>
    public class RenamingRuleCollection
    {
        public RenamingRuleCollection()
        {
            DirectoryRules = new List<RenamingRule>();
            NameRules = new List<RenamingRule>();
            ExtensionRules = new List<RenamingRule>();
        }

        // Renaming Rules
        /// <summary>
        ///     Gets the list of renaming rules applied to directory components of the file paths.
        /// </summary>
        public List<RenamingRule> DirectoryRules { get; private set; }

        /// <summary>
        ///     Gets the list of renaming rules applied to file name components of the file paths.
        /// </summary>
        public List<RenamingRule> NameRules { get; private set; }

        /// <summary>
        ///     Gets the list of renaming rules applied to file extension components of the file paths.
        /// </summary>
        public List<RenamingRule> ExtensionRules { get; private set; }

        /// <summary>
        /// Adds a rule to the collection.
        /// </summary>
        /// <param name="rule"></param>
        public void AddRule(RenamingRule rule)
        {
            rule.Active = true;

            switch (rule.Type)
            {
                case RenamingRule.RuleType.Name:
                        NameRules.Add(rule);
                    break;
                case RenamingRule.RuleType.Extension:
                        ExtensionRules.Add(rule);
                    break;
                case RenamingRule.RuleType.Directory:
                        DirectoryRules.Add(rule);
                    break;
            }
        }

        /// <summary>
        ///     Transforms single file name descriptor according to the set of rules.
        /// </summary>
        /// <param name="fd">Original file name descriptor.</param>
        /// <param name=""></param>
        /// <returns></returns>
        public RenExFileNameDescriptor TransformSingle(FileNameDescriptor fd)
        {
            // Create a copy of the old file name descriptor
            RenExFileNameDescriptor newFd = new RenExFileNameDescriptor
                {
                    Directory = fd.Directory,
                    FileName = fd.FileName,
                    Extensions = fd.Extensions
                };

            try
            {
                // Run name rules
                foreach (RenamingRule rule in NameRules.Where(r => r.Active))
                {
                    Match match = Regex.Match(fd.FileName, rule.RegularExpression, RegexOptions.IgnoreCase);
                    if (!match.Success) continue;

                    if (rule.DeleteFile)
                        newFd.MarkForDelete = true;
                    else
                        newFd.FileName = match.Result(rule.ReplacementExpression);

                    break;
                }

                // Run Extension Rules
                foreach (RenamingRule rule in ExtensionRules.Where(r => r.Active))
                {
                    Match match = Regex.Match(fd.Extensions, rule.RegularExpression, RegexOptions.IgnoreCase);
                    if (!match.Success) continue;

                    if (rule.DeleteFile)
                        newFd.MarkForDelete = true;
                    else
                        newFd.Extensions = match.Result(rule.ReplacementExpression);

                    break;
                }

                // Run Directory Rules
                foreach (RenamingRule rule in DirectoryRules.Where(r => r.Active))
                {
                    Match match = Regex.Match(fd.Directory, rule.RegularExpression, RegexOptions.IgnoreCase);
                    if (!match.Success) continue;

                    if (rule.DeleteFile)
                        newFd.MarkForDelete = true;
                    else
                        newFd.Directory = match.Result(rule.ReplacementExpression);

                    break;
                }

                return newFd;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}