using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
    
    
            Fraction f1 = new Fraction();
            Console.WriteLine(f1.GetFractionString());
            Console.WriteLine(f1.GetDecimalValue());

            Fraction f2 = new Fraction(5);
            Console.WriteLine(f2.GetFractionString());
            Console.WriteLine(f2.GetDecimalValue());

            Fraction f3 = new Fraction(3, 4);
            Console.WriteLine(f3.GetFractionString());
            Console.WriteLine(f3.GetDecimalValue());

            Fraction f4 = new Fraction(1, 3);
            Console.WriteLine(f4.GetFractionString());
            Console.WriteLine(f4.GetDecimalValue());

            f1.SetTop(7);
            f1.SetBottom(10);
            Console.WriteLine(f1.GetFractionString());
            Console.WriteLine(f1.GetDecimalValue());

            int top = f2.GetTop();
            int bottom = f2.GetBottom();
            Console.WriteLine($"Top: {top}, Bottom: {bottom}");
        }
}