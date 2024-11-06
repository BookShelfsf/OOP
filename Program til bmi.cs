using System;
using BMIMonitor.ReferenceTypes;

namespace BMIMonitor
{
    class Program_til_bmi
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                FirstName = "Lukas",
                LastName = "Haugstad",
                Weight = 70,
                Height = 1.78
            };

            Console.WriteLine($"BMI for {person.FirstName} {person.LastName}: {person.BMI}");
        }
    }
}
