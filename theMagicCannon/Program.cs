using System;

class Program
{
    static void Main()
    {
        for (int i = 1; i <= 100; i++) 
        {
            if (i % 3 == 0 && i % 5 ==0)
            {
                Console.WriteLine($"{i}: C-C-Combo!!! Electric and fire!");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine($"{i}: Fire blast!");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine($"{i}:Electric blast!");
            }
            else
            {
                Console.WriteLine($"{i}: normal blast!");
            }
        }
    }
}
