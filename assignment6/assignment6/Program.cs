using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            const double nav = 0.12;
            bool isLogin=true;
            char choice='\0';
            string menu = "1. Download new app \n2.Watch popular navigation app\n3.Navigate with app\n4.Show mobile data\n5.Sort apps\n6.Close moblie\n";
            MobileDevice mobile=new MobileDevice("lior","1234");
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            try
            {
                isLogin = mobile.Login(username,password);

                if (isLogin)
                {
                    do { 
                   

                        Console.WriteLine("Choose what to do:\n" + menu);
                        choice = Char.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case '1':
                                Console.WriteLine("Press 'S' to download Social app or press 'N' for navigation app");
                                choice = char.Parse(Console.ReadLine());
                                Console.WriteLine("Enter app's name");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter app's price");
                                int price = int.Parse(Console.ReadLine());
                                if (choice == 'S')
                                {
                                    
                                    Console.WriteLine("Enter app's rating");
                                    int rating=int.Parse(Console.ReadLine());
                                    Console.WriteLine("Should the app be for organization? (true/false)");
                                    bool isOrg=bool.Parse(Console.ReadLine());
                                    
                                    Social sApp = new Social(name,price,rating,isOrg);
                                    sApp.AddVAT(price);

                                    mobile.AddApp(sApp);
                                }
                                else
                                {
                                    Console.WriteLine("Enter current location");
                                    string currentLocation = Console.ReadLine();
                                    Console.WriteLine("Enter type of car");
                                    TypeOfCar car = (TypeOfCar)Enum.Parse(typeof(TypeOfCar), Console.ReadLine());
                                    NavigationManager navManage = new NavigationManager(currentLocation,car);
                                    Navigation nApp = new Navigation(name,price, navManage);
                                    nApp.AddVAT(price);

                                    mobile.AddApp(nApp);
                                }
                                break;
                            case '2':
                                try
                                {
                                    mobile.PopularNavigationApp();

                                }
                                catch
                                {
                                    
                                    Console.WriteLine("There is no navigation apps");

                                }
                                break;
                            case '3':
                                
                                mobile.ShowListAppNavigation();
                                Console.WriteLine("Enter the app's name");
                                string temp = Console.ReadLine();
                                for (int i = 0; i < mobile.Numofapps; i++) 
                                {
                                    if (mobile.Apps[i].AppName == temp)
                                    {
                                        Console.WriteLine(mobile.ToString());
                                        mobile.ShowListAppNavigation();
                                        Console.WriteLine("Enter address to navigate");
                                        ((Navigation)(mobile.Apps[i])).NvMgr.AddAddress(Console.ReadLine());
                                        Console.WriteLine("Have a nice and safe trip");
                                        break;
                                    }
                                }
                               
                                
                                break;
                            case '4':
                                mobile.ToString();
                                break;
                            case '5':
                                Array.Sort(mobile.Apps);
                                break;
                            case '6':
                                Console.WriteLine("Bye Bye..");
                                break;
                        }
                    
                } while (choice != '6');
                }
            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            



        }
    }
}
