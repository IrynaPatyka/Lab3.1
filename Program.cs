using System;
class Parent
{
    protected double Pole1; // Відстань в км
    protected double Pole2; // Вартість проїзду 1 км

    public Parent(double pole1, double pole2)
    {
        Pole1 = pole1;
        Pole2 = pole2;
    }
    public virtual void Print()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Відстань в км: {Pole1} Вартість проїзду 1 км: {Pole2}");
    }
    public virtual double Metod()
    {
        return Pole1 * Pole2;
    }
}
class Child1 : Parent
{
    private double Pole3; // Швидкість в км/год
    private double Pole4; // Висота в км

    public Child1(double pole1, double pole2, double pole3, double pole4) : base(pole1, pole2)
    {
        Pole3 = pole3;
        Pole4 = pole4;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Швидкість: {Pole3} Висота: {Pole4} ");
    }

    public override double Metod()
    {
        return base.Metod() + Pole3 * Pole4;
    }
}
class Child2 : Parent
{
    private int Pole5; // Кількість палуб
    private int Pole6; // Номер палуби

    public Child2(double pole1, double pole2, int pole5, int pole6) : base(pole1, pole2)
    {
        Pole5 = pole5;
        Pole6 = pole6;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Кількість палуб: {Pole5} Номер палуби: {Pole6}");
    }

    public override double Metod()
    {
        double totalCost = base.Metod();
        if (Pole6 == 3 || Pole6 == 4)
        {
            totalCost += (totalCost * Pole5 * Pole5) / 100;
        }
        return totalCost;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Parent parent = new Parent(1000, 0.5);
        Child1 child1 = new Child1(1000, 0.5, 800, 10);
        Child2 child2 = new Child2(1000, 0.5, 5, 2);

        
        parent.Print();
        Console.WriteLine($"Звичайний. Ціна 1 білета: {parent.Metod()}");
        Console.WriteLine();
        child1.Print();
        Console.WriteLine($"Літак. Ціна 1 білета: {child1.Metod()}");
        Console.WriteLine();
        child2.Print();
        Console.WriteLine($"Корабель. Ціна одного білета: {child2.Metod()}");
    }
}
