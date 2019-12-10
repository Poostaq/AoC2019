using System;
using System.IO;
using System.Collections.Generic;

namespace AOC_2019
{
    public class AOC_2019_Day6
    {
        List<Tuple<string, string>> orbiters;
        public AOC_2019_Day6()
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "Day6_input.txt");
            this.orbiters = new List<Tuple<string, string>>();
            int orbits_count = 0;
            foreach (var line in File.ReadLines(path))
            {
                string[] object_orbiter = line.Split(')');
                orbiters.Add(Tuple.Create(object_orbiter[0], object_orbiter[1]));
            }
            //DAY 6 FIRST PART
            for (int x = 0; x < orbiters.Count; x++)
            {
                orbits_count += find_total_orbits(orbiters[x].Item2);
            }
            Console.WriteLine(orbits_count);

            //DAY 6 SECOND PART
            Console.WriteLine(find_total_orbit_jups_to_SAN());
        }

        private int find_total_orbits(string name)
        {
            var current_check = name;
            int result = 0;
            bool found_center = false;
            while (found_center != true)
            {
                for (int y = 0; y < orbiters.Count; y++)
                {
                    if (orbiters[y].Item2 == current_check)
                    {
                        result += 1;
                        if (orbiters[y].Item1 == "COM")
                        {
                            found_center = true;
                        }
                        else
                        {
                            current_check = orbiters[y].Item1;
                        }
                        break;
                    }
                }
            }
            return result;
        }

        private Tuple<int, List<string>> find_total_orbits_and_list_of_jumps(string name)
        {

            List<string> visited_places = new List<string>();
            var current_check = name;
            int result = 0;
            bool found_center = false;
            while (found_center != true)
            {
                for (int y = 0; y < orbiters.Count; y++)
                {
                    if (orbiters[y].Item2 == current_check)
                    {
                        result += 1;
                        visited_places.Insert(0, orbiters[y].Item1);
                        if (orbiters[y].Item1 == "COM")
                        {
                            found_center = true;
                        }
                        else
                        {
                            current_check = orbiters[y].Item1;
                        }
                        break;
                    }
                }
            }
            return Tuple.Create(result, visited_places);
        }

        private int find_total_orbit_jups_to_SAN()
        {
            int result = 0;
            Tuple <int, List<string>> you = find_total_orbits_and_list_of_jumps("YOU");
            Tuple<int, List<string>> san = find_total_orbits_and_list_of_jumps("SAN");


            for (int x = 0; x < 2000; x++)
            {
                if (you.Item2[x] != san.Item2[x])
                {
                    result = you.Item1 - x + san.Item1 - x;
                    break;
                }
            }
            return result;
        }


    }
}
