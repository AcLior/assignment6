using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    abstract class AppSystem : IComparable // מחלקה אבסטרקטית, מימוש מחדש של ממשק IComparable
    {
        int id; // מספר ייחודי
        protected string appName; // שם אפליקציה    
        protected int price; // מחיר
        DateTime date; // תאריך הורדה למכשיר

        public AppSystem(string appName, int price) // בנאי שמקבל שם ומחיר
        {
            AppName = appName;
            Price = price;
            Date = DateTime.Now; // תאריך הורדה הוא התאריך שמתקבל באותו רגע
            this.id = GetHashCode(); // מספר ייחודי הוא ההאש קוד שנוצר
        }
        public int Id // תכונה ID
        {
            get { return id; }
        }

        public string AppName // תכונה לשם אפליקציה
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

        public int Price // תכונת מחיר
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
                    throw new ArgumentException("The value can't be negative"); // מחיר לא יכול להיות שלילי

                }
            }
        }

        public DateTime Date // תכונת תאריך
        {
            get { return date; }
            set { date = value; }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString() // דריסת מתודת טו-סטרינג, בהתאם למקרה שלנו - הדפסה
        {
            return String.Format("Id: {0} Name: {1} Price: {2} Date: {3}\n", Id, AppName, Price, Date.ToShortDateString());
        }

        abstract public string AppSystemPurpose(); // מתודה אבסטרקטית המחזירה מחרוזת המייצגת את מטרת האפליקציה

        public int CompareTo(Object obj) // מתודת שבודקת האם האובייקטים שווים ע"פ השם
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
