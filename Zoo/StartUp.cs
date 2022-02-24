namespace Zoo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Zoo.Models;

    public class StartUp
    {
        private const int MonkeyCriticalHp = 40;
        private const int LionCriticalHp = 50;
        private const int ElephantCriticalHp = 70;


        static void Main(string[] args)
        {
            var zoo = new Park();
            PopulateZoo(zoo);
            var dayCounter = 1;
            var liveAnimals = GetLiveAnimals(zoo);
            while (zoo.Animals.Any(a => a.IsDead == false))
            {
                Console.WriteLine($"Day {dayCounter} - There are {liveAnimals.Count()} animals in the zoo");

                foreach (var animal in liveAnimals)
                {
                    animal.Starvation();
                    switch (animal.GetType().Name)
                    {
                        case "Lion":
                            if (animal.HealthPoints < LionCriticalHp)
                            {
                                animal.IsDead = true;
                                Console.WriteLine("A lion starved to death !!!");
                            }
                            break;
                        case "Monkey":
                            if (animal.HealthPoints < MonkeyCriticalHp)
                            {
                                animal.IsDead = true;
                                Console.WriteLine("A monkey starved to death !!!");
                            }
                            break;
                        case "Elephant":

                            if (animal.HealthPoints < ElephantCriticalHp)
                            {
                                animal.IsDead = true;
                                Console.WriteLine("An elephant starved to death !!!");
                            }
                            break;
                    }
                }
                liveAnimals = GetLiveAnimals(zoo);
                foreach (var animal in liveAnimals)
                {
                    animal.Eat();
                }
                dayCounter++;
                Console.WriteLine("Press Enter...");
                Console.ReadLine();
            }

            Console.WriteLine("No survivors");

        }

        private static List<Animal> GetLiveAnimals(Park zoo)
        => zoo
            .Animals
            .Where(a => a.IsDead == false)
            .ToList();

        private static void PopulateZoo(Park zoo)
        {
            for (int i = 0; i < 5; i++)
            {
                var monkeyEntity = new Monkey();
                var elephantEntity = new Elephant();
                var lionEntity = new Lion();
                zoo.Animals.Add(monkeyEntity);
                zoo.Animals.Add(elephantEntity);
                zoo.Animals.Add(lionEntity);
            }
        }
    }
}
