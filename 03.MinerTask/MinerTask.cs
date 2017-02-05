using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MinerTask
{
    class MinerTask
    {
        static void Main(string[] args)
        {
            string action = "";

            Dictionary<string, int> money = new Dictionary<string, int>();

            while (action != "stop")
            {
                action = Console.ReadLine();

                if (action == "stop")
                {
                    foreach (var item in money)
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    break;
                }
                else
                {
                    if (!money.ContainsKey(action))
                        money[action] = int.Parse(Console.ReadLine());
                    else
                        money[action] += int.Parse(Console.ReadLine());
                }
            }
        }
    }
}
