namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Time t1 = new(r.Next(1, 25), r.Next(0, 60), r.Next(0, 60));
            Time t2 = new(r.Next(1, 25), r.Next(0, 60), r.Next(0, 60));
            Time t3 = new(r.Next(1, 25), r.Next(0, 60), r.Next(0, 60));
            Time t4 = new(r.Next(1, 25), r.Next(0, 60), r.Next(0, 60));

            Console.WriteLine("Time t1: " + t1.ShowTime() + ", it`s " + t1.ShowTimeOfDay());
            Console.WriteLine("Time t2: " + t2.ShowTime() + ", it`s " + t2.ShowTimeOfDay());
            Console.WriteLine("Time t3: " + t3.ShowTime() + ", it`s " + t3.ShowTimeOfDay());
            Console.WriteLine("Time t4: " + t4.ShowTime() + ", it`s " + t4.ShowTimeOfDay() + "\n");

            Time T1 = t1 + t3;
            Time T2 = t4 - t2;
            Console.WriteLine("Time T1 = t1 + t3: " + T1.ShowTime() + ", it`s " + T1.ShowTimeOfDay());
            Console.WriteLine("Time T2 = t4 - t2: " + T2.ShowTime() + ", it`s " + T2.ShowTimeOfDay());

            Console.WriteLine("Is T1 > T2? - " + (T1 > T2 ? "Yes" : "No"));
            Console.WriteLine("Is T1 < T2? - " + (T1 < T2 ? "Yes" : "No"));
            //У якості позначення опівночі було обрано число 24, а не 00.
            //Якщо сума t1+t3 буде більше за 24 години, то в суму буде записан час, t1+t3-24 години, ніби вони перейшли в розряд діб, і порівнюватися буе лише час
            //Якщо при відніманні t4-t2 t2 буде більшим за t4, то буде взята одиниця з умовних діб, і у різність буде записан час t2-t4+24години
        }
    }
}