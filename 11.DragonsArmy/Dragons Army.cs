using System;
using System.Collections.Generic;

namespace Dragons_Army
{
    class StatsOfDragons
    {
        public int Damage;
        public int Health;
        public int Armor;
        
        public StatsOfDragons(string dmg, string hp, string ar)
        {
            if (dmg == "null")
                Damage = 45;
            else
                Damage = int.Parse(dmg);
            if (hp == "null")
                Health = 250;
            else
                Health = int.Parse(hp);
            if (ar == "null")
                Armor = 10;
            else
                Armor = int.Parse(ar);
        }
        
    }

    class Dragons_Army
    {
        static void Main()
        {
            byte NumberOfDragons = byte.Parse(Console.ReadLine());

            Dictionary<string, SortedDictionary<string, StatsOfDragons>> Dragons = new Dictionary<string, SortedDictionary<string, StatsOfDragons>>();

            InsertTheDragons(Dragons, NumberOfDragons);

            foreach (string type in Dragons.Keys)
            {
                double armor = 0;
                double health = 0;
                double damage = 0;

                foreach (string name in Dragons[type].Keys)
                {
                    armor += Dragons[type][name].Armor;
                    health += Dragons[type][name].Health;
                    damage += Dragons[type][name].Damage;
                }

                armor = armor / Dragons[type].Count;
                health = health / Dragons[type].Count;
                damage = damage / Dragons[type].Count;

                Console.WriteLine($"{type}::({damage.ToString("0.00")}/{health.ToString("0.00")}/{armor.ToString("0.00")})");
                foreach (string name in Dragons[type].Keys)
                {
                    Console.WriteLine($"-{name} -> damage: {Dragons[type][name].Damage}, health: {Dragons[type][name].Health}, armor: {Dragons[type][name].Armor}");
                }                    
            }
        }

        static void InsertTheDragons(Dictionary<string, SortedDictionary<string, StatsOfDragons>> Dragons, int NumberOfDragons)
        {
            for (int i = 0; i < NumberOfDragons; i++)
            {
                string[] inPut = Console.ReadLine().Split(' ');

                if (!Dragons.ContainsKey(inPut[0]))
                {
                    Dragons[inPut[0]] = new SortedDictionary<string, StatsOfDragons>();
                }
                Dragons[inPut[0]][inPut[1]] = new StatsOfDragons(inPut[2], inPut[3], inPut[4]);
            }
        }
    }
}
