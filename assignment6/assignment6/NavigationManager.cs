using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    enum TypeOfCar{Private=1,Motorcycle,Taxi};
    class NavigationManager
    {
        string currentLocation;
        string[] destinations;
        int numOfDest;

        public NavigationManager(string currentLocation,TypeOfCar car)
        {
            CurrentLocation = currentLocation;
            CarType = car;
            destinations = new string[0];
            NumOfDestinations = 0;
        }

        TypeOfCar CarType { get; set; }
       
        string CurrentLocation
        {
            get { return currentLocation; }
            set { currentLocation = value; }
        }

        string[] Destinations
        {
            get { return destinations; }
            set { destinations = value; }
        }

        int NumOfDestinations
        {
            get { return numOfDest; }
            set { numOfDest = value; }
        }
        public override string ToString()
        {
            return String.Format("Type of car: {0} Current Location: {1} Amount of destinations: {2}", CarType, CurrentLocation, NumOfDestinations);
        }
    }
}
