using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Flowers_project
{
    internal abstract class BaseFlower
    {
        private readonly string name;
        private readonly int length;
        private readonly int freshness;
        private readonly double cost;
        private readonly string color;
        protected string strForFile;

        public BaseFlower(string name, int length, int freshness, double cost, string color) 
        {
            this.name = name;
            this.length = length;
            this.freshness = freshness;
            this.cost = cost;
            this.color = color;
            strForFile = name + "~" + length.ToString() + "~" + freshness.ToString() + "~" + cost.ToString() + "~" + color;
        }

        public string getName() { return name; }
        public int getLength() { return length; }
        public int getFreshness() { return freshness; }
        public double getCost() { return cost; }
        public string getColor() { return color; }
        public string getStrForFile() { return strForFile; }
        public virtual string toStringForConsole()
        {
            return "Name: " + name + "\nLength (cm): " + length.ToString() + "\nFreshness (1-10): " + freshness + "\nCost(BY): " + cost.ToString() + "\nColor: " + color;
        }
        public abstract void Write(string path);
    }
}
