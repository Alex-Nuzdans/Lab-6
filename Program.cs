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

        string S = "";
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
            Console.WriteLine(i.ToString() + " сказал мяу " + work.Meow[i.ToString()] + " раз");
        }
    }
}