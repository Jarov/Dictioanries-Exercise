using System;
using System.Collections.Generic;
using System.Linq;

namespace HandsOfCards
{
    class HandsOfCards
    {
        static void Main()
        {
            Dictionary<string, HashSet<string>> PlayersHands = new Dictionary<string, HashSet<string>>();
            //Речник със който пазим за всеки играч всички уникални карти които е истеглил

            for (int loop = 0; ; loop++)
            {
                string[] inPut = Console.ReadLine().Split(':');  //inPut[0] - името на играчът, inPut[1] - Картите които е истеглил

                if (inPut[0] == "JOKER") break;

                List<string> CurentHand = inPut[1].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                //прехвърляме картите които играчът е истеглил в момента в лист за да можем по лесно да ги добавим в HashSet който ще вземе само уникалните карти които играчът е истеглил 

                if (!PlayersHands.ContainsKey(inPut[0]))  //ако нямаме регистриран играч в речника създаваме HashSet от карти за играчът
                    PlayersHands[inPut[0]] = new HashSet<string>();

                foreach (string card in CurentHand)  //добавяме картите в HashSet-а който сме създали за дадения играч
                    PlayersHands[inPut[0]].Add(card);
            }

            foreach (KeyValuePair<string, HashSet<string>> player in PlayersHands)
                Console.WriteLine($"{player.Key}: {CalculateScore(player.Value)}");
            //player.Key - името на играчът, player.Value - HashSet от всички карти които е взел
            //вместо да правим новa променлива която да пази името на играча и неговият резултат директно принтираме резултата без да го пазим (грешен подход ако се изисква после да се правят други неща със резултата)
        }

        static int CalculateScore(HashSet<string> Cards)
        {
            int sum = 0;

            foreach (string card in Cards)
            {
                byte power = 0;
                switch (card.Substring(0, card.Length - 1)) //Taking the power of the current card
                {
                    case "2": power = 2; break;
                    case "3": power = 3; break;
                    case "4": power = 4; break;
                    case "5": power = 5; break;
                    case "6": power = 6; break;
                    case "7": power = 7; break;
                    case "8": power = 8; break;
                    case "9": power = 9; break;
                    case "10": power = 10; break;
                    case "J": power = 11; break; //Jack
                    case "Q": power = 12; break; //Queen
                    case "K": power = 13; break; //King
                    case "A": power = 14; break; //Ace
                }

                byte type = 0;

                switch (card.Substring(card.Length - 1))  //Taking the type of the current card
                {
                    case "S": type = 4; break; //Spades
                    case "H": type = 3; break; //Hearths
                    case "D": type = 2; break; //Diamonds 
                    case "C": type = 1; break; //Clubs
                }

                sum += power * type;
            }

            return sum;
        }
    }
}