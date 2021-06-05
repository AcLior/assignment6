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
        public int numOfDest;

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

        string[] Destinations { get; set; }
      

        int NumOfDestinations
        {
            get { return numOfDest; }
            set { numOfDest = value; }
        }
        public override string ToString()
        {
            return String.Format("Type of car: {0} Current Location: {1} Amount of destinations: {2}", CarType, CurrentLocation, NumOfDestinations);
        }

        public void ShowRecentLocations() //מיקומים בפועל?
        {
            foreach (string dest in Destinations)
            {
                if (dest != null)
                {
                    Console.WriteLine(dest+", ");
                }
            }
        }

        public void AddAddress(string destAddress)
        {
            string[] temp;
            if (!CheckDestination(destAddress))
            {
                temp = Destinations;
                Destinations = new string[++NumOfDestinations];
                temp.CopyTo(Destinations, 0);
                Destinations[NumOfDestinations - 1] = destAddress;
            }
            else
            {
                Console.WriteLine("The address already exist");
            }
        }
        
        public bool CheckDestination(string address)
        {
            for(int i = 0; i < NumOfDestinations; i++)
            {
                if (address == destinations[i])
                {
                    return true;
                }
                
            }
            return false;
        }
        
    }
}
