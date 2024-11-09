namespace LINQIndexDotNet9
{
    public static class SelectWithForeach
    {
        public static void Execute(List<City> cities)
        {
            var indexedElements = cities.Select((item, index) => new { Index = index, Item = item });

            foreach (var item in indexedElements)
            {
                Console.WriteLine($"Index: {item.Index}, City: {item.Item.Name}");
            }
        }
    }
}
