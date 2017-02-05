using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            string action = "";
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (action != "END")
            {
                string[] inPut = Console.ReadLine().Split(' ');
                action = inPut[0];

                switch (action)
                {
                    case "A":
                        phonebook[inPut[1]] = inPut[2];
                        break;
                    case "S":
                        if (phonebook.ContainsKey(inPut[1]))
                            Console.WriteLine($"{inPut[1]} -> {phonebook[inPut[1]]}");
                        else
                            Console.WriteLine($"Contact {inPut[1]} does not exist.");
                        break;
                    case "END":
                        break;
                }
            }
        }
    }
}
