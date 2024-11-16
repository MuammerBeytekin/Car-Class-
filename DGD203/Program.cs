using System;
using DGD203;

namespace ProgramConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan araba bilgilerini al
            Console.Write("Enter the car's color: ");
            string color = Console.ReadLine();

            Console.Write("Enter the license number: ");
            string licenseNo = Console.ReadLine();

            Console.Write("Enter the manufacturer: ");
            string make = Console.ReadLine();

            Console.Write("Enter the year of production: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the fuel capacity (L): ");
            int fuelCapacity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the engine horsepower: ");
            int horsepower = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the engine juice type (e.g., Petrol, Diesel, Electric): ");
            string engineType = Console.ReadLine();

            // Zoominator ve JuiceCan nesnelerini oluştur
            Zoominator engine = new Zoominator(horsepower, engineType);
            JuiceCan fuelTank = new JuiceCan(fuelCapacity);

            // Araba nesnesini oluştur
            Car myCar = new Car(color, licenseNo, make, year, engine, fuelTank);

            Console.WriteLine("\nYour ride is ready. Check it out:");
            Console.WriteLine(myCar);

            string choice;
            do
            {
                Console.WriteLine("\n--- What's your next move? ---");
                Console.WriteLine("1 - Start the Zoominator");
                Console.WriteLine("2 - Stop the Zoominator");
                Console.WriteLine("3 - Zoom Away");
                Console.WriteLine("4 - Slow Down");
                Console.WriteLine("5 - Refill the JuiceCan");
                Console.WriteLine("6 - Show Car Details");
                Console.WriteLine("0 - Exit");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        myCar.Engine.Ignite();
                        break;
                    case "2":
                        myCar.Engine.Chill();
                        myCar.Halt(); // Motor durunca hız sıfırlanıyor
                        break;
                    case "3":
                        myCar.Zoom();
                        break;
                    case "4":
                        myCar.Slow();
                        break;
                    case "5":
                        Console.Write("How much juice to refill (L)? ");
                        int juiceAmount = Convert.ToInt32(Console.ReadLine());
                        myCar.FuelTank.Rejuice(juiceAmount);
                        Console.WriteLine($"JuiceCan refilled! Current juice: {myCar.FuelTank.CurrentJuice} L");
                        break;
                    case "6":
                        Console.WriteLine(myCar);
                        break;
                    case "0":
                        Console.WriteLine("Goodbye! Drive safe.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != "0");
        }
    }
}
