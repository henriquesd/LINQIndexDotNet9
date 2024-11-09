namespace LINQIndexDotNet9
{
    public static class ForLoopWithCount
    {
        public static void Execute(List<City> cities)
        {
            var citiesCount = cities.Count();

            for (int i = 0; i < citiesCount; i++)
            {
                Console.WriteLine($"Index: {i}, City: {cities[i].Name}");
            }
        }
    }
}
