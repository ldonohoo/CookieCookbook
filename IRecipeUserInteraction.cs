using System;

namespace CookieCookbook;

public interface IRecipeUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PromptToCreateRecipe();
    List<Ingredient> SelectIngredients();
    void PrintExisting();

}

public class ConsoleUserInteraction : IRecipeUserInteraction
{
    public void PromptToCreateRecipe()
    {
        ShowMessage("Creating recipe!");
        ConsolePrinter.PrintIngredients(_availableIngredients);
        ShowMessage("Enter an ingredient number or press any other key to finish:");
    }

    public List<Ingredients> SelectIngredients()
    {
        bool isRecipeEmpty = true;
        bool didUserEndRecipe = false;
        private List<Ingredient> currentIngredients = new();

        do
        {
            if (int.TryParse(Console.ReadLine(), out int ingredientId))
            {
                Ingredient selectedIngredient = _availableIngredients.Find(ingredient => ingredient.Id == ingredientId);   
                if (selectedIngredient is not null)
                {
                    currentIngredients.Add(selectedIngredient);
                } else 
                {
                    ShowMessage("Ingredient not found.");
                }  
            } else 
            {
                didUserEndRecipe = true;
            }
        } while(!didUserEndRecipe);
        return currentIngredients;
    }

    public void PrintExisting()
    {
        ShowMessage($"Welcome to the Cookie Cookbook! {Environment.NewLine}");
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

    public void PrintIngredients(List<Ingredient> ingredients)
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
     
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }   

    public void Exit()
    {
        ShowMessage(Environment.NewLine + "Press any key to exit" );
        Console.ReadKey();
    }

}