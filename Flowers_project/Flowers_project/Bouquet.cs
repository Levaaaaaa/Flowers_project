using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers_project
{
    internal class Bouquet
    {
        public Bouquet(string path)
        {
            bouquet = Read(path);
        }
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
                writer.WriteLine(flower.toStringForFile());
            }
            writer.Close();
        }

        private static List<BaseFlower> Read(string path)
        {
            StreamReader reader = new StreamReader(path);
            List<BaseFlower> bouquet = new List<BaseFlower>();
            string[] all = reader.ReadToEnd().Split('\n');
            all = all.SkipLast(1).ToArray();
            string[] line;
            //while (!reader.EndOfStream)
            foreach(string str in all)
            {
                line = str.Split('~');
                switch (line[0])
                {
                    case "rose":
                        bouquet.Add(new Rose(line[1], Convert.ToInt32(line[2]), Convert.ToInt32(line[3]), Convert.ToDouble(line[4]), line[5], Convert.ToInt32(line[6])));
                        break;
                    case "tulip":
                        bouquet.Add(new Tulip(line[1], Convert.ToInt32(line[2]), Convert.ToInt32(line[3]), Convert.ToDouble(line[4]), line[5], line[6]));
                        break;
                    case "camomile":
                        bouquet.Add(new Camomile(line[1], Convert.ToInt32(line[2]), Convert.ToInt32(line[3]), Convert.ToDouble(line[4]), line[5], Convert.ToInt32(line[6])));
                        break;
                    default:
                        throw new InvalidDataException();
                }
            }

            return bouquet;//new Bouquet(bouquet);
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

            if (result.ToArray().Length == 0)
            {
                throw new InvalidDataException();

            }
            return new Bouquet(result);
        }

        public Bouquet sortByFreshness(bool ascending)
        {
            BaseFlower[] array = this.bouquet.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if ((ascending && (array[i].getFreshness() > array[j].getFreshness())) || (!ascending && (array[i].getFreshness() < array[j].getFreshness())))
                    {
                        BaseFlower buff = array[i];
                        array[i] = array[j];
                        array[j] = buff;
                    }
                }
            }

            return new Bouquet(array.ToList<BaseFlower>());
            //return array;
        }
        /*
        public void PrintSortedArray(BaseFlower[] array)
        {)
        }
        */
    }
}
