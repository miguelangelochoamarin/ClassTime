namespace ClassTime.Backend
{
    public class Time
    {
        //Fields
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;
        

        //Constructor + sobrecargas
        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour)
        {
            Hour = hour;
        }

        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }

        //Properties
        public int Hour
        {
            get => _hour;
            set => _hour = ValidHour(value);
        }

        public int Minute 
        { 
            get => _minute;
            set => _minute = ValidMinute(value);
        }

        public int Second 
        { 
            get => _second;
            set => _second = ValidSecond(value);
        }

        public int Millisecond { 
            get => _millisecond;
            set => _millisecond = ValidMillisecond(value);
        }


        //Methods
        public Time Add(Time newTime)
        {
            long totalMs = ToMilliseconds() + newTime.ToMilliseconds();
            const long msPerDay = 24L * 60 * 60 * 1000;
            totalMs %= msPerDay;
            int hours = (int)(totalMs / (60 * 60 * 1000));
            totalMs -= hours * 60 * 60 * 1000;
            int minutes = (int)(totalMs / (60 * 1000));
            totalMs -= minutes * 60 * 1000;
            int seconds = (int)(totalMs / 1000);
            int milliseconds = (int)(totalMs - seconds * 1000);

            return new Time(hours, minutes, seconds, milliseconds);
        }

        public bool IsOtherDay(Time newTime)
        {
            long sum = ToMilliseconds() + newTime.ToMilliseconds();
            const long milisecondsAtDay = 24 * 60 * 60 * 1000;
            
            if (sum > milisecondsAtDay) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public long ToMilliseconds()
        {
            try
            {
                long total = ((long)Hour * 60 * 60 + (long)Minute * 60 + Second) * 1000 + Millisecond;
                return total;
            }
            catch
            {
                return 0;
            }
        }

        public long ToSeconds()
        {
            long ms = ToMilliseconds();
            return ms / 1000;
        }

        public long ToMinutes()
        {
            long ms = ToMilliseconds();
            return ms / (60 * 1000);
        }

        public override string ToString()
        {
            DateTime dateTime = new DateTime(1, 1, 1, Hour, Minute, Second, Millisecond);
            return dateTime.ToString("HH:mm:ss.fff tt").ToUpper();
        }
        //metodo para validar quela hora ingreasdo es un valor correcto
        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour), $"The Hour: {hour}, is not valid.");
            }
            return hour;
        }
        //metodo para validar que el milisegundo ingreasdo es un valor correcto
        private int ValidMillisecond(int milisecond)
        {
            if (milisecond < 0 || milisecond > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(milisecond), $" the Millisecond: {milisecond} is not valid.");
            }
            return milisecond;
        }
        //metodo para validar que el minuto ingreasdo es un valor correcto
        private int ValidMinute(int minute) {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute), $"the Minute: {minute} is not valid.");
            }
            return minute;
        }
        //metodo para validar que el segundo ingreasdo es un valor correcto
        private int ValidSecond(int second) {  
            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(second), "Second must be between 0 and 59.");
            }
            return second;
        }
    
    }
}
