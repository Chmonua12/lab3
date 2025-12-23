using System;

public class DoublyLinkedListTests
{
    public static void RunAllTests()
    {
        Console.WriteLine("\nТестирование DoublyLinkedList");
        
        Test1_AddAndCount();
        Test2_Indexer();
        Test3_Contains();
        Test4_Insert();
        Test5_Remove();
        Test6_Enumerator();
        
        Console.WriteLine("Тесты DoublyLinkedList пройдены");
    }
    
    static void Test1_AddAndCount()
    {
        var list = new DoublyLinkedList<int>();
        
        list.Add(10);
        list.Add(20);
        list.Add(30);
        
        if (list.Count != 3)
            throw new Exception("Count должен быть 3");
    }
    
    static void Test2_Indexer()
    {
        var list = new DoublyLinkedList<string>();
        
        list.Add("а");
        list.Add("б");
        list.Add("в");
        
        if (list[0] != "а" || list[1] != "б" || list[2] != "в")
            throw new Exception("Неверные значения по индексам");
    }
    
    static void Test3_Contains()
    {
        var list = new DoublyLinkedList<char>();
        
        list.Add('X');
        list.Add('Y');
        
        if (!list.Contains('X'))
            throw new Exception("Ошибка: должен содержать 'X'");
            
        if (list.Contains('Z'))
            throw new Exception("Ошибка: не должен содержать 'Z'");
    }
    
    static void Test4_Insert()
    {
        var list = new DoublyLinkedList<int>();
        
        list.Add(1);
        list.Add(3);
        
        list.Insert(1, 2);
        
        if (list.Count != 3)
            throw new Exception("Count должен быть 3");
            
        if (list[1] != 2)
            throw new Exception("На позиции 1 должно быть 2");
    }
    
    static void Test5_Remove()
    {
        var list = new DoublyLinkedList<string>();
        
        list.Add("первый");
        list.Add("второй");
        list.Add("третий");
        
        bool removed = list.Remove("второй");
        
        if (!removed)
            throw new Exception("Ошибка: удаление должно вернуть true");
            
        if (list.Count != 2)
            throw new Exception("Count должен быть 2");
            
        if (list.Contains("второй"))
            throw new Exception("'второй' должен быть удален");
    }
    
    static void Test6_Enumerator()
    {
        var list = new DoublyLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        
        int sum = 0;
        foreach (var item in list)
        {
            sum += item;
        }
        
        if (sum != 6)
            throw new Exception($"Сумма должна быть 6");
    }
}