using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers_project
{
    internal class Rose : BaseFlower
    {
        private readonly int lengthOfPrickles;
        public Rose(string name, int length, int freshness, double cost, string color, int lengthOfPrickles) : base(name, length, freshness, cost, color)
        {
            this.lengthOfPrickles = lengthOfPrickles;
            this.strForFile += "~" + lengthOfPrickles.ToString();
        }

        public int getLengthOfPrickles() { return lengthOfPrickles; }
        public override string toStringForConsole()
        {
            return base.toStringForConsole() + "\nLength of Prickles (mm): " + lengthOfPrickles.ToString() + "\n";
        }
        public override void Write(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(strForFile);
            writer.Close();
        }
    }
}
