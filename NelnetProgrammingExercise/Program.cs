using NelnetProgrammingExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NelnetProgrammingExercise
{
    class Program
    {
        private static PersonModel[] People;
        private static PetModel[] Pets;

        #region Initialization

        private static void SetupObjects()
        {
            People = new PersonModel[]
            {
                new PersonModel()
                {
                    Name = "Dalinar",
                    PreferredClassification = PetClassification.Mammal,
                    PreferredType = PetType.Snake,
                    PreferredWeight = WeightClassification.Medium,
                    TypeOverrides = new HashSet<PetType> { PetType.Spider },
                    ClassificationOverrides = new HashSet<PetClassification> { PetClassification.Arachnid },
                },
                new PersonModel()
                {
                    Name = "Kaladin",
                    PreferredClassification = PetClassification.Bird,
                    PreferredType = PetType.Goldfish,
                    PreferredWeight = WeightClassification.ExtraSmall,
                    WeightClassificationOverrides = new HashSet<WeightClassification> { WeightClassification.Medium, WeightClassification.Large }
                }
            };

            Pets = new PetModel[]
            {
                new PetModel()
                {
                    Name = "Garfield",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Cat,
                    Weight = 20.0
                },
                new PetModel()
                {
                    Name = "Odie",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Dog,
                    Weight = 15.0
                },
                new PetModel()
                {
                    Name = "Peter Parker",
                    Classification = PetClassification.Arachnid,
                    Type = PetType.Spider,
                    Weight = 0.5
                },
                new PetModel()
                {
                    Name = "Kaa",
                    Classification = PetClassification.Reptile,
                    Type = PetType.Snake,
                    Weight = 25.0
                },
                new PetModel()
                {
                    Name = "Nemo",
                    Classification = PetClassification.Fish,
                    Type = PetType.Goldfish,
                    Weight = 0.5
                },
                new PetModel()
                {
                    Name = "Alpha",
                    Classification = PetClassification.Fish,
                    Type = PetType.Betta,
                    Weight = 0.1
                },
                new PetModel()
                {
                    Name = "Splinter",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Rat,
                    Weight= 0.5
                },
                new PetModel()
                {
                    Name = "Coco",
                    Classification = PetClassification.Bird,
                    Type = PetType.Parrot,
                    Weight = 6.0
                },
                new PetModel()
                {
                    Name = "Tweety",
                    Classification = PetClassification.Bird,
                    Type = PetType.Canary,
                    Weight = 0.05
                }
            };
        }

        #endregion

        #region DecidingLogic
        private static int GetMatchingScore(PersonModel person, PetModel pet)
        {
            int score = 0;

            if (person.PreferredClassification == pet.Classification) score += 1;
            if (person.PreferredType == pet.Type) score += 1;
            if (person.PreferredWeight == GetWeightClass(pet.Weight)) score += 1;

            if (person.TypeOverrides.Contains(pet.Type)) return score - 1;
            if (person.ClassificationOverrides.Contains(pet.Classification)) return score - 1;
            if (person.WeightClassificationOverrides.Contains(GetWeightClass(pet.Weight))) return score - 1;

            return score;
        }

        private static bool IsGood(PersonModel person, PetModel pet)
        {
            return !person.TypeOverrides.Contains(pet.Type) &&
                   !person.ClassificationOverrides.Contains(pet.Classification) &&
                   !person.WeightClassificationOverrides.Contains(GetWeightClass(pet.Weight)) &&
                   (person.PreferredClassification == pet.Classification ||
                   person.PreferredType == pet.Type ||
                   person.PreferredWeight == GetWeightClass(pet.Weight));
        }

        private static WeightClassification GetWeightClass(double weight)
        {
            if (weight > 30.0)
                return WeightClassification.ExtraLarge;
            else if (weight > 15.0 && weight <= 30.0)
                return WeightClassification.Large;
            else if (weight > 5.0 && weight <= 15.0)
                return WeightClassification.Medium;
            else if (weight > 1.0 && weight <= 5.0)
                return WeightClassification.Small;
            else if (weight > 0 && weight <= 1.0)
                return WeightClassification.ExtraSmall;
            else
                return WeightClassification.None;
        }

        #endregion

        static void Main(string[] args)
        {
            SetupObjects();

            foreach (PersonModel person in People)
            {
                Console.WriteLine($"Pets for {person.Name}:");

                var petResults = Pets
                    .Select(pet => new { Pet = pet, Score = GetMatchingScore(person, pet), IsGood = IsGood(person, pet) })
                    .OrderByDescending(result => result.Score)
                    .ThenBy(result => Pets.ToList().IndexOf(result.Pet))
                    .Select(result => $"{result.Pet.Name} would be a {(result.IsGood ? "good" : "bad")} pet with a score of {result.Score}.")
                    .ToList();

                foreach (var result in petResults)
                {
                    Console.WriteLine(result);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}