// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to Advent of Code 2023!");
Console.WriteLine("This is Robin's Unified Answer Application.");
Console.WriteLine("Please peruse the following options:");
Console.Write("Enter a Day (1-25):");

while (ReadInput(Console.ReadLine()) == false) { Console.Write("Enter a Day (1-25):"); }

static bool ReadInput (string? input)
{
    if (input is null || string.IsNullOrWhiteSpace(input)) return false;

    string[]? lines = null;
    try
    {
        lines = File.ReadAllLines($"./Day{input}.txt");
    }
    catch 
    {
        return false;
    }

    if (input == "1")
    {
        Console.WriteLine(new Day1.Solver().Solve(lines));
    }
    else
    {
        Console.WriteLine(new string(input.Reverse().ToArray()));
        return false;
    }
    return true;
}