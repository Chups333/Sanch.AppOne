using Sanch.Fitness.BL.Controller;
using Sanch.Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //работа с локализацией
            // var culture = CultureInfo.CurrentCulture(); культура текущая
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Sanch.Fitness.CMD.Languages.Message", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {

                Console.WriteLine("Введите пол");
                var gender = Console.ReadLine();
                var birthDate = ParseDataTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");


                userController.SetNawUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);




            while (true)
            {

                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("A - ввести упражнения");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);


                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exercises = EnterExercise();
                        exerciseController.Add(exercises.Activity, exercises.Begin, exercises.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{item.Activity.Name} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;




                }
            
            Console.ReadLine();

            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения: ");
            var name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Название упражнения не может быть пустым");
                Console.Write("Введите название упражнения: ");
                name = Console.ReadLine();
            }

            var energy = ParseDouble("расход каллорий в минуту");
            var begin = ParseDataTime("начало упражнения");
            var end = ParseDataTime("окончание упражнения");
            var activity = new Activity(name, energy);

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите название продукта: ");
            var food = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(food))
            {
                Console.WriteLine("Имя продукта не может быть пустым");
                Console.Write("Введите имя продукта: ");
                food = Console.ReadLine();
            }

            var calories = ParseDouble("каллорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weightFood = ParseDouble("вес порции");
            var product = new Food(food, calories, proteins, fats, carbs);

            return (product, weightFood);

        }

        private static DateTime ParseDataTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Введите {value} ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }
    }
}
