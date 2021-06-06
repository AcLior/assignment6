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
        string username;
        string password;
        bool online;
        int numoflogins;
        AppSystem[] apps;
        int numofapps;

        public MobileDevice(string name, string pass)
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
               
               bool result = value.All(char.IsLetter);
                if (result)
                {
                    username = value;
                }
                else if(value==null)
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
        public void ShowListAppNavigation()
        {
            Console.WriteLine("Navigation apps: ");
            for (int i = 0; i < numofapps; i++)
            {
                if (apps[i] is Navigation)
                {
                    Console.WriteLine("ID: "+((Navigation)apps[i]).Id +"Name: "+ ((Navigation)apps[i]).AppName);
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

         public AppSystem PopularNavigationApp()
        {
            int temp=0,index=0;
            
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
            return apps[index];
        }

        public bool Login(string username,string password)
        {
            Numoflogins++;
            if (Numoflogins > 3 && Numoflogins < 9)
            {
                Thread.Sleep(15000);
                return false;
            }
            else if (Numoflogins>9)
            {
                Online = false;
                throw new Exception("The mobile is blocked..");
            }
            return username == Username && password == Password;
        }

    }
}
