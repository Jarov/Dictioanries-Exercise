using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FixEmails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            string action = "";
            Dictionary<string, string> emailList = new Dictionary<string, string>();

            while (action != "stop")
            {
                action = Console.ReadLine();

                if (action == "stop")
                {
                    foreach (var contact in emailList)
                        Console.WriteLine($"{contact.Key} -> {contact.Value}");
                    break;
                }
                else
                {
                    string email = Console.ReadLine();

                    bool add = email.EndsWith("us", StringComparison.OrdinalIgnoreCase) || email.EndsWith("uk", StringComparison.OrdinalIgnoreCase);

                    if (!add)
                        emailList[action] = email;
                }
            }
        }
    }
}
