using System;

using System.Globalization;

namespace HourAndDays
{
    class Program
    {
        static void Main(string[] args)
        {

            NumberStyles style;

            style = NumberStyles.Any;// but allows Thousand

            var str = promptInput();

            var min = validate(str, style);

            CalculateHourDays(min);

            Console.ReadKey();
        }

        private static void CalculateHourDays(int min)
        {
            var hours = (int)(min / 60);

            var days = (int)(hours / 24);

            if (hours <= 0 && min >= 30)
                hours = 1;
            Console.WriteLine("Hours\t:{1}\nDays\t:{0}", days, hours);


        }

        private static string promptInput()
        {
            var str = "";


            Console.WriteLine("please enter numbers only");
            Console.Write("enter minutes: ");
            str = Console.ReadLine();

            return str;
        }

        public static int validate(string str, NumberStyles style)
        {
            CultureInfo provider;

            provider = CultureInfo.InvariantCulture;
            var min = 0;
            while (!Int32.TryParse(str, style, provider, out min))
            {
                str = promptInput();

                if (str.Contains("."))
                    Console.WriteLine("not decimal point allowed");


            }

            return min;
        }
    }
}
