using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using LINQIndexDotNet9;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1 - Run the benchmark");
        Console.WriteLine("2 - Run the code example");
        var userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                LINQIndexDotNet9Program.RunBenchmark();
                break;
            case "2":
                LINQIndexDotNet9Program.RunCodeExample();
                break;
            default:
                Console.WriteLine("Invalid input. Please enter '1' or '2'.");
                break;
        }
    }
}

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn(NumeralSystem.Arabic)]
[MarkdownExporter]
public class LINQIndexDotNet9Program
{
    readonly List<City> cities = Enumerable.Range(1, 100000)
        .Select(i => new City($"City {i}", $"Country {i}"))
        .ToList();

    [Benchmark(Description = "For loop with Count")]
    public void RunTraditionalWay() => ForLoopWithCount.Execute(cities);

    [Benchmark(Description = "Select with foreach")]
    public void RunSelectDemo() => SelectWithForeach.Execute(cities);

    [Benchmark(Description = "New Index method")]
    public void RunIndexDemo() => NewIndex.Execute(cities);

    public static void RunBenchmark()
    {
        BenchmarkRunner.Run<LINQIndexDotNet9Program>();
    }

    public static void RunCodeExample()
    {
        var cities = new List<City>
        {
            new City("Paris", "France"),
            new City("Berlin", "Germany"),
            new City("Madrid", "Spain"),
            new City("Rome", "Italy"),
            new City("Amsterdam", "Netherlands")
        };

        Console.WriteLine("For loop with Count:");
        ForLoopWithCount.Execute(cities);
        Console.WriteLine();

        Console.WriteLine("Select with foreach:");
        SelectWithForeach.Execute(cities);
        Console.WriteLine();

        Console.WriteLine("New Index method:");
        NewIndex.Execute(cities);
    }
}