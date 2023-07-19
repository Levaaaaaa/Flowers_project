﻿// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Flowers_project;

int choose = -1;
/*Rose rose = new Rose("rose", 20, 8, 5.0, "red", 4);
Tulip tulip = new Tulip("tulip", 12, 5, 7.0, "pink", "oval");
Camomile camomile = new Camomile("beautiful camomile", 5, 10, 0.05, "white", 10);
Bouquet bouquet = new Bouquet(new BaseFlower[] {rose, tulip, camomile});*/
//Bouquet bouquet = new Bouquet(new List<BaseFlower>());
const string space = "\n---------------------------------\n";
const string menu = "Choose the operation:\n1. Get cost of bouquet\n2. Print bouquet\n3. Find flower by length\n4. Sort by freshness\n0. Exit";
const string path = "..\\flowers.txt";
//bouquet.Write(path);
Bouquet bouquet = new Bouquet(path);

while (choose != 0)
{
    Console.WriteLine(space + menu + space);
    try
    {
        choose = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException)
    {
        choose = -1;
        Console.WriteLine("\nUncorrect choose\n");
        continue;
    }
    Console.WriteLine("\n");
    switch (choose)
    {
        case 1:
            Console.WriteLine("The cost of current bouquet is " + bouquet.getCostOfBouquet() + "\n");
            break;
        case 2:
            bouquet.Print();
            break;
        case 3:
            int min, max;
            Console.WriteLine("Input min value ");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input max value ");
            max = Convert.ToInt32(Console.ReadLine());
            try
            {
                bouquet.findFlowerByLength(min, max).Print();
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("In this bouquet aren't flowers of this range");
            }
            break;
        case 4:
            bouquet.sortByFreshness(true).Print();
            break;
/*        case 5:
            try
            {
                bouquet.Read(path);
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Invalid data in the readed file");
            }
            break;*/
    }
}