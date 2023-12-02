using System.Text.RegularExpressions;

namespace Day1;

public class Solver
{
    public Solver() { }
    public Solver(string specialRegex) {
        Regex = new Regex(specialRegex);
    }

    public Regex Regex = new(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine|zero))");

    public int Solve(string[] lines, bool verbose = false)
    {
        Console.WriteLine(lines.Length + " lines to parse...");

        int Sum = 0;

        foreach (string line in lines)
        {
            var matches = Regex.Matches(line);

            string first = matches.First().Groups[1].Value;
            string last = matches.Last().Groups[1].Value;

            int mashedTogether = ParseInt(first) * 10  + ParseInt(last);

            if(verbose) Console.WriteLine($"{line} has {matches.Count()} matches; we care about {first} and {last}, yielding {mashedTogether}");
            Sum += mashedTogether;
        }

        return Sum;
    }

    public int ParseInt(string alpha) => alpha.ToLower() switch
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
