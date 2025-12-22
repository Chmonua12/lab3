class Program
{
    static void Main()
    {
        try
        {
            SimpleListTests.RunAllTests();
            SimpleDictionaryTests.RunAllTests();
            DoublyLinkedListTests.RunAllTests();
            
            Console.WriteLine("\nТесты - ВСЁ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nошибка: {ex.Message}");
            Console.WriteLine("Тесты не пройдены");
        }
    }
}