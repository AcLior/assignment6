using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    abstract class AppSystem : IComparable
    {
        int id;
        protected string appName;
        protected int price;
        DateTime date;

        public AppSystem(string appName, int price)
        {
            AppName = appName;
            Price = price;
            Date = DateTime.Now;
            this.id = GetHashCode();
        }
        public int Id
        {
            get { return id; }
        }

        public string AppName
        {
            get { return appName; }
            set
            {
                if (value != null)
                {
                    appName = value;

                }
                else
                {
                    throw new ArgumentNullException("The value can't be null");

                }

            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value;

                }
                else
                {
                    throw new ArgumentException("The value can't be negative");

                }
            }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return String.Format("Id: {0} Name: {1} Price: {2} Date: {3}\n", Id, AppName, Price, Date.ToShortDateString());
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
