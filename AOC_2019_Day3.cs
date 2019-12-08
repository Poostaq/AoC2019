using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC_2019
{
    public class AOC_2019_Day3
    {
        public AOC_2019_Day3()
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "Day3_input.txt");
            List<string> text = File.ReadLines(path).ToList();
            string[] wire_a_directions = text[0].Split(',');
            string[] wire_b_directions = text[1].Split(',');
            List<Tuple<int, int, int>> wire_a_coords = check_all_visited_coords(wire_a_directions);
            List<Tuple<int, int, int>> wire_b_coords = check_all_visited_coords(wire_b_directions);
            //List<Tuple<int, int, int>> results = find_crossing_points(wire_a_coords, wire_b_coords);
            //int result = find_closest_point_manhattan_distance(results);
            int result = find_shortest_cable_crossing_point(wire_a_coords, wire_b_coords);
            Console.WriteLine(result);
        }

        List<Tuple<int, int, int>> check_all_visited_coords(string[] directions)
        {
            int x = 0;
            int y = 0;
            int z = 0;

            List<Tuple<int, int, int>> result_coords = new List<Tuple<int, int, int>>();

            for(int i = 0; i < directions.Length; i++)
            {
                string direction = directions[i].Substring(0,1);
                int steps = Convert.ToInt32(directions[i].Substring(1));
                Console.WriteLine(steps);
                switch (direction)
                {
                    
                    case "R":
                        for(int k = 0; k < steps; k++)
                        {
                            x++;
                            z++;
                            result_coords.Add(Tuple.Create(x, y, z));
                            Console.WriteLine("Right: +" + x + " " + y + " steps: " + z);
                        }
                        break;
                    case "L":
                        for(int k = 0; k < steps; k++)
                        {
                            x--;
                            z++;
                            result_coords.Add(Tuple.Create(x, y, z));
                            Console.WriteLine("Left: +" + x + " " + y + " steps: " + z);
                        }
                        break;
                    case "U":
                        for(int k = 0; k < steps; k++)
                        {
                            y++;
                            z++;
                            result_coords.Add(Tuple.Create(x, y, z));
                            Console.WriteLine("Up: +" + x + " " + y + " steps: " + z);
                        }
                        break;
                    case "D":
                        for(int k = 0; k < steps; k++)
                        {
                            y--;
                            z++;
                            result_coords.Add(Tuple.Create(x, y, z));
                            Console.WriteLine("Down: +" + x + " " + y + " steps: " + z);
                        }
                        break;
                    default:
                        break;
                    
                }
            }
            return result_coords;
        }

        List<Tuple<int, int, int>> find_crossing_points(List<Tuple<int, int, int>> a_coords, List<Tuple<int, int, int>> b_coords)
        {
            Console.WriteLine(a_coords.Count + " " + b_coords.Count);
            List<Tuple<int, int, int>> crossing_coords = new List<Tuple<int, int, int>>();
            foreach (Tuple<int,int, int> a_coord in a_coords)
            {
                foreach(Tuple<int, int, int> b_coord in b_coords)
                {
                    if( a_coord.Item1 == b_coord.Item1 && a_coord.Item2 == b_coord.Item2)
                    {
                        Console.WriteLine("FOUND CROSSING POINT AT : x " + a_coord.Item1 + ", y: " + a_coord.Item2);
                        crossing_coords.Add(a_coord);
                    }
                }
            }
            return crossing_coords;
        }

        int find_closest_point_manhattan_distance(List<Tuple<int, int, int>> list_of_coords)
        {
            int result = 10000000;
            foreach(Tuple<int, int, int> coord in list_of_coords)
            {
                int manhattan_distance = Math.Abs(coord.Item1) + Math.Abs(coord.Item2);
                if(manhattan_distance < result)
                {
                    Console.WriteLine(result);
                    result = manhattan_distance;
                }
            }
            return result;
        }

        int find_shortest_cable_crossing_point(List<Tuple<int, int, int>> a_coords, List<Tuple<int, int, int>> b_coords)
        {
            //Console.WriteLine(a_coords.Count + " " + b_coords.Count);
            List<int> crossing_coords_distances = new List<int>();
            foreach (Tuple<int, int, int> a_coord in a_coords)
            {
                foreach (Tuple<int, int, int> b_coord in b_coords)
                {
                    if (a_coord.Item1 == b_coord.Item1 && a_coord.Item2 == b_coord.Item2)
                    {
                        Console.WriteLine("FOUND CROSSING POINT AT : x " + a_coord.Item1 + ", y: " + a_coord.Item2);
                        int cable_length = a_coord.Item3 + b_coord.Item3;
                        crossing_coords_distances.Add(cable_length);
                    }
                }
            }

            int result = 10000000;
            foreach (int cables_length in crossing_coords_distances)
            {
                if (cables_length < result)
                {
                    //Console.WriteLine(result);
                    result = cables_length;
                }
            }
            return result;
        }
    }
}
