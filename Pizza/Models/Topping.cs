namespace Pizza.Models
{
    using System;
    using System.Collections.Generic;

    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private readonly Dictionary<string, double> types =
            new Dictionary<string, double>()
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 },
            };

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double CaloriesPerGram
        {
            get
            {
                return this.CalculateCalories();
            }
        }

        private string Type
        {
            set
            {
                if (!this.types.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(
                        $"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        private int Weight
        {
            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException(
                        $"{this.type} weight should be in the range [{MinWeight}..{MaxWeight}].");
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
                                this.types[this.type.ToLower()];

            return totalCalories;
        }
    }
}