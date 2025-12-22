using System;

public class SimpleDictionaryTests
{
    public static void RunAllTests()
    {
        Console.WriteLine("\nТестирование SimpleDictionary");
        
        Test1_AddAndCount();
        Test2_ContainsKey();
        Test3_Remove();
        Test4_Indexer();
        Test5_TryGetValue();
        
        Console.WriteLine("тесты SimpleDictionary пройдены");
    }
    
    static void Test1_AddAndCount()
    {
        var dict = new SimpleDictionary<string, int>();
        
        dict.Add("ключ1", 100);
        dict.Add("ключ2", 200);
        
        if (dict.Count != 2)
            throw new Exception("Ошибка: Count должен быть 2");
    }
    
    static void Test2_ContainsKey()
    {
        var dict = new SimpleDictionary<int, string>();
        
        dict.Add(1, "значение1");
        dict.Add(2, "значение2");
        
        if (!dict.ContainsKey(1))
            throw new Exception("Ошибка: должен содержать ключ 1");
            
        if (dict.ContainsKey(3))
            throw new Exception("Ошибка: не должен содержать ключ 3");
    }
    
    static void Test3_Remove()
    {
        var dict = new SimpleDictionary<string, string>();
        
        dict.Add("к1", "з1");
        dict.Add("к2", "з2");
        
        bool removed = dict.Remove("к1");
        
        if (!removed)
            throw new Exception("Ошибка: удаление должно вернуть true");
            
        if (dict.Count != 1)
            throw new Exception("Ошибка: Count должен быть 1");
    }
    
    static void Test4_Indexer()
    {
        var dict = new SimpleDictionary<string, double>();
        
        dict["пи"] = 3.14;
        dict["е"] = 2.71;
        
        if (dict["пи"] != 3.14)
            throw new Exception("Ошибка: неверное значение для ключа 'пи'");
            
        dict["пи"] = 3.1415;
        if (dict["пи"] != 3.1415)
            throw new Exception("Ошибка: значение не изменилось");
    }
    
    static void Test5_TryGetValue()
    {
        var dict = new SimpleDictionary<int, bool>();
        
        dict.Add(10, true);
        dict.Add(20, false);
        
        if (!dict.TryGetValue(10, out bool value1) || !value1)
            throw new Exception("Ошибка: TryGetValue для ключа 10");
            
        if (dict.TryGetValue(30, out bool value2))
            throw new Exception("Ошибка: TryGetValue для несуществующего ключа");
    }
}