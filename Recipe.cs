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

public class Recipe
{
    public List<Ingredient> Ingredients { get; set;}
    public void Print() 
    {
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
        }
    }
    public bool Add(Ingredient ingredient)
    {
        if (Ingredients is not null)
        {
            Ingredients.Add(ingredient);
            return true;
        }
        return false;
    }
}
