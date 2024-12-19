using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6;
class Home
{
    static void Main()
    {
        Console.WriteLine("Коты(Введите 1) или дроби(Введите 2)");
        string S = Console.ReadLine();
        if (S == "1")
        {
            S = "";
            Work work = new Work();
            List<Meoweable> m = new List<Meoweable>();
            while (S != "stop")
            {
                Console.WriteLine("\nВведите Cat — чтобы добавить кота\nВведите no_Cat — чтобы добавить не кота\nВведите stop — чтобы закончить ввод котов");
                S = Console.ReadLine();
                if (S == "Cat")
                {
                    Console.WriteLine("Введите имя кота");
                    Meoweable Cat = new Cat(Console.ReadLine());
                    m.Add(Cat);
                }
                else if (S == "no_Cat")
                {
                    Meoweable NO_CAT = new NO_Cat();
                    m.Add(NO_CAT);
                }

            }
            if (m.Count() == 0)
            {
                m.Add(new Cat("Барсик"));
            }
            work.Imouw(m);
            foreach (var i in m)
            {
                try
                {
                    Console.WriteLine(i + " сказал мяу " + work.Meow[i.ToString()] + " раз");
                }
                catch
                {
                    Console.WriteLine(i+" не говорил мяу.");
                }
            }
        }
        else if (S == "2") {
            S = "";
            List<fractions> f = new List<fractions>();
            int a = 1;
            int b = 1;
            while (S != "stop")
            {
                Console.WriteLine("Введите целочисленный числитель");
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                }
                catch{
                    Console.WriteLine("Неподходящий элемент. Задано стандартное значение");
                }
                Console.WriteLine("Введите целочисленный знаменатель");
                try
                {
                    b = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неподходящий элемент. Задано стандартное значение");
                }
                fractions F = new fractions(a,b);
                f.Add(F);
                Console.WriteLine("Введите stop, чтобы завершить ввод дробей");
                S = Console.ReadLine();
            }
            a = 2;
            while (f.Count() <3)
            {
                f.Add(new fractions(1,a));
                a++;
            }
            Console.WriteLine("Выводим стандартные данные\n");
            fractions F1 = new fractions(1, 3) * new fractions(2, 3);
            Console.WriteLine(F1);
            fractions F2 = new fractions(1, 2).sum(new fractions(2, 3)).div(new fractions(3, 4)).minus(5);
            Console.WriteLine(F2);
            S = "";
            Dictionary<fractions,fractions_cach> Cache=new Dictionary<fractions, fractions_cach>();
            while (S != "stop")
            {

                Console.WriteLine("\nВведите print — чтобы вывести все дроби\nВведите sum — чтобы сложить два вектора или вектор и число\nВведите minus — чтобы вычесть два вектора или вектор и число\nВведите comp — чтобы перемножить два вектора или вектор и число\nВведите div — чтобы разделить два вектора или вектор и число\nВведите Equals — чтобы клонировать элемент\nВведите Clone — чтобы клонировать элемент\nВведите New_num — чтобы задать новое значение числителя\nВведите New_den — чтобы задать новое значение знаменателя\nВведите Cache — чтобы получить вещественное значение дроби\nВведите stop — чтобы выйти из программы");
                S = Console.ReadLine();
                if (S == "sum")
                {
                    a = 0;
                    b = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                    Console.WriteLine("Выберите номер первого элемента");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        a = 1;
                    }
                    Console.WriteLine("Выберите номер второго элемента");
                    try
                    {
                        b = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        b = 1;
                    }
                    if (a >= f.Count())
                    {
                        a = f.Count() - 1;
                    }
                    if (b >= f.Count())
                    {
                        b = f.Count() - 1;
                    }
                    Console.WriteLine(f[a] + f[b]);
                }
                else if (S == "minus")
                {
                    a = 0;
                    b = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                    Console.WriteLine("Выберите номер первого элемента");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        a = 1;
                    }
                    Console.WriteLine("Выберите номер второго элемента");
                    try
                    {
                        b = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        b = 1;
                    }
                    if (a >= f.Count())
                    {
                        a = f.Count() - 1;
                    }
                    if (b >= f.Count())
                    {
                        b = f.Count() - 1;
                    }
                    Console.WriteLine(f[a] - f[b]);
                }
                else if (S == "div")
                {
                    a = 0;
                    b = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                    Console.WriteLine("Выберите номер делимого");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        a = 1;
                    }
                    Console.WriteLine("Выберите номер делителя");
                    try
                    {
                        b = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        b = 1;
                    }
                    if (a >= f.Count())
                    {
                        a = f.Count() - 1;
                    }
                    if (b >= f.Count())
                    {
                        b = f.Count() - 1;
                    }
                    Console.WriteLine(f[a] / f[b]);
                }
                else if (S == "comp")
                {
                    a = 0;
                    b = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                    Console.WriteLine("Выберите номер первого множителя");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        a = 1;
                    }
                    Console.WriteLine("Выберите номер второго множителя");
                    try
                    {
                        b = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        b = 1;
                    }
                    if (a >= f.Count())
                    {
                        a = f.Count() - 1;
                    }
                    if (b >= f.Count())
                    {
                        b = f.Count() - 1;
                    }
                    Console.WriteLine(f[a] * f[b]);
                }
                else if (S == "New_num")
                {
                    a = 0;
                    b = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                    Console.WriteLine("Выберите номер первого элемента");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        a = 1;
                    }
                    if (a >= f.Count())
                    {
                        a = f.Count() - 1;
                    }
                    Console.WriteLine("Выберите новое значение");
                    try
                    {
                        b = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        b = 1;
                    }
                    f[a].new_num(b);
                }
                else if (S == "New_den")
                {
                    a = 0;
                    b = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                    Console.WriteLine("Выберите номер первого элемента");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        a = 1;
                    }
                    if (a >= f.Count())
                    {
                        a = f.Count() - 1;
                    }
                    Console.WriteLine("Выберите новое значение");
                    try
                    {
                        b = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        b = 1;
                    }
                    f[a].new_den(b);
                }
                else if (S == "Cache")
                {
                    a = 0;
                    b = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                    Console.WriteLine("Выберите номер первого элемента");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        a = 1;
                    }
                    if (a >= f.Count())
                    {
                        a = f.Count() - 1;
                    }
                    if (Cache.ContainsKey(f[a]) == false)
                    {
                        Cache[f[a]] = f[a].converter();
                    }
                    Console.WriteLine(Cache[f[a]]);
                }
                else if (S == "Clone")
                {
                    a = 0;
                    b = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                    Console.WriteLine("Выберите номер первого элемента");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        a = 1;
                    }
                    if (a >= f.Count())
                    {
                        a = f.Count() - 1;
                    }
                    f.Add((fractions)f[a].Clone());
                }
                else if (S == "print")
                {
                    a = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                }
                else if (S == "Equals")
                {
                    a = 0;
                    b = 0;
                    foreach (var i in f)
                    {
                        Console.WriteLine(a + " " + i);
                        a++;
                    }
                    Console.WriteLine("Выберите номер первого элемента");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        a = 1;
                    }
                    Console.WriteLine("Выберите номер второго элемента");
                    try
                    {
                        b = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        b = 1;
                    }
                    if (a >= f.Count())
                    {
                        a = f.Count() - 1;
                    }
                    if (b >= f.Count())
                    {
                        b = f.Count() - 1;
                    }
                    if (f[a].Equals(f[b])){
                        
                        Console.WriteLine("Они равны");
                    }
                    else
                    {
                        Console.WriteLine("Они не равны");
                    }
                }
            }
        }
    }
}
