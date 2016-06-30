namespace Pizza.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private const int MinPizzaNameLenght = 1;
        private const int MaxPizzaNameLenght = 15;
        private const int MinNumOfToppings = 0;
        private const int MaxNumOfToppings = 10;

        private readonly List<Topping> toppings;
        private string name;

        public Pizza(string name, int numberOfToppings)
        {
            this.Name = name;
            this.ValidateNumberOfToppings(numberOfToppings);

            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == string.Empty ||
                    value.Length < MinPizzaNameLenght ||
                    value.Length > MaxPizzaNameLenght)
                {
                    throw new ArgumentException(
                        $"Pizza name should be between {MinPizzaNameLenght} and {MaxPizzaNameLenght} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public double TotalCalories
        {
            get
            {
                return this.Dough.CaloriesPerGram +
                       this.toppings.Sum(t => t.CaloriesPerGram);
            }
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            var pizza = $"{this.name} - {this.TotalCalories:f2} Calories.";

            return pizza;
        }

        private void ValidateNumberOfToppings(int topics)
        {
            if (topics < MinNumOfToppings ||
                topics > MaxNumOfToppings)
            {
                throw new ArgumentException(
                    $"Number of toppings should be in range [{MinNumOfToppings}..{MaxNumOfToppings}].");
            }
        }
    }
}