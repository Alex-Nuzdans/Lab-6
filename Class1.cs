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
    class NO_Cat : Meoweable
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
    class Cat:Meoweable
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
                meows = "молчит...";
            }
            Console.WriteLine(name+": " +meows);
        }
        public override string ToString()
        {
            return "Кот: " + name;
        }
    }

    public interface ICloneable
    {
        object Clone();
    }
    public interface Ifractions
    {
        public fractions_cach converter();
        public void new_num(int num);
        public void new_den(int den);
    }
    class fractions:ICloneable,Ifractions
    {
        private int numerator;
        private int denominator;
        public fractions(int num,int den)
        {
            if (den < 0)
            {
                num *= -1;
                den *= -1;
            }
            else if (den == 0)
            {
                den = 1;
            }
            numerator = num;
            denominator = den;
        }

        public fractions_cach converter()
        {
            double temp = Convert.ToDouble(numerator) / Convert.ToDouble(denominator);
            fractions_cach cach = new fractions_cach(temp);
            return cach;
        }
        public void new_num(int num) {
            numerator = num;
        }
        public void new_den(int den)
        {
            if (den == 0)
            {
                Console.WriteLine("Значение не может быть нулевым.");
                den = 1; 
            }
            denominator = den;
        }
        private int GCD(int a,int b)
        {
            if (a < 0)
            {
                a *= -1;
            }
            while (a != 0 && b != 0) {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            if (a > 0){
                return a;
            }
            if (b > 0)
            {
                return b;
            }
            return 0;
        }
        public override bool Equals(object? obg)
        {
            if(obg is fractions F)
            {
                return (numerator == F.numerator && denominator==F.denominator);
            }
            return false;
        }
        public object Clone()
        {
            return new fractions(numerator,denominator);
        }
        public static fractions operator +(fractions A, fractions B)
        {
            int num=0;
            int den=0;
            if (A.denominator == B.denominator)
            {
                num = A.numerator + B.numerator;
            }
            else {
                num = A.numerator * B.denominator + B.numerator * A.denominator;
                den = A.denominator * B.denominator;
                int del = A.GCD(num, den);
                if (del != 0)
                {
                    num/= del;
                    den/= del;
                }
            }
            Console.Write(A+" + "+B+" = ");
            return new fractions(num,den);
        }
        public static fractions operator -(fractions A, fractions B)
        {
            int num = 0;
            int den = 0;
            if (A.denominator == B.denominator)
            {
                num = A.numerator - B.numerator;
            }
            else
            {
                num = A.numerator * B.denominator - B.numerator * A.denominator;
                den = A.denominator * B.denominator;
                int del = A.GCD(num, den);
                if (del != 0)
                {
                    num /= del;
                    den /= del;
                }
            }
            Console.Write(A + " - " + B + " = ");
            return new fractions(num, den);
        }
        public static fractions operator *(fractions A, fractions B)
        {

            Console.Write(A + " * " + B + " = ");
            return new fractions(A.numerator*B.numerator, A.denominator*B.denominator);
        }
        public static fractions operator /(fractions A, fractions B)
        {
            Console.Write(A + " : " + B + " = ");
            return new fractions(A.numerator * B.denominator, A.denominator * B.numerator);
        }
        public static fractions  operator +(fractions A, int B)
        {
            fractions den = new fractions(B,1);
            Console.Write(A + " + " + B + " = ");
            return A+den;
        }
        public static fractions operator -(fractions A, int B)
        {
            fractions den = new fractions(B, 1);
            Console.Write(A + " - " + B + " = ");
            return A - den;
        }
        public static fractions operator *(fractions A, int B)
        {
            fractions den = new fractions(B, 1);
            Console.Write(A + " * " + B + " = ");
            return A * den;
        }
        public static fractions operator /(fractions A, int B)
        {
            fractions den = new fractions(B, 1);
            Console.Write(A + " : " + B + " = ");
            return A / den;
        }
        public static fractions operator +(int A, fractions B)
        {
            fractions den = new fractions(A, 1);
            Console.Write(A + " + " + B + " = ");
            return den + B;
        }
        public static fractions operator -(int A, fractions B)
        {
            fractions den = new fractions(A, 1);
            Console.Write(A + " - " + B + " = ");
            return den - B;
        }
        public static fractions operator *(int A, fractions B)
        {
            fractions den = new fractions(A, 1);
            Console.Write(A + " * " + B + " = ");
            return den * B;
        }
        public static fractions operator /(int A, fractions B)
        {
            fractions den = new fractions(A, 1);
            Console.Write(A + " : " + B + " = ");
            return den / B;
        }
        public fractions sum(fractions B)
        {
            int num = 0;
            int den = 0;
            if (denominator == B.denominator)
            {
                num = numerator + B.numerator;
            }
            else
            {
                num = numerator * B.denominator + B.numerator * denominator;
                den = denominator * B.denominator;
                int del = GCD(num, den);
                if (del != 0)
                {
                    num /= del;
                    den /= del;
                }
            }
            Console.Write(numerator+" / "+denominator+ " + " + B + " = ");
            return new fractions(num, den);
        }
        public fractions minus(fractions B)
        {
            int num = 0;
            int den = 0;
            if (denominator == B.denominator)
            {
                num = numerator - B.numerator;
                den = denominator;
            }
            else
            {
                num = numerator * B.denominator - B.numerator * denominator;
                den = denominator * B.denominator;
                int del = GCD(num, den);
                if (del != 0)
                {
                    num /= del;
                    den /= del;
                }
            }
            Console.Write(numerator + " / " + denominator + " - " + B + " = ");
            return new fractions(num, den);
        }
        public fractions comp(fractions B)
        {
            Console.Write(numerator + " / " + denominator + " * " + B + " = ");
            return new fractions(numerator * B.numerator, denominator * B.denominator);
        }
        public fractions div(fractions B)
        {
            Console.Write(numerator + " / " + denominator + " : " + B + " = ");
            return new fractions(numerator * B.denominator, denominator * B.numerator);
        }
        public fractions sum(int A)
        {
            fractions den = new fractions(A, 1);
            Console.Write(numerator + " / " + denominator + " + " + A + " = ");
            return sum(den);
        }
        public fractions minus(int A)
        {
            fractions den = new fractions(A, 1);
            Console.Write(numerator + " / " + denominator + " - " + A + " = ");
            return minus(den);
        }
        public fractions div(int A)
        {
            fractions den = new fractions(A, 1);
            Console.Write(numerator + " / " + denominator + " : " + A + " = ");
            return div(den);
        }
        public fractions comp(int A)
        {
            fractions den = new fractions(A, 1);
            Console.Write(numerator + " / " + denominator + " * " + A + " = ");
            return comp(den);
        }
        public override string ToString() {
            return numerator + "/" + denominator;
        }
    }
    public class fractions_cach
    {
        private double cach;
        public fractions_cach(double cach)
        {
            this.cach = cach;
        }
        public void Cach_is_NULL()
        {
            cach = 0;
        }
        public override string ToString() {
            return Convert.ToString(cach);
        }
    }
    class Work
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
                        Console.WriteLine("Введите количество мяуконий");
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
                    Console.WriteLine("Введите количество мяуконий");
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
