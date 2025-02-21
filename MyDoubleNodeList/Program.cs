using ListOfNodes;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

class Programm
{
    static void Main()
    {
        Stopwatch sw = new Stopwatch();

        // создание встроенного и созданного мною списка
        DoubleLinkedList<string> MyList = new DoubleLinkedList<string>();
        LinkedList<string> InBuiltList = new LinkedList<string>();

        // создание массива изначальных данных
        string[] names = { "Alisha", "Zenston", "Bob", "Sally", "Kompton", "Kwark", "Kerowsky", "August", "Gutnah", "Cordon", "Krapenton" };

        // замер времени добавления 
        sw.Start();
        foreach (string num in names)
        {
            MyList.Add(num);
        }
        sw.Stop();
        Console.WriteLine($"Время на добавление элементов в моем списке: {sw.ElapsedTicks} ticks");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        sw.Restart();
        foreach (string num in names)
        {
            InBuiltList.AddLast(num);
        }
        sw.Stop();
        Console.WriteLine($"Время на добавление элементов во встроенном списке: {sw.ElapsedTicks} ticks\n");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // замер времени удаления одного элемента
        sw.Restart();
        MyList.Remove("Kwark");
        sw.Stop();
        Console.WriteLine($"Время на удаление 1 элемента в моем списке: {sw.ElapsedTicks} ticks");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        sw.Restart();
        InBuiltList.Remove("Kwark");
        sw.Stop();
        Console.WriteLine($"Время на удаление 1 элемента во встроенном списке: {sw.ElapsedTicks} ticks\n");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // замер времени добавления в начало одного элемента
        sw.Restart();
        MyList.AddFirst("Paulimus");
        sw.Stop();
        Console.WriteLine($"Время на добавление 1 элемента в начало в моем списке: {sw.ElapsedTicks} ticks");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        sw.Restart();
        InBuiltList.AddFirst("Paulimus");
        sw.Stop();
        Console.WriteLine($"Время на добавление 1 элемента в начало во встроенном списке: {sw.ElapsedTicks} ticks\n");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // замер времени добавления в случайное место одного элемента
        sw.Restart();
        MyList.Insert(5,"Los Buenos");
        sw.Stop();
        Console.WriteLine($"Время на добавление 1 элемента в случайное место в моем списке: {sw.ElapsedTicks} ticks");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        sw.Restart();
        LinkedListNode<string> node = InBuiltList.Find("Bob");
        InBuiltList.AddAfter(node, "Los Buenos");
        sw.Stop();
        Console.WriteLine($"Время на добавление 1 элемента в случайное место во встроенном списке: {sw.ElapsedTicks} ticks\n");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // замер времени поиска элемента
        sw.Restart();
        MyList.Contains("Los Buenos");
        sw.Stop();
        Console.WriteLine($"Время на проверку содержимости в моем списке: {sw.ElapsedTicks} ticks");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        sw.Restart();
        InBuiltList.Contains("Los Buenos");
        sw.Stop();
        Console.WriteLine($"Время на проверку содержимости во встроенном списке: {sw.ElapsedTicks} ticks\n");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // замер времени сортировки
        sw.Restart();
        MyList.Sort();
        sw.Stop();
        Console.WriteLine($"Время на сортировку в моем списке: {sw.ElapsedTicks} ticks \nМетод сортировки во встроенном списке не реализован\n");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // замер времени очистки списка
        sw.Restart();
        MyList.Clear();
        sw.Stop();
        Console.WriteLine($"Время на очистку списка в моем списке: {sw.ElapsedTicks} ticks");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        sw.Restart();
        InBuiltList.Clear();
        sw.Stop();
        Console.WriteLine($"Время на очистку списка во встроенном списке: {sw.ElapsedTicks} ticks");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.ReadKey();
    }
}
