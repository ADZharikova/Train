using System;

namespace Train
{
    internal class Train
    {
        public string Departure { get; private set; }
        public string Arrival { get; private set; }
        private Random _random = new Random();
        public int NumberOfPassenger { get; private set; }
        public int CountofTrainCars { get; private set; } = 0;
        public int IdTrain { get; private set; }


        public Train(string depature, string arrival, int id)
        {
            IdTrain = id;
            Departure = depature;
            Arrival = arrival;
            NumberOfPassenger = _random.Next(0, 250);
        }

        public void CountTrainCars()
        {
            CountofTrainCars++;
        }
    }
}
