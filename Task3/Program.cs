class Program
{
    static void Main(string[] args)
    {
        FunctionCache<int, double> cache = new FunctionCache<int, double>();
        TimeSpan cacheDuration = TimeSpan.FromSeconds(10);

        FunctionCache<int, double>.Func<int, double> expensiveFunction = key =>
        {
            Console.WriteLine($"Calculating result for key {key}");
            return Math.Sqrt(key);
        };

        int key1 = 18;
        int key2 = 17;

        double result1 = cache.GetResult(key1, expensiveFunction, cacheDuration);
        double result2 = cache.GetResult(key2, expensiveFunction, cacheDuration);

        Console.WriteLine($"Result for key {key1}: {result1}");
        Console.WriteLine($"Result for key {key2}: {result2}");

        double result1Cached = cache.GetResult(key1, expensiveFunction, cacheDuration);
        Console.WriteLine($"Cached result for key {key1}: {result1Cached}");
    }
}