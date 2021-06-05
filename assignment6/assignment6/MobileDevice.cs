using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    class MobileDevice
    {
        string username;
        string password;
        bool online;
        int numoflogins;
        AppSystem[] apps;
        int numofapps;

        public string Username
        {
            get => username;
            set
            {
                bool result = username.All(char.IsLetter);
                if (result)
                {
                    username = value;
                }
                else
                {
                    throw new ArgumentNullException("Username can only contain letters");
                }
            }
        }

        public string Password { get => password; set => password = value; }
        public bool Online { get => online; set => online = value; }
        public int Numoflogins { get => numoflogins; set => numoflogins = value; }
        public int Numofapps { get => numofapps; set => numofapps = value; }
        public AppSystem[] Apps { get => apps; set => apps = value; }

        public MobileDevice(string username, string password)
        {
            Username = username;
            Password = password;
            online = false;
            apps = new AppSystem[0];
            numofapps = 0;
        }
        public void AddApp(AppSystem app) //?
        {
            AppSystem[] temp;
            for (int i = 0; i < numofapps; i++)
            {
                if (apps[i].CompareTo(app)!=0)
                {
                    throw new ArgumentException("App already exists");
                }
            }
            temp = apps;
            apps = new AppSystem[++numofapps];
            temp.CopyTo(apps, 0);
            apps[numofapps - 1] = app;
        }
        public void showListAppNavigation()
        {
            Console.WriteLine("Navigation apps: ");
            for (int i = 0; i < numofapps; i++)
            {
                if (apps[i] is Navigation)
                {
                    Console.WriteLine(apps[i].PrintNav());
                }
            }
        }
        public override string ToString()
        {
            string applications="Apps: ";
            for (int i = 0; i < numofapps; i++)
            {
                applications +=  apps[i].ToString();
            }
            return String.Format("Username: {0}\nPassword: {1}\nOnline: {3}\nNumber of logins: {4}\nNumber of apps: {5}",username,password,online,numoflogins,numofapps) + applications;
        }
        
    }
}
