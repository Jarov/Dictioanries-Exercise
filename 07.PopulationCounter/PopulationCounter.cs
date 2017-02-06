using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> Countries = new Dictionary<string, Dictionary<string, long>>();
            
            for (int loop = 0; ; loop++)
            {
                string[] inPut = Console.ReadLine().Split('|');

                if (inPut[0] == "report")
                {
                    foreach (var Country in Countries)
                    {
                        long Population = Countries[Country.Key].Values.Sum();

                        Console.WriteLine($"{Country.Key} (total population: {Population})");
                        foreach (var City in Countries[Country.Key])
                        {
                            Console.WriteLine($"=>{City.Key}: {Countries[Country.Key][City.Key]}");
                        }
                    }

                    break;
                }

                if (!Countries.ContainsKey(inPut[1]))
                    Countries[inPut[1]] = new Dictionary<string, long>();
                if (!Countries.ContainsKey(inPut[0]))
                    Countries[inPut[1]][inPut[0]] = 0;

                Countries[inPut[1]][inPut[0]] = long.Parse(inPut[2]);
            }
        }
    }
}
