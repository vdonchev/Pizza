namespace Pizza
{
    using System;
    using Models;

    public static class PizzaMain
    {
        public static void Main()
        {
            try
            {
                var input = Console.ReadLine();

                while (input != "END")
                {
                    var tokens = input.Split();
                    switch (tokens[0])
                    {
                        case "Dough":
                            AddDough(tokens);
                            break;
                        case "Topping":
                            AddTopping(tokens);
                            break;
                        default:
                            AddPizza(tokens);
                            return;
                    }

                    input = Console.ReadLine();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddTopping(string[] tokens)
        {
            var toppingTokens = tokens;
            var toppingType = toppingTokens[1];
            var toppingWeight = int.Parse(toppingTokens[2]);

            var topping = new Topping(toppingType, toppingWeight);
            Console.WriteLine(topping);
        }

        private static void AddDough(string[] tokens)
        {
            var doughTokens = tokens;
            var doughFlourType = doughTokens[1];
            var doughBakingTechnique = doughTokens[2];
            var doughWeight = int.Parse(doughTokens[3]);

            Dough dough = new Dough(doughFlourType, doughBakingTechnique, doughWeight);
            Console.WriteLine(dough);
        }

        private static void AddPizza(string[] tokens)
        {
            var pizzaTokens = tokens;
            var pizzaName = pizzaTokens[1];
            var pizzaToppings = int.Parse(pizzaTokens[2]);

            var pizza = new Pizza(pizzaName, pizzaToppings);

            var doughTokens = Console.ReadLine().Split();
            var doughFlourType = doughTokens[1];
            var doughBakingTechnique = doughTokens[2];
            var doughWeight = int.Parse(doughTokens[3]);

            var dough = new Dough(doughFlourType, doughBakingTechnique, doughWeight);
            pizza.Dough = dough;

            for (int i = 0; i < pizzaToppings; i++)
            {
                var toppingTokens = Console.ReadLine().Split();
                var toppingType = toppingTokens[1];
                var toppingWeight = int.Parse(toppingTokens[2]);

                var topping = new Topping(toppingType, toppingWeight);

                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
    }
}