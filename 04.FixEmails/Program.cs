using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FixEmails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emailList = new Dictionary<string, string>();

            for (int i = 0; ; i++)
            {
                string inPut = Console.ReadLine();

                if (inPut == "stop")
                {
                    foreach (var contact in emailList)
                        Console.WriteLine($"{contact.Key} -> {contact.Value}");
                    break;
                }

                string email = Console.ReadLine();

                bool add = email.EndsWith(".us", StringComparison.OrdinalIgnoreCase) || email.EndsWith(".uk", StringComparison.OrdinalIgnoreCase);

                if (!add)
                    emailList[inPut] = email;
            }
        }
    }
}
