using System.Text.RegularExpressions;

namespace Day1;

public class Day1Solver
{
    public Day1Solver() { }

    static readonly Regex Regex = new(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine|zero))");

    public int Solve(string[] lines)
    {
        Console.WriteLine(lines.Length + " lines to parse...");

        int Sum = 0;

        foreach (string line in lines)
        {
            Console.Write(line);
            var matches = Regex.Matches(line);
            var mf = matches.First();
            var ml = matches.Last();
            Console.Write($" has {matches.Count()} matches; we care about");
            string first = mf.Groups[1].Value;
            Console.Write($" {first}");
            string last = ml.Groups[1].Value;
            Console.Write($" and { last}");

            int mashedTogether = ParseInt(first) * 10  + ParseInt(last);

            Console.Write($", yielding {mashedTogether}\n");
            Sum += mashedTogether;
        }

        return Sum;
    }

    public int ParseInt(string alpha) =>
        alpha.ToLower() switch
        {
            "one" or "1" => 1,
            "two" or "2" => 2,
            "three" or "3" => 3,
            "four" or "4" => 4,
            "five" or "5" => 5,
            "six" or "6" => 6,
            "seven" or "7" => 7,
            "eight" or "8" => 8,
            "nine" or "9" => 9,
            "zero" or "0"=> 0,
            _ => throw new InvalidCastException(),
        };
}
