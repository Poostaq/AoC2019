using System;
using System.Collections.Generic;

namespace AOC_2019
{
    public class AOC_2019_Day4
    {
        public AOC_2019_Day4()
        {
            int input_boundary_a = 367479;
            int input_boundary_b = 893698;

            List<int> passwords = new List<int>();

            for (int i = input_boundary_a; i < input_boundary_b; i++)
            {
                if(check_adjacent_digits(i) == true &&
                    check_increasing_digits(i) == true &&
                    check_exactly_two_adjacent(i) == true)
                {
                    passwords.Add(i);
                }
            }

            Console.WriteLine(passwords.Count);
        }

        bool check_adjacent_digits(int value)
        {
            string checking = value.ToString();
            for(int j = 0; j < checking.Length - 1; j++)
            {
                if(checking.Substring(j, 1) == checking.Substring(j + 1, 1)){
                    return true;
                }
            }
            return false;
        }

        bool check_increasing_digits(int value)
        {

            string checking = value.ToString();
            for (int j = 0; j < checking.Length - 1; j++)
            {
                if (Convert.ToInt16(checking.Substring(j, 1)) > Convert.ToInt16(checking.Substring(j + 1, 1))){
                    return false;
                }
            }
            return true;
        }

        bool check_exactly_two_adjacent(int value)
        {
            string checking = value.ToString();
            bool is_there_double = false;
            int length_of_same_digit = 1;
            for (int j = 0; j < checking.Length - 1; j++)
            {
                if (checking.Substring(j, 1) == checking.Substring(j + 1, 1))
                {
                    if (length_of_same_digit < 2)
                    {
                        ++length_of_same_digit;
                        is_there_double = true;
                    }
                    else
                    {
                        length_of_same_digit++;
                        is_there_double = false;
                    }
                }
                else
                {
                    length_of_same_digit = 1;
                    if (is_there_double == true)
                    {
                        break;
                    }
                }
            }
            if(is_there_double == true)
            {
                Console.WriteLine(value + " has double digit");
            }
            return is_there_double;
        }
    }
}
 