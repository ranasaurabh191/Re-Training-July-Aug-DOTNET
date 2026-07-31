namespace Day2_LibraryOrderSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool result = LibraryProcessor.TryProcessOrder(
                out List<string> validIsbns,
                "978-3-16-148410-0",
                "1234567890123",
                "invalid-isbn",
                "978-1-4028-9462-6"
            );

            Console.WriteLine(result);

            foreach (string isbn in validIsbns)
            {
                Console.WriteLine(isbn);
            }
        }
    }
}