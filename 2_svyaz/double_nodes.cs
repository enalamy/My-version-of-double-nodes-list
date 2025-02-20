using SimpleAlgorithmsApp;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Programm
{ 
    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        DoubleLinkedList<string> linkedGlist = new DoubleLinkedList<string>();
        // проблему с памятью все еще надо решить
        // мой Add работает на +- 3500 тиков медленнее и само создание тоже медленнее        
        string[] names = { "Alisha", "Bob", "Sally", "Kompton", "Kwark", "Kerowsky", "Gutnah", "Cordon", "Krapenton" };
        foreach (string num in names)
        {
            linkedGlist.Add(num);
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();

        sw.Start();
        linkedGlist.Remove("Gus");
        sw.Stop();

        Console.WriteLine($"My add: {sw.ElapsedTicks} ticks");
        //Console.WriteLine($"Память после: {GC.GetTotalMemory(true)} байт");

        LinkedList<string> list = new LinkedList<string>();
        GC.Collect();
        GC.WaitForPendingFinalizers();        
        string[] names2 = { "Alisha", "Bob", "Sally", "Kompton", "Kwark", "Kerowsky", "Gutnah", "Cordon", "Krapenton" };
        foreach (string num in names2)
        {
            list.AddLast(num);
        }
        sw.Restart();
        list.Remove("Gus");
        sw.Stop();
        Console.WriteLine($"Ins add: {sw.ElapsedTicks} ticks");
        
    }
}
