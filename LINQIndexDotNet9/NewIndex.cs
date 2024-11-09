namespace LINQIndexDotNet9
{
    public static class NewIndex
    {
        public static void Execute(List<City> cities)
        {
            foreach ((int index, City city) in cities.Index())
            {
                Console.WriteLine($"Index: {index}, City: {city.Name}");
            }
        }
    }
}
