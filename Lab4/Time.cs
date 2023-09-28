

namespace Lab4
{
    internal class Time
    {
        private int hour;
        private int minute;
        private int second;

        public Time(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        /// <summary>
        /// Складання часів за допомогою перегруженого оператора "+".
        /// </summary>
        /// <param name="t1">Перший об'єкт класу Time, що додається.</param>
        /// <param name="t2">Другий об'єкт класу Time, що додається.</param>
        /// <returns>
        /// Новий об'єкт Time.
        /// </returns>
        public static Time operator +(Time t1, Time t2)
        {
            int totalSeconds = GetTotalSeconds(t1) + GetTotalSeconds(t2);
            int newHour = totalSeconds / 3600;
            int newMinute = (totalSeconds % 3600) / 60;
            int newSecond = totalSeconds % 60;
            if (newHour > 24)
            {
                newHour -= 24;//Віднімаємо 24 години
            }
            return new Time(newHour, newMinute, newSecond);
        }

        /// <summary>
        /// Віднімання часів за допомогою перегруженого оператора "-".
        /// </summary>
        /// <param name="t1">Перший об'єкт класу Time, що віднімається.</param>
        /// <param name="t2">Другий об'єкт класу Time, що віднімається.</param>
        /// <returns>
        /// Новий об'єкт Time.
        /// </returns>
        public static Time operator -(Time t1, Time t2)
        {
            int resultSeconds = GetTotalSeconds(t1) - GetTotalSeconds(t2);
            if (resultSeconds < 0)
            {
                resultSeconds += 86400;//Запозиуємо 24 години
            }
            int newHour = resultSeconds / 3600;
            int newMinute = (resultSeconds % 3600) / 60;
            int newSecond = resultSeconds % 60;
            return new Time(newHour, newMinute, newSecond);
        }

        /// <summary>
        /// Порівняння часів за допомогою перегруженого оператора "<".
        /// </summary>
        /// <param name="t1">Перший об'єкт класу Time, що порівнюється.</param>
        /// <param name="t2">Другий об'єкт класу Time, що порівнюється.</param>
        /// <returns>
        /// Булеве значення.
        /// </returns>
        public static bool operator <(Time t1, Time t2)
        {
            return GetTotalSeconds(t1) < GetTotalSeconds(t2);
        }

        /// <summary>
        /// Порівняння часів за допомогою перегруженого оператора ">".
        /// </summary>
        /// <param name="t1">Перший об'єкт класу Time, що порівнюється.</param>
        /// <param name="t2">Другий об'єкт класу Time, що порівнюється.</param>
        /// <returns>
        /// Булеве значення.
        /// </returns>
        public static bool operator >(Time t1, Time t2)
        {
            return GetTotalSeconds(t1) > GetTotalSeconds(t2);
        }

        /// <summary>
        /// Функція показу часу.
        /// </summary>
        /// <returns>
        /// Строка з часом у форматі ГГ:ХХ:СС.
        /// </returns>
        public string ShowTime()
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        }

        /// <summary>
        /// Функція показу часу доби.
        /// </summary>
        /// <returns>
        /// Строка з назвою часу доби.
        /// </returns>
        public string ShowTimeOfDay()
        {
            string timeOfDay = "";
            if (hour >= 6 && hour < 12)
            {
                timeOfDay = "morning";
            }
            if (hour >= 12 && hour < 18)
            {
                timeOfDay = "day";
            }
            if (hour >= 18 && hour < 24)
            {
                timeOfDay = "evening";
            }
            if (hour < 6 || hour == 24)
            {
                timeOfDay = "night";
            }
            return timeOfDay;
        }

        /// <summary>
        /// Функція розрахунку кількості секунд в часі, формату ГГ:ХХ:СС.
        /// </summary>
        /// <param name="t">Об'єкт класу Time, що обраховується.</param>
        /// <returns>
        /// Числове значення секунд у вхідному часі.
        /// </returns>
        private static int GetTotalSeconds(Time t)
        {
            return t.second + t.minute * 60 + t.hour * 3600;
        }

    }
}

