using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    abstract class AppSystem:IComparable
    {
        int counter = 0;
        static int id;
        protected string appName;
        protected int price;
        DateTime date;

        public AppSystem(string appName,int price)
        {
            AppName = appName;
            Price = price;
            Date = DateTime.Now;
            Id = ++counter;
        }
        int Id
        {
            get { return id; }
            set { id = value; }
        }

        string AppName
        {
            get { return appName; }
            set 
            {
                if (appName != null)
                {
                    appName = value;

                }
                else
                {
                    throw new ArgumentNullException("The value can't be null");

                }

            }
        }

        int Price
        {
            get { return price; }
            set 
            {
                if (price > 0)
                {
                    price = value;

                }
                else
                {
                    throw new ArgumentException("The value can't be negative");

                }
            }
        }

        DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public override string ToString()
        {
            return String.Format("Id: {0} Name: {1} Price: {2} Date: {3}", Id, AppName, Price, Date);
        }

        abstract public string AppSystemPurpose();

        public int CompareTo(Object obj)
        {
            if (!(obj is AppSystem))
                throw new Exception("this is not a AppSystem type");
            AppSystem appsys = (AppSystem)obj;
            if (AppName == appsys.AppName)
                return 0;
         
            return 1;

        }

    }
}
