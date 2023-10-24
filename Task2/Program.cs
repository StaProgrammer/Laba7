using System;
class Program
{
    static void Main(string[] args)
    {
        Repository<int> numbersRepository = new Repository<int>();
        numbersRepository.Add(1);
        numbersRepository.Add(2);
        numbersRepository.Add(3);
        numbersRepository.Add(4);
        numbersRepository.Add(5);

        Repository<string> namesRepository = new Repository<string>();
        namesRepository.Add("Alice");
        namesRepository.Add("Bob");
        namesRepository.Add("Charlie");
        namesRepository.Add("David");
        namesRepository.Add("Eve");

        List<int> evenNumbers = numbersRepository.Find(x => x % 2 == 0);
        List<string> namesStartingWithA = namesRepository.Find(s => s.StartsWith("A", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));
        Console.WriteLine("Names starting with 'A': " + string.Join(", ", namesStartingWithA));
    }
}
