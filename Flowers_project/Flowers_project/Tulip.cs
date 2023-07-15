﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers_project
{
    internal class Tulip : BaseFlower
    {
        public Tulip(string name, int length, int freshness, double cost, string color, string formOfTurnip) : base(name, length, freshness, cost, color)
        {
            this.formOfTurnip = formOfTurnip;
            this.strForFile += "~" + formOfTurnip;
        }

        private readonly string formOfTurnip;
        public string getFormOfTurnip() { return formOfTurnip; }

        public override string toStringForConsole()
        {
            return base.toStringForConsole() + "\nForm of turnip: " + formOfTurnip + "\n";
        }

        public override void Write(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(strForFile);
            writer.Close();
        }
    }
}