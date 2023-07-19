using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers_project
{
    internal class Camomile : BaseFlower
    {
        public Camomile(string name, int length, int freshness, double cost, string color, int countOfPetal) : base(name, length, freshness, cost, color)
        {
            this.countOfPetal = countOfPetal;
            type = "camomile";
            //_ = strForFile.Insert(0, type);
            //this.strForFile += "~" + countOfPetal.ToString();
        }

        private readonly int countOfPetal;
        public int getCountOfPetal() { return countOfPetal; }

        public override string toStringForConsole()
        {
            return base.toStringForConsole() + "\nCount of petal: " + countOfPetal.ToString() + "\n";
        }

        public override string toStringForFile()
        {
            return type + "~" + base.toStringForFile() + "~" + countOfPetal.ToString();
        }

        public override void Write(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(this.toStringForFile());
            writer.Close();
        }
    }
}
