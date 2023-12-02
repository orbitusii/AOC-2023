// See https://aka.ms/new-console-template for more information
using Day1;

Console.WriteLine("Welcome to Advent of Code 2023!");
Console.WriteLine("This is Robin's Unified Answer Application.");
Console.WriteLine("Please peruse the following options:");

while (ReadInput(Console.ReadLine()) == false) { Console.Write("Enter a Day (1-25):"); }

static bool ReadInput (string? input)
{
    if (input is null || string.IsNullOrWhiteSpace(input)) return false;

    string[] lines = File.ReadAllLines($"./Day{input}.txt");

    if (input == "1")
    {
        Console.WriteLine(new Day1Solver().Solve(lines));
    }

    return true;
}