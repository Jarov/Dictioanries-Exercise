using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.UserLogs
{
    class UserLogs
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, short>> UserIPAddresses = new SortedDictionary<string, Dictionary<string, short>>();

            for (byte i = 0; i < 50; i++)
            {
                string[] inPut = Console.ReadLine().Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (inPut[0] == "end")
                {
                    Print(UserIPAddresses);
                    break;
                }

                string IP = inPut[1];
                string user = inPut[5];

                if (!UserIPAddresses.ContainsKey(user))
                {
                    UserIPAddresses[user] = new Dictionary<string, short>();
                }

                if (!UserIPAddresses[user].ContainsKey(IP))
                {
                    UserIPAddresses[user][IP] = 0;
                }

                UserIPAddresses[user][IP] += 1;
            }
        }

        static void Print(SortedDictionary<string, Dictionary<string, short>> UserIPAddresses)
        {
            foreach (KeyValuePair<string, Dictionary<string, short>> User in UserIPAddresses)
            {
                Console.WriteLine($"{User.Key}: ");
                foreach (KeyValuePair<string, short> IPAddress in UserIPAddresses[User.Key])
                {
                    Console.Write($"{IPAddress.Key} => {IPAddress.Value}");
                    if (IPAddress.Key == UserIPAddresses[User.Key].Last().Key)
                    {
                        Console.WriteLine(".");
                    }
                    else
                    {
                        Console.Write(", ");
                    }
                }
            }
        }
    }
}
