using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Check_Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            ICheckdomain chd = new Checkdomain();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = GetRandomConsoleColor();

                Console.Write("Enter Your Domain : ");
                string txtdomin = Console.ReadLine();
                if (txtdomin != "")
                {
                    string check = Regex.Match(txtdomin, @"(www.)?([a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3})(\/\S*)?").Groups[2].Value.Split('.')[0];

                    if (check != "")
                    {
                        txtdomin = check;
                    }
                    Console.WriteLine("Please wait it may take while...\n");

                    string[] x = await Task.Run(() => { return chd.domain_all(txtdomin); });

                    Console.WriteLine("We found these domain for you...\n");

                    if (x.Length > 1)
                    {
                        foreach (var item in x)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("We Found Nothing...\n");
                    }
                }
            }
        }
        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            l2:
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            var result = (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
            if (result == ConsoleColor.Black)
            {
                goto l2;
            }
            return result;
        }

    }
}
