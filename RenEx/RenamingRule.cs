using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RenEx
{
    public class RenamingRule
    {
        public enum RuleType
        {
            Directory,
            Name,
            Extension
        }

        public String Name { get; set; }

        public RuleType Type { get; set; }

        public String RegularExpression { get; set; }

        public String ReplacementExpression { get; set; }

        public Boolean DeleteFile { get; set; }

        public Boolean Active { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
