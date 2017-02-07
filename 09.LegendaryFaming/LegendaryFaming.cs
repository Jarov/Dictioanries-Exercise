using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.LegendaryFaming
{
    class LegendaryFaming
    {
        static void Main()
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();

            keyMaterials["motes"] = 0;
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;

            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

            for (byte i = 0; ; i++)
            {
                string[] inPut = Console.ReadLine().ToLower().Split(' ');

                bool Break = false;

                for (int index = 1; index < inPut.Length; index += 2)
                {
                    if (inPut[index] == "motes" || inPut[index] == "shards" || inPut[index] == "fragments")
                    {
                        keyMaterials[inPut[index]] += int.Parse(inPut[index - 1]);
                        if (keyMaterials["motes"] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            keyMaterials["motes"] -= 250;
                            SortAndPrint(keyMaterials, junk);
                            Break = true;
                            break;
                        }
                        if (keyMaterials["shards"] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            keyMaterials["shards"] -= 250;
                            SortAndPrint(keyMaterials, junk);
                            Break = true;
                            break;
                        }
                        if (keyMaterials["fragments"] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            keyMaterials["fragments"] -= 250;
                            SortAndPrint(keyMaterials, junk);
                            Break = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(inPut[index]))
                            junk[inPut[index]] = 0;
                        junk[inPut[index]] += int.Parse(inPut[index - 1]);
                    }
                }

                if (Break) break;
            }
        }

        static void SortAndPrint(Dictionary<string, int> keyMaterials, SortedDictionary<string, int> junk)
        {
            var SortedKeyMaterials = keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (KeyValuePair<string, int> material in SortedKeyMaterials)
                Console.WriteLine($"{material.Key}: {material.Value}");
            foreach (KeyValuePair<string, int> item in junk)
                Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
