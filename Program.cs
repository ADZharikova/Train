using System;
using System.Collections.Generic;
using System.IO;

namespace Train
{
    internal class Program
    {
        static Dictionary<string, string> AddTypeOfTrainCars(string name, char delimiter)
        {
            Dictionary<string, string> TypeOfTrainCars = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(name))
            { 
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] keyvalue = line.Split(delimiter);
                    if (keyvalue.Length == 2)
                    {
                        TypeOfTrainCars.Add(keyvalue[0], keyvalue[1]);
                    }
                }
            }

            return TypeOfTrainCars;
        }
        static void Main(string[] args)
        {
            Dictionary<string, string> addTrainCars;
            string name = "Type.txt";
            char delimiter = '=';


            TrainCars trainCars = new TrainCars();
            TrainStation TrainStation = new TrainStation();
            bool isOpen = true;
            string putUser;
            string depature, arrival;
            int passengers;

            //Add type of train cars from file
            addTrainCars = AddTypeOfTrainCars(name, delimiter);
            foreach (var item in addTrainCars)
            {
                var valueTrainCars = Convert.ToInt32(item.Value);
                trainCars.AddType(item.Key, valueTrainCars);
            }

            while (isOpen)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Добро пожаловать в приложение!!!");
                Console.WriteLine("\n");

                TrainStation.ShowInfoAll();
                Console.WriteLine("\n");

                Console.WriteLine("Что хотите сделать?\n1. Отправить новый поезд.\n2. Выйти из программы.\n");
                Console.Write("Действие: ");
                putUser = Console.ReadLine();

                switch (putUser)
                {
                    case "1":

                        Console.WriteLine();
                        Console.Write("Введите город отправления: ");
                        depature = Console.ReadLine().Trim();
                        while (String.IsNullOrEmpty(depature))
                        {
                            Console.Write("Введите город ещё раз: ");
                            depature = Console.ReadLine().Trim();
                        }
                        Console.Write("Введите город прибытия: ");
                        arrival = Console.ReadLine().Trim();
                        while (String.IsNullOrEmpty(arrival))
                        {
                            Console.Write("Введите город ещё раз: ");
                            arrival = Console.ReadLine().Trim();
                        }
                        TrainStation.AddNewTrain(depature, arrival);
                        Console.WriteLine();

                        Console.ForegroundColor=ConsoleColor.DarkGray;
                        Console.WriteLine("Чтобы продать билеты, нажмите любую кнопку.");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        passengers = TrainStation.SellTickets();
                        Console.WriteLine();

                        trainCars.ShowInfo();

                        while (passengers > 0)
                        {
                            Console.WriteLine();
                            Console.Write("Введите название вагона: ");
                            putUser = Console.ReadLine();
                            var i = trainCars.Check(putUser);
                            if (i == 0)
                            {
                                Console.WriteLine("Такого вагона не существует");
                            }
                            else
                            {
                                TrainStation.AddCount();
                            }
                            passengers -= i;
                            Console.WriteLine("Осталось разместить " + passengers + " человек.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Вы точно хотите выйти? (д/н)");
                        putUser= Console.ReadLine();
                        if (putUser == "д")
                        {
                            isOpen = false;
                        }
                        else
                        {
                            Console.WriteLine("Вы будете отправлены в начало программы.");
                        }
                        break;

                    default:
                        Console.WriteLine("Не удалось считать действие. Вы будете отправлены в начало программы.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Для продолжения нажмите любую кнопку");
                Console.ReadKey(true);
                Console.Clear();
            }

            Console.WriteLine("Возвращайтесь!");
        }
    }
}
