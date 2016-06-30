namespace Pizza.Models
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private readonly Dictionary<string, double> flourTypes = new Dictionary<string, double>()
        {
            { "white", 1.5 },
            { "wholegrain", 1 },
        };

        private readonly Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1 },
        };

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double CaloriesPerGram
        {
            get
            {
                return this.CalculateCalories();
            }
        }

        private string FlourType
        {
            set
            {
                if (!this.flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (!this.bakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        private int Weight
        {
            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public override string ToString()
        {
            var calories = $"{this.CaloriesPerGram:f2}";

            return calories;
        }

        private double CalculateCalories()
        {
            var totalCalories = 2 *
                                this.weight *
                                this.flourTypes[this.flourType.ToLower()] *
                                this.bakingTechniques[this.bakingTechnique.ToLower()];

            return totalCalories;
        }
    }
}