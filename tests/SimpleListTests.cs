using System;

public class SimpleListTests
{
    public static void RunAllTests()
    {
        Console.WriteLine("Тестирование SimpleList");
        
        Test1_AddAndCount();
        Test2_Indexer();
        Test3_Contains();
        Test4_IndexOf();
        Test5_Remove();
        Test6_Insert();
        Test7_Clear();
        
        Console.WriteLine("тесты SimpleList пройдены");
    }
    
    static void Test1_AddAndCount()
    {
        SimpleList list = new SimpleList();
        
        list.Add("тест1");
        list.Add("тест2");
        list.Add("тест3");
        
        if (list.Count != 3)
        {
            throw new Exception("Count должен быть 3");
        }
    }
    
    static void Test2_Indexer()
    {
        SimpleList list = new SimpleList();
        
        list.Add(100);
        list.Add(200);
        
        if ((int)list[0] != 100)
            throw new Exception("неверное значение по индексу 0");
            
        if ((int)list[1] != 200)
            throw new Exception("неверное значение по индексу 1");
    }
    
    static void Test3_Contains()
    {
        SimpleList list = new SimpleList();
        
        list.Add("яблоко");
        list.Add("груша");
        
        if (!list.Contains("яблоко"))
            throw new Exception("Ошибка должен содержать 'яблоко'");
            
        if (list.Contains("апельсин"))
            throw new Exception("не должен содержать 'апельсин'");
    }
    
    static void Test4_IndexOf()
    {
        SimpleList list = new SimpleList();
        
        list.Add("первый");
        list.Add("второй");
        list.Add("третий");
        
        if (list.IndexOf("второй") != 1)
            throw new Exception("Ошибка неверный индекс");
            
        if (list.IndexOf("четвертый") != -1)
            throw new Exception("Ошибка должен возвращать -1");
    }
    
    static void Test5_Remove()
    {
        SimpleList list = new SimpleList();
        
        list.Add("A");
        list.Add("B");
        list.Add("C");
        
        list.Remove("B");
        
        if (list.Count != 2)
            throw new Exception("Count должен быть 2");
            
        if (list.Contains("B"))
            throw new Exception("B должен быть удален");
    }
    
    static void Test6_Insert()
    {
        SimpleList list = new SimpleList();
        
        list.Add("начало");
        list.Add("конец");
        
        list.Insert(1, "середина");
        
        if (list.Count != 3)
            throw new Exception("Count должен быть 3");
            
        if ((string)list[1] != "середина")
            throw new Exception("неверный элемент на позиции 1");
    }
    
    static void Test7_Clear()
    {
        SimpleList list = new SimpleList();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        
        list.Clear();
        
        if (list.Count != 0)
            throw new Exception("список должен быть пустым");
    }
}