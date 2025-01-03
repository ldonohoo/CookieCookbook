

public static class ConsolePrinter
    {
        public static void PrintRecipes(List<Recipe> recipes)
        {
            if (recipes.Count == 0) 
            {
                PrintMessage("No current recipes" + Environment.NewLine);
                return;
            }
            PrintMessage("Here are the current recipes:");
            foreach (Recipe recipe in recipes)
            {
                recipe.Print();
            }
        }   
        public static void PrintIngredients(List<Ingredient> ingredients)
        {
            if (ingredients.Count == 0) 
            {
                PrintMessage("No current ingredients" + Environment.NewLine);
                return;
            }
            PrintMessage("Here are the current ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Print();
            }
        }    

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }   

    }