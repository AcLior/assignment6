using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assignment6
{
    class MobileDevice
    {
        string username; // שם משתמש
        string password; // סיסמה
        bool online; // האם מחובר
        int numoflogins; // מספר חיבורים סה"כ
        AppSystem[] apps; // מערך שמייצג אפליקציות קיימות
        int numofapps; // מספר המייצג מספר אפליקציות בפועל

        public MobileDevice(string name, string pass) // בנאי עם אתחול מתאים
        {
            Username = name;
            Password = pass;
            online = false;
            apps = new AppSystem[0];
            numofapps = 0;
        }
        public string Username
        {
            get => username;
            set
            {
               
               bool result = value.All(char.IsLetter); // בדיקה האם הערך מכיל רק אותיות
                if (result)
                {
                    username = value;
                }
                else
                {
                    throw new ArgumentException("Username can only contain letters");
                }
            }
        }

        public string Password { get => password; set => password = value; }
        public bool Online { get => online; set => online = value; }
        public int Numoflogins { get => numoflogins; set => numoflogins = value; }
        public int Numofapps { get => numofapps; set => numofapps = value; }
        public AppSystem[] Apps { get => apps; set => apps = value; }

       
        public void AddApp(AppSystem app) // מתודה המוסיפה אפליקציה
        {
            AppSystem[] temp;
            for (int i = 0; i < numofapps; i++)
            {
                if (apps[i].CompareTo(app)==0) // אם האפליקציה קיימת כבר, נזרקת חריגה
                {
                    throw new ArgumentException("App already exists");
                }
            }
            temp = apps;
            apps = new AppSystem[++numofapps];
            temp.CopyTo(apps, 0);
            apps[numofapps - 1] = app;
            // עדכון מערך האפליקציות עם שמירה על הסדר
        }
        public void ShowListAppNavigation() // מדפיסה את כל מספרי האפליקציות ניווט ושמותיהן
        {
            Console.WriteLine("Navigation apps: ");
            for (int i = 0; i < numofapps; i++)
            {
                if (apps[i] is Navigation)
                {
                    Console.WriteLine("ID: "+((Navigation)apps[i]).Id +"Name: \n"+ ((Navigation)apps[i]).AppName);
                }
            }
        }
        public override string ToString() // דריסה למתודה, הדפסה בהתאם עם שרשור
        {
            string applications="\n\nApps: \n";
            for (int i = 0; i < numofapps; i++)
            {
                applications +=  apps[i].ToString();
            }
            return String.Format("Username: {0}\nPassword: {1}\nOnline: {2}\nNumber of logins: {3}\nNumber of apps: {4}\n",username,password,online,numoflogins,numofapps + applications);
        }

         public AppSystem PopularNavigationApp() // מתודה המחזירה הפנייה לאפליקציית ניווט עם הכי הרבה יעדים אליהם ניווט המשתמש
        {
            int temp=-1,index=0;
            
            for(int i = 0; i < numofapps; i++)
            {
                if(apps[i] is Navigation)
                {
                    if (((Navigation)(apps[i])).NvMgr.NumOfDestinations > temp)
                    {
                        temp = ((Navigation)(apps[i])).NvMgr.NumOfDestinations;
                        index = i;
                    }
                }
            }
            if (temp == 0)
            {
                return null;
            }
            if (apps[index] is Navigation)
            {
                return apps[index];
            }
            else
            {
                return null;
            }
        }

        public bool Login(string username,string password) // מתודה המקבלת שם משתמש וסיסמה, מגדילה את שדה ההתחברוית באחד
        {
            Numoflogins++;
            if (!(username == Username && password == Password)) // אם השם משתמש והסיסמא לא נכונים
            {
                if (Numoflogins > 3 && Numoflogins < 9) // ובמידה ויש בין 3 ל-9 כניסות
                {
                    Thread.Sleep(15000); // השהייה של 15 שניות
                    return false;
                }
                else if (Numoflogins > 9) // אם מספר ההתחברויות גדול מ-9
                {
                    Online = false; // חיבור מתנתק
                    throw new Exception("The mobile is blocked..");  // זריקת חריגה - הטלפון נחסם
                }
            }                       
            return (username == Username && password == Password); // במידה והשם משתמש והסיסמה נכונים, המתודה מחזירה אמת
        }

    }
}
