using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.LogsAggregator
{
    class LogsAggregator
    {
        static void Main()
        {
            short LogsCount = short.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, int>> logs = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (short i = 0; i < LogsCount; i++)
            {
                string[] currentLog = Console.ReadLine().Split(' ');

                if (!logs.ContainsKey(currentLog[1]))
                    logs[currentLog[1]] = new SortedDictionary<string, int>();

                if (!logs[currentLog[1]].ContainsKey(currentLog[0]))
                    logs[currentLog[1]][currentLog[0]] = 0;

                logs[currentLog[1]][currentLog[0]] += short.Parse(currentLog[2]);
            }

            foreach (KeyValuePair<string, SortedDictionary<string, int>> log in logs)
            {
                Console.WriteLine($"{log.Key}: {log.Value.Values.Sum()} [{string.Join(", ", log.Value.Keys)}]");
            }
        }
    }
}
