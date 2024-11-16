using System;

namespace DGD203
{
    
    public class Zoominator
    {
        public int Horsepower { get; private set; } 
        public string JuiceType { get; private set; } 
        public bool IsPurring { get; private set; } 

        public Zoominator(int horsepower, string juiceType)
        {
            Horsepower = horsepower;
            JuiceType = juiceType;
            IsPurring = false; 
        }

        public void Ignite()
        {
            IsPurring = true;
            Console.WriteLine("The Zoominator is purring now. Ready to go!");
        }

        public void Chill()
        {
            IsPurring = false;
            Console.WriteLine("The Zoominator has been shut down. Time to relax.");
        }
    }

    
    public class JuiceCan
    {
        public int MaxJuice { get; private set; } 
        public int CurrentJuice { get; private set; } 

        public JuiceCan(int maxJuice)
        {
            MaxJuice = maxJuice;
            CurrentJuice = maxJuice; 
        }

        public void SlurpJuice(int amount)
        {
            if (amount > 0)
            {
                CurrentJuice = Math.Max(0, CurrentJuice - amount); 
            }
        }

        public void Rejuice(int amount)
        {
            if (amount > 0)
            {
                CurrentJuice = Math.Min(MaxJuice, CurrentJuice + amount); 
            }
        }
    }

    
    public class Car
    {
        public string Color { get; set; }
        public string LicenseNo { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public int ZoomLevel { get; private set; } 
        public Zoominator Engine { get; private set; }
        public JuiceCan FuelTank { get; private set; }

        public Car(string color, string licenseNo, string make, int year, Zoominator engine, JuiceCan fuelTank)
        {
            Color = color;
            LicenseNo = licenseNo;
            Make = make;
            Year = year;
            Engine = engine;
            FuelTank = fuelTank;
            ZoomLevel = 0; 
        }

        public void Zoom()
        {
            if (!Engine.IsPurring)
            {
                Console.WriteLine("You can't zoom while the Zoominator is snoozing!");
                return;
            }

            if (FuelTank.CurrentJuice > 0)
            {
                ZoomLevel += 10; 
                FuelTank.SlurpJuice(5); 
                Console.WriteLine($"Zooming! Speed: {ZoomLevel} km/h, Juice left: {FuelTank.CurrentJuice} L");
            }
            else
            {
                Console.WriteLine("Out of juice! Time to refill your JuiceCan.");
            }
        }

        public void Slow()
        {
            if (ZoomLevel > 0)
            {
                ZoomLevel -= 10;
                Console.WriteLine($"Slowing down... Speed: {ZoomLevel} km/h");
            }
            else
            {
                Console.WriteLine("Your ride is already at a standstill.");
            }
        }

        public void Halt()
        {
            ZoomLevel = 0;
            Console.WriteLine("The car has come to a complete stop. No more zoom.");
        }

        public override string ToString()
        {
            return $"Make: {Make}\nYear: {Year}\nLicense No: {LicenseNo}\nColor: {Color}\nJuice Capacity: {FuelTank.MaxJuice} L\nCurrent Juice: {FuelTank.CurrentJuice} L\nZoom Level: {ZoomLevel} km/h\nEngine: {Engine.Horsepower} HP ({Engine.JuiceType})";
        }
    }
}
