using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Days
{
    public class Day2
    {
        public int Red, Green, Blue;

        public Day2(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public string Solve(string[] lines)
        {
            int PossibleSum = 0;
            int MinimumSum = 0;

            foreach (string line in lines)
            {
                bool Possible = true;

                int minR = 0;
                int minG = 0;
                int minB = 0;

                string[] split0 = line.Split(':');
                int gameNum = int.Parse(split0[0].Split(' ')[1]);

                string[] splitSets = split0[1].Split(';');
                foreach (string set in splitSets)
                {
                    (int _r, int _g, int _b) = SplitSet(set);

                    if (_r > Red || _g > Green || _b > Blue) Possible = false;
                    minR = Math.Max(minR, _r);
                    minG = Math.Max(minG, _g);
                    minB = Math.Max(minB, _b);
                }

                int GamePower = minR * minG * minB;

                if (Possible) PossibleSum += gameNum;

                MinimumSum += GamePower;
            }

            return $"Possible Game Sum: {PossibleSum}; Minimum Cube Sums: {MinimumSum}";
        }

        public (int Red, int Green, int Blue) SplitSet(string set)
        {
            int R = 0;
            int G = 0;
            int B = 0;

            foreach (string element in set.Split(","))
            {
                string[] split = element.Trim().Split(' ');

                int count = int.Parse(split[0]);
                if (split[1] == "red") R = count;
                if (split[1] == "green") G = count;
                if (split[1] == "blue") B = count;
            }

            return (R, G, B);
        }
    }
}
