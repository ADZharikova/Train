using System;
using System.Collections.Generic;
namespace Train
{
    internal class TrainCars
    {
        private List<TrainCars> _typeOfTrainCars = new List<TrainCars>();
        private string _trainCarType;
        private int _numberOfSeats;
        


        public TrainCars(string name, int number)
        {
            _trainCarType = name;
            _numberOfSeats = number;
        }

        public TrainCars()
        {
        }

        public void AddType(string name, int number)
        {
            _typeOfTrainCars.Add(new TrainCars(name, number));
        }

        public void ShowInfo()
        {
            
            Console.WriteLine("У вагонов есть следующие типы:");
            foreach (var car in _typeOfTrainCars)
            {
                Console.WriteLine(car._trainCarType + ": " + car._numberOfSeats + " мест");
            }
        }

        public int Check(string putUser)
        {
            int j = -1;
            foreach (var car in _typeOfTrainCars)
            {
                if (car._trainCarType.ToLower() == putUser.ToLower())
                {
                    return car._numberOfSeats;
                }
            }

                return 0;
            
            
        }
    }

}
