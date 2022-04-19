using System;
using System.Collections.Generic;

namespace Train
{
    internal class TrainStation
    {
        private List<Train> _listOfTrains = new List<Train>();
        private static int _id = 0;

        public void AddNewTrain(string depature, string arrival)
        {
            ++_id;
            _listOfTrains.Add(new Train(depature, arrival, _id));
        }

        public int SellTickets()
        {
            Console.WriteLine($"Билеты купили {_listOfTrains[_listOfTrains.Count - 1].NumberOfPassenger} человек");
            return _listOfTrains[_listOfTrains.Count - 1].NumberOfPassenger;
        }

        public void ShowInfoAll()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (_listOfTrains.Count == 0)
            {
                Console.WriteLine("Пока с этого вокзала не ушёл ни один поезд");
            }
            else
            {
                Console.WriteLine("Отправленные поезда :");
                for (int i = 0; i < _listOfTrains.Count; i++)
                {
                    Console.WriteLine($"ИД: {_listOfTrains[i].IdTrain}, Направление: {_listOfTrains[i].Departure} - {_listOfTrains[i].Arrival}, Количество людей в поезде: {_listOfTrains[i].NumberOfPassenger}, Количество вагонов: {_listOfTrains[i].CountofTrainCars}");
                }
            }
            Console.ResetColor();
        }

        public void AddCount()
        {
            _listOfTrains[_listOfTrains.Count - 1].CountTrainCars();
        }
    }
}
