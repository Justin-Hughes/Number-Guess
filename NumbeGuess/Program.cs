using System;
namespace NumberGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            Application a = new Application();
            a.Run();
        }
    }

    public class Application
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What range do you want for your number guessing game?");
                Console.WriteLine("Enter the low number");
                int low = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the high number");
                int high = int.Parse(Console.ReadLine());
                Console.WriteLine("Do you want to (1)guess a number or have the (2)computer guess your number?(Esc to Exit)");

                var x = Console.ReadKey().Key;
                if (x == ConsoleKey.Escape) { Environment.Exit(0); }
                bool userGue = x == ConsoleKey.D1 ? true : false;

                if (userGue == true) { UserGuess(low, high); }
                else { ComputerGuess(low, high); }
            }
        }

        public void UserGuess(int low, int high)
        {
            Random num = new Random();
            int comNum = num.Next(low, high);
            bool correct = false;
            int count = 0;
            do
            {
                Console.Clear();
                count++;
                Console.WriteLine("What is your guess?");
                int guess = int.Parse(Console.ReadLine());

                if (guess == comNum)
                {
                    Console.WriteLine($"Good Job! It only took you {count} guesses!");
                    correct = true;
                }
                else if (guess > comNum)
                { Console.WriteLine("Your guess is high"); }
                else
                { Console.WriteLine("Your guess is low"); }
                Console.ReadKey();
            } while (correct == false);
        }
        public void ComputerGuess(int low, int high)
        {
            bool correct;
            int count = 0;
            do
            {
                count++;
                Console.Clear();
                int temp;

                if (high == low + 1) { temp = high; }
                else { temp = (low + high) / 2; }

                Console.WriteLine(temp);
                Console.WriteLine("Is the number correct?(y/n)");

                ConsoleKey? v = Console.ReadKey().Key;
                Console.WriteLine();

                correct = v == ConsoleKey.Y ? true : false;

                if (correct == false)
                {
                    Console.WriteLine("Is (1)high or (2)low?");

                    ConsoleKey? x = null;
                    x = Console.ReadKey().Key;
                    Console.WriteLine();
                    if (x == ConsoleKey.D1) { high = temp; }
                    else { low = temp; }
                }
            } while (correct == false);
            Console.WriteLine($"It took {count} to guess correctly");
            Console.ReadLine();
        }
    }
}
