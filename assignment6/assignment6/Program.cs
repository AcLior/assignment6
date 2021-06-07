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
            const double nav = 0.12; // קבוע של המע"מ - מקרה של אפליקציית ניווט
            const double soc = 0.13; // כנ"ל - מקרה של אפליקציה חברתית
            bool isLogin=true; // אתחול החיבור לאמת
            char choice = '\0'; // משתנה בחירה - תפריט
            string menu = "1. Download new app \n2. Watch popular navigation app\n3. Navigate with app\n4. Show mobile data\n5. Sort apps\n6. Close moblie\n"; // תפריט
            MobileDevice mobile=new MobileDevice("lior","1234"); // אתחול מכשיר נייד עם שם משתמש וסיסמה
           
            try
            {
                    do {

                        Console.WriteLine("Enter username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string password = Console.ReadLine();
                        isLogin = mobile.Login(username, password); // בדיקה האם הערכים שהתקבלו מהמשתמש תואמים לחשבון שקיים

                    if (isLogin) // במידה והוכנס קלט מתאים
                        {
                        
                        Console.WriteLine("What would you like to do?\n" + menu);
                        choice = char.Parse(Console.ReadLine());
                        if (choice >= '1' && choice <= '6')
                        {
                            switch (choice)
                            {
                                case '1': // קייס ראשון, הורדת אפליקציה מסוג ניווט או חברתית
                                    Console.WriteLine("Press 'S' to download Social app or press 'N' for navigation app");
                                    choice = char.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter app's name");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Enter app's price");
                                    int price = int.Parse(Console.ReadLine());
                                    if (choice == 'S') // אם נבחר חברתית
                                    {

                                        Console.WriteLine("Enter app's rating");
                                        int rating = int.Parse(Console.ReadLine()); // דירוג
                                        Console.WriteLine("Should the app be for organization? (true/false)");
                                        bool isOrg = bool.Parse(Console.ReadLine()); // האם שייכת לארגון

                                        Social sApp = new Social(name, price, rating, isOrg); // אתחול האפליקציה עם הערכים מהמשתמש
                                        sApp.AddVAT(soc); // הוספת המע"מ המתאים

                                        mobile.AddApp(sApp); // הוספת האפליקצייה למכשיר
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter current location");
                                        string currentLocation = Console.ReadLine();
                                        Console.WriteLine("Enter type of car");
                                        TypeOfCar car = (TypeOfCar)Enum.Parse(typeof(TypeOfCar), Console.ReadLine());
                                        NavigationManager navManage = new NavigationManager(currentLocation, car);
                                        Navigation nApp = new Navigation(name, price, navManage); // אתחול אפליקציה עם ערכים מתאימים
                                        nApp.AddVAT(nav); // הוספת מע"מ מתאים

                                        mobile.AddApp(nApp);
                                    }
                                    break;
                                case '2':
                                    try
                                    {
                                        Console.WriteLine(mobile.PopularNavigationApp().ToString()); // צפייה באפליקציית הניווט הפופולרית

                                    }
                                    catch
                                    {

                                        Console.WriteLine("There is no navigation apps"); // תפיסת חריגה במידה ולא קיימת אפליקציית ניווט או שלא אותחלו יעדים

                                    }
                                    break;
                                case '3': // ניווט ליעד באמצעות האפליקציה

                                    mobile.ShowListAppNavigation(); // הצגת אפליקציות הניווט הקיימות
                                    Console.WriteLine("Enter the app's name");
                                    string temp = Console.ReadLine();
                                    for (int i = 0; i < mobile.Numofapps; i++)
                                    {
                                        if (mobile.Apps[i].AppName == temp) // במידה והמשתמש מכניס שם אפליקציה שקיימת
                                        {
                                            Console.WriteLine(((Navigation)(mobile.Apps[i])).NvMgr.CurrentLocation);
                                            ((Navigation)(mobile.Apps[i])).NvMgr.ShowRecentLocations(); // רשימת הכתובות האחרונות
                                            mobile.ShowListAppNavigation();
                                            Console.WriteLine("Enter address to navigate");
                                            ((Navigation)(mobile.Apps[i])).NvMgr.AddAddress(Console.ReadLine()); // הכנסת היעד אליו המשתמש ירצה לנווט
                                            Console.WriteLine("Have a nice and safe trip");
                                            break;
                                        }
                                    }
                                    break;
                                case '4':
                                    Console.WriteLine(mobile.ToString()); // הצגת פרטי המכשיר הסלולרי כולל רשימת האפליקציות
                                    break;
                                case '5':
                                    Array.Sort(mobile.Apps); // מתודה SORT
                                    break;
                                case '6':
                                    Console.WriteLine("Bye Bye..");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number between 1-6");
                        }

                    }
                } while (choice!='6');
                
            }

            
            catch (Exception e) // תפיסת חריגה מתאימה
            {
                Console.WriteLine(e.Message);
                return;
            }
            



        }
    }
}
