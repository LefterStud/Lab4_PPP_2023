

using Microsoft.VisualBasic;

namespace Lab4
{
    /// <summary>
    /// Перелік часів доби.
    /// </summary>
    enum TimeOfDay
    {
        morning = 0,
        day = 1,
        evening = 2,
        night = 3
    }
    /// <summary>
    /// Клас Time є простою структурою для роботи з часом.
    /// Він містить години, хвилини та секунди, а також надає певні методи для роботи з часом.
    /// </summary>
    /// 
    internal class Time
    {
        private int _hours;
        private int _minutes;
        private int _seconds;
        private int errorCode = 0;

        /// <summary>
        /// Створює новий екземпляр класу Time з заданими значннями годин, хвилин та секунд.
        /// </summary>
        /// <param name="hour">Години (от 0 до 23).</param>
        /// <param name="minute">Хвилини (от 0 до 59).</param>
        /// <param name="second">Секунди (от 0 до 59).</param>
        public Time(int hour, int minute, int second)
        {
            Hours = hour;
            Minutes = minute;
            Seconds = second;
        }

        /// <summary>
        /// Сеттер та геттер для номера помилки.
        /// </summary>
        public int ErrorCode
        {
            get => errorCode;
            set => errorCode = value;
        }

        /// <summary>
        /// Сеттер та геттер для поля _hours.
        /// Години від 0 до 23.
        /// </summary>
        public int Hours
        {
            get => _hours;
            set
            {
                if (value > 0 && value <= Constants.HOURS_IN_DAY)
                {
                    _hours = (value == Constants.HOURS_IN_DAY) ? 0 : value;
                }
                else
                {
                    ErrorCode = 1;
                }
            }
        }

        /// <summary>
        /// Сеттер та геттер для поля _minutes.
        /// Хвилини від 0 до 59.
        /// </summary>
        public int Minutes
        {
            get => _minutes;
            set
            {
                if (value > 0 && value <= Constants.MINUTES_IN_HOUR)
                {
                    _minutes = value;
                }
                else
                {
                    ErrorCode = 2;
                }
            }
        }

        /// <summary>
        /// Сеттер та геттер для поля _seconds.
        /// Секунди від 0 до 59.
        /// </summary>
        public int Seconds
        {
            get => _seconds;
            set
            {
                if (value > 0 && value < Constants.SECONDS_IN_MINUTE)
                {
                    _seconds = value;
                }
                else
                {
                    errorCode = 3;
                }
            }
        }

        /// <summary>
        /// Складання часів за допомогою перегруженого оператора "+".
        /// </summary>
        /// <param name="left">Перший об'єкт класу Time, що додається.</param>
        /// <param name="right">Другий об'єкт класу Time, що додається.</param>
        /// <remarks>
        /// Знаходиться загальне число секунд обох часів, воно складується, 
        /// і далі обчислюється кількість повних годин, хвилин і секунд в даній загальній кількості секунд
        /// </remarks>
        /// <returns>
        /// Новий об'єкт Time.
        /// </returns>
        public static Time operator +(Time left, Time right)
        {
            int totalSeconds = GetTotalSeconds(left) + GetTotalSeconds(right);
            if (totalSeconds > Constants.SECONDS_IN_DAY)
            {
                totalSeconds %= Constants.SECONDS_IN_DAY;
            }
            int newHour = totalSeconds / Constants.SECONDS_IN_HOUR;
            int newMinute = (totalSeconds % Constants.SECONDS_IN_HOUR) / Constants.MINUTES_IN_HOUR;
            int newSecond = totalSeconds % Constants.SECONDS_IN_MINUTE;
            return new Time(newHour, newMinute, newSecond);
        }

        /// <summary>
        /// Віднімання часів за допомогою перегруженого оператора "-".
        /// </summary>
        /// <param name="left">Перший об'єкт класу Time, що віднімається.</param>
        /// <param name="right">Другий об'єкт класу Time, що віднімається.</param>
        /// <remarks>
        /// Даний оператор працює за рахунок викорситання оператора "+", 
        /// з інвертованом вхідним значенням параметру right
        /// </remarks>
        /// <returns>
        /// Новий об'єкт Time.
        /// </returns>
        public static Time operator -(Time left, Time right)
        {
            Time result;
            // Такий метод подання від'ємника був обран через неможливість одразу створити екземпляр класу Time з від'ємними значеннями,
            // оскільки в setter є умова, що час не може бути від'ємний(додано для введення даних)
            Time tempTime = new Time(right.Hours, right.Minutes, right.Seconds);
            tempTime._hours = -right.Hours;
            tempTime._minutes = -right.Minutes;
            tempTime._seconds = -right.Seconds;
            if (GetTotalSeconds(left) < GetTotalSeconds(right))
            {
                tempTime._hours = -right.Hours + Constants.HOURS_IN_DAY;
                result = left + tempTime;
            }
            else
            {
                result = left + tempTime;
            }
            return result;
        }

        /// <summary>
        /// Порівняння часів за допомогою перегруженого оператора "<".
        /// </summary>
        /// <param name="left">Перший об'єкт класу Time, що порівнюється.</param>
        /// <param name="right">Другий об'єкт класу Time, що порівнюється.</param>
        /// <returns>
        /// Булеве значення.
        /// </returns>
        public static bool operator <(Time left, Time right)
        {
            return GetTotalSeconds(left) < GetTotalSeconds(right);
        }

        /// <summary>
        /// Порівняння часів за допомогою перегруженого оператора ">".
        /// </summary>
        /// <param name="left">Перший об'єкт класу Time, що порівнюється.</param>
        /// <param name="right">Другий об'єкт класу Time, що порівнюється.</param>
        /// <returns>
        /// Булеве значення.
        /// </returns>
        public static bool operator >(Time left, Time right)
        {
            return GetTotalSeconds(left) > GetTotalSeconds(right);
        }

        /// <summary>
        /// Функція показу часу.
        /// </summary>
        /// <returns>
        /// Строка з часом у форматі ГГ:ХХ:СС.
        /// </returns>
        public string ShowTime()
        {
            return ErrorCode > 0 ? Errors.GetError(ErrorCode) : string.Format("{0:D2}:{1:D2}:{2:D2}", _hours, _minutes, _seconds);
        }

        /// <summary>
        /// Функція показу часу доби.
        /// </summary>
        /// <returns>
        /// Строка з назвою часу доби.
        /// </returns>
        public string ShowTimeOfDay()
        {
            if (Hours < Constants.LIMIT_OF_NIGHT)
            {
                return $"{(TimeOfDay)3}";
            }
            else if (Hours < Constants.LIMIT_OF_MORNING)
            {
                return $"{(TimeOfDay)0}";
            }
            else if (Hours < Constants.LIMIT_OF_DAY)
            {
                return $"{(TimeOfDay)1}";
            }
            else if (Hours <= Constants.LIMIT_OF_EVENING)
            {
                return $"{(TimeOfDay)2}";
            }
            else
            {
                return ErrorCode > 0 ? Errors.GetError(ErrorCode) : "";
            }
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
            return t.Seconds + t.Minutes * Constants.SECONDS_IN_MINUTE + t.Hours * Constants.SECONDS_IN_HOUR;
        }
    }
}

