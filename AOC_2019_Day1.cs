using System;
using System.IO;

namespace AOC_2019
{
    public class AOC_2019_Day1
    {
        int result = 0;
        public AOC_2019_Day1()
        {
            int result = 0;
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "Day1_input.txt");
            string[] values = File.ReadAllLines(path);
            Console.WriteLine(path);
            foreach (string module in values)
            {
                int weight = Convert.ToInt32(module);
                int module_fuel = CalculateFuel(weight);
                result += module_fuel;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private int CalculateFuel(int weight)
        {
            int fuel = (weight / 3) - 2;

            if (fuel <= 0) return 0;
            else
            {
                int additional_fuel = CalculateFuel(fuel);
                return fuel + additional_fuel;
            }
        }
    }
}
