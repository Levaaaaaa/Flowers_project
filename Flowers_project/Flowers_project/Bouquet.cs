using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers_project
{
    internal class Bouquet
    {
        public Bouquet(BaseFlower[] bouquet) 
        {
            this.bouquet = bouquet.ToList();
        }

        public Bouquet(List<BaseFlower> bouquet)
        {
            this.bouquet = bouquet;
        }

        private List<BaseFlower> bouquet;
        public BaseFlower[] getBouquet() { return bouquet.ToArray(); }
        public double getCostOfBouquet()
        {
            double cost = 0;
            foreach (BaseFlower flower in bouquet)
            {
                cost += flower.getCost();
            }

            return Math.Round(cost * 100) / 100;
        }

        public void Print()
        {
            Console.WriteLine("\n");
            foreach (BaseFlower flower in bouquet)
            {
                Console.Write(flower.toStringForConsole() + "\n");
            }
        }

        public void Write(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (BaseFlower flower in bouquet)
            {
                writer.WriteLine(flower.getStrForFile());
            }
            writer.Close();
        }

        public Bouquet findFlowerByLength(int min, int max)
        {
            List<BaseFlower> result = new List<BaseFlower>();
            foreach (BaseFlower flower in bouquet)
            {
                if ((flower.getLength() >= min) && (flower.getLength() <= max))
                {
                    result.Add(flower);
                }
            }

            return new Bouquet(result);
        }
    }
}
