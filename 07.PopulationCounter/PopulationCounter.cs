using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PopulationCounter
{
    public class Country
    {
        public Dictionary<string, int> Cities = new Dictionary<string, int>();
        public long TotalPopulation;

        public void AddCity(string City, int CityPopulation)
        {
            Cities[City] = CityPopulation;
            TotalPopulation += CityPopulation;

        }
    }

    class PopulationCounter
    {
        static void Main()
        {
            Dictionary<string, Country> countries = new Dictionary<string, Country>();

            for (int loop = 0; ; loop++)
            {
                string[] inPut = Console.ReadLine().Split('|');

                if (inPut[0] == "report") break;

                if (!countries.ContainsKey(inPut[1]))
                    countries[inPut[1]] = new Country();

                countries[inPut[1]].AddCity(inPut[0], int.Parse(inPut[2]));
            }

            SortAndPrint(countries);
        }

        static void SortAndPrint(Dictionary<string, Country> countries)
        {
            var sortedCountries = countries.OrderByDescending(x => x.Value.TotalPopulation);

            foreach (KeyValuePair<string, Country> country in sortedCountries)
            {
                var sortedCities = country.Value.Cities.OrderByDescending(x => x.Value);
                Console.WriteLine($"{country.Key} (total population: {country.Value.TotalPopulation})");
                foreach (KeyValuePair<string, int> city in sortedCities)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
