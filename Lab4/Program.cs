namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            //В даному випадку +1 використовується для того, щоб розширити діапазон чисел до 0-60 включно
            Time t1 = new(r.Next(0, Constants.HOURS_IN_DAY), r.Next(0, Constants.MINUTES_IN_HOUR + 1), r.Next(0, Constants.SECONDS_IN_MINUTE + 1));
            Time t2 = new(r.Next(0, Constants.HOURS_IN_DAY), r.Next(0, Constants.MINUTES_IN_HOUR + 1), r.Next(0, Constants.SECONDS_IN_MINUTE + 1));
            Time t3 = new(r.Next(0, Constants.HOURS_IN_DAY), r.Next(0, Constants.MINUTES_IN_HOUR + 1), r.Next(0, Constants.SECONDS_IN_MINUTE + 1));
            Time t4 = new(r.Next(0, Constants.HOURS_IN_DAY), r.Next(0, Constants.MINUTES_IN_HOUR + 1), r.Next(0, Constants.SECONDS_IN_MINUTE + 1));

            Console.WriteLine("Time t1: " + t1.ShowTime() + ", it`s " + t1.ShowTimeOfDay());
            Console.WriteLine("Time t2: " + t2.ShowTime() + ", it`s " + t2.ShowTimeOfDay());
            Console.WriteLine("Time t3: " + t3.ShowTime() + ", it`s " + t3.ShowTimeOfDay());
            Console.WriteLine("Time t4: " + t4.ShowTime() + ", it`s " + t4.ShowTimeOfDay() + "\n");

            Time T1 = t1 + t3;
            Console.WriteLine("Time T1 = t1 + t3: " + T1.ShowTime() + ", it`s " + T1.ShowTimeOfDay());
            Time T2 = t4 - t2;
            Console.WriteLine("Time T2 = t4 - t2: " + T2.ShowTime() + ", it`s " + T2.ShowTimeOfDay());

            Console.WriteLine("Is T1 > T2? - " + (T1 > T2 ? "Yes" : "No"));
            Console.WriteLine("Is T1 < T2? - " + (T1 < T2 ? "Yes" : "No"));
            //Якщо сума t1+t3 буде більше за 24 години, то в суму буде записан час, t1+t3-24 години, ніби вони перейшли в розряд діб, і порівнюватися буе лише час
            //Якщо при відніманні t4-t2 t2 буде більшим за t4, то буде взята одиниця з умовних діб, і у різність буде записан час t2-t4+24години
        }
    }
}