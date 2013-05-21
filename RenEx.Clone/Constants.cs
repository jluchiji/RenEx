using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RenEx.Clone
{
    static class Constants
    {
        public const String HeadPrompt =
            "RenEx.Clone - RenEx Testing Utility\n" +
            "-------------------------------------------------------------------------------\n" +
            "Copyright (C) 2013 Jieni Luchijinzhou a.k.a Aragorn Wyvernzora\n";

        public const String UsagePrompt =
            "Usage:\n" +
            "\tRenEx.Clone [Command] [Arguments]\n\n" +
            "Commands:\n" +
            "\tSCAN:   Scans the directory structure and saves it to a dump file.\n" +
            "\tAPPLY:  Restores the directory structure from a sump file.\n" +
            "\tCLONE:  Scans the directory structure and makes a copy of it.\n";

    }
}
