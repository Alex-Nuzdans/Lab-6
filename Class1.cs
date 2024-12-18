using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    abstract class Meoweable
    {
        abstract public void meow();
        abstract public void meow(int N);
        public abstract override string ToString();
    }
    internal class NO_Cat : Meoweable
    {
        public NO_Cat()
        {
        }
        public override void meow()
        {
            Console.WriteLine("МЯУ.");
        }
        public override void meow(int N)
        {
            Console.WriteLine("МЯУ "+N+" РАЗ.");
        }
        public override string ToString() {
            return "НЕ КОТ!";
        }
    }
    internal class Cat:Meoweable
    {
        private string name;
        public Cat(string Name)
        {
            name= Name;
        }
        public override void meow()
        {
            Console.WriteLine(name+": мяу!");
        }
        public override void meow(int N)
        {
            string meows = "";
            if (N < 0) {
                N *= -1;
            }
            if (N != 0)
            {
                meows = "мяу";
                for (int i = 0; i < N - 1; i++)
                {
                    meows += "-мяу";
                }
                meows += "!";
            }
            else
            {
                meows = "молчит.";
            }
            Console.WriteLine(name+": " +meows);
        }
        public override string ToString()
        {
            return "Кот: " + name;
        }
    }
    internal class Work
    {
        Dictionary<string, int> more_meow;
        public Dictionary<string,int> Meow {get {return more_meow;}set { Console.WriteLine("НЕТ"); } }
        public Work() {
            more_meow = new Dictionary<string, int>();
        }
        private void plus_meow(string key)
        {
            try {
                more_meow[key] += 1;
            }
            catch
            {
                more_meow[key] = 1;
            }
        }
        private void plus_meow(string key,int N)
        {
            try
            {
                more_meow[key] += N;
            }
            catch
            {
                more_meow[key] = N;
            }
        }
        public void Imouw(List<Meoweable> L)
        {
            more_meow.Clear();
            int N = 0;
            string M;
            foreach (var i in L)
            {
                M = "";
                while (M!="next") {
                    Console.WriteLine(i + "\nВедите meow — чтобы мяукнуть;\nВведите lot_meow — чтобы мяукнуть несколько раз;\nВведите next — чтобы перейти к следующему обекту.");
                    M = Console.ReadLine();
                    if (M == "meow")
                    {
                        i.meow();
                        plus_meow(i.ToString());
                    }
                    else if(M=="lot_meow"){
                        Console.WriteLine("Введите количество  мяуконий");
                        try
                        {
                            N = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Это НЕ количество мяуконий. Задано стандартное значение");
                            N = 1;
                        }
                        i.meow(N);
                        plus_meow(i.ToString(), N);
                    }
                }
            }
        }
        public void Imouw(Meoweable L)
        {
            more_meow.Clear();
            int N = 0;
            string M = "";
            while (M != "exit")
            {
                Console.WriteLine(L + "\nВедите meow — чтобы мяукнуть;\nВведите lot_meow — чтобы мяукнуть несколько раз;\nВведите exit — чтобы закончить мяукать.");
                M = Console.ReadLine();
                if (M == "meow")
                {
                    L.meow();
                    plus_meow(L.ToString());
                }
                else if (M == "lot_meow")
                {
                    Console.WriteLine("Введите количество  мяуконий");
                    try
                    {
                        N = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Это НЕ количество мяуконий. Задано стандартное значение");
                        N = 1;
                    }
                    L.meow(N);
                    plus_meow(L.ToString(), N);
                }
            }
        }
    }
}
