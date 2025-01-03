// cookbook class
// list of Recipes

// Recipe class
// list of ingredients

// ingredients interface

// ingredient class
// - flour, sugar, etc. classes


// open cookbook
// welcome messaage (cookbook method)
// print recipes (recipe method)
// print ingredients and new recipe message (ingredients interface method)
// loop:
//  get ingredient input (cookbook method calling string method)
//  add ingredient to recipe (ingredients interface method)
// add recipe to file (fileprocessing method)
// 

using System.Text.Json;


var recipes = new List<Recipe>();
var cookieCookbook = new CookieCookbook(recipes);
cookieCookbook.OpenCookbook();

public class CookieCookbook
{
    const FileFormat FILE_FORMAT = FileFormat.Text;
    public List<Recipe> _recipes;
    public List<Ingredient> _availableIngredients =
    [
        new Flour(),
        new Sugar(),
        new Eggs(),
        new Butter(),
        new BakingPowder(),
        new Vanilla(),
        new ChocolateChips()
    ];
    public Recipe _currentRecipe = new Recipe();

    public CookieCookbook(List<Recipe> recipes)
    {
        _recipes = recipes;
    }

    public void OpenCookbook()
    {
        ConsolePrinter.PrintMessage($"Welcome to the Cookie Cookbook! {Environment.NewLine}");
        ConsolePrinter.PrintRecipes(_recipes);

        ConsolePrinter.PrintMessage("Creating recipe!");
        bool isRecipeEmpty = GetIngredients();
        if (isRecipeEmpty)
        {
            System.Console.WriteLine("No ingredients selected. Recipe not created.");
            return;
        } 
        AddCurrentRecipeToCookbook();
        System.Console.WriteLine("Recipe created:");
        _currentRecipe.Print();
    }

    private void AddCurrentRecipeToCookbook()
    {
        StringsTWriteListToFile(_currentRecipe, FILE_FORMAT);
    }



    public bool GetIngredients()
    {
        bool isRecipeEmpty = true;
        bool didUserEndRecipe = false;
        do
        {
            ConsolePrinter.PrintIngredients(_availableIngredients);
            ConsolePrinter.PrintMessage("Enter an ingredient number or press any other key to finish:");

            if (int.TryParse(Console.ReadLine(), out int ingredientId))
            {
                Ingredient selectedIngredient = _availableIngredients.Find(ingredient => ingredient.Id == ingredientId);   
                if (selectedIngredient is not null)
                {
                    _currentRecipe.Add(selectedIngredient);
                    isRecipeEmpty = false; 
                } else 
                {
                    ConsolePrinter.PrintMessage("Ingredient not found.");
                }  
            } else 
            {
                didUserEndRecipe = true;
            }
        } while(!didUserEndRecipe);
        return isRecipeEmpty;
    }
}


