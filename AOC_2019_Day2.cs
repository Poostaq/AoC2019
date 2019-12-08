using System;
using System.IO;

namespace AOC_2019
{
    public class AOC_2019_Day2
    {
        string[] integers;
        int result;
        public AOC_2019_Day2()
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "Day2_input.txt");
            string text = File.ReadAllText(path);
            string[] initial_integers = text.Split(',');
            for(int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    integers = new string[initial_integers.Length];
                    initial_integers.CopyTo(integers, 0);
                    this.integers[1] = i.ToString();
                    this.integers[2] = j.ToString();
                    Console.WriteLine("NEW INTEGERS 1 " + this.integers[1]);
                    int x = 0;
                    while (this.integers[x] != "99")
                    {
                        if (this.integers[x] == "1")
                        {
                            addOperation(this.integers[x + 1], this.integers[x + 2], this.integers[x + 3]);
                        }
                        else if (this.integers[x] == "2")
                        {
                            multiplyOperation(this.integers[x + 1], this.integers[x + 2], this.integers[x + 3]);
                        }
                        x += 4;
                        //Console.WriteLine("Index " + x + " has value " + integers[x]);
                    }
                    if(this.integers[0] == "19690720")
                    {
                        result = 100 * i + j;
                    }

                }
                
            }
            Console.WriteLine(this.integers[0]);
            Console.WriteLine("OMG! RESULT is " + result);
        }

        private void addOperation(string index1, string index2, string resultIndex)
        {
            Console.WriteLine("ADDING");
            Console.WriteLine("Index1= " + index1 + " Value @ index1= " + this.integers[Convert.ToInt32(index1)]);
            Console.WriteLine("Index2= " + index2 + " Value @ index2= " + this.integers[Convert.ToInt32(index2)]);
            Console.WriteLine("resultIndex= " + resultIndex + " Value @ resultIndex= " + this.integers[Convert.ToInt32(resultIndex)]);
            this.integers[Convert.ToInt32(resultIndex)] =
                (Convert.ToInt32(this.integers[Convert.ToInt32(index1)]) +
                Convert.ToInt32(this.integers[Convert.ToInt32(index2)])).ToString();
            Console.WriteLine("resultIndex= " + resultIndex + " Value @ resultIndex after= " + this.integers[Convert.ToInt32(resultIndex)]);
        }

        private void multiplyOperation(string index1, string index2, string resultIndex)
        {
            //Console.WriteLine("MULTIPLYING");
            //Console.WriteLine("Index1= " + index1 + " Value @ index1= " + this.integers[Convert.ToInt32(index1)]);
            //Console.WriteLine("Index2= " + index2 + " Value @ index2= " + this.integers[Convert.ToInt32(index2)]);
            //Console.WriteLine("resultIndex= " + resultIndex + " Value @ resultIndex= " + this.integers[Convert.ToInt32(resultIndex)]);
            this.integers[Convert.ToInt32(resultIndex)] =
                (Convert.ToInt32(this.integers[Convert.ToInt32(index1)]) *
                Convert.ToInt32(this.integers[Convert.ToInt32(index2)])).ToString();
            //Console.WriteLine("resultIndex= " + resultIndex + " Value @ resultIndex after= " + this.integers[Convert.ToInt32(resultIndex)]);
        }
    }
}
