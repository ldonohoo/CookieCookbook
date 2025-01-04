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

namespace CookieCookbook.DataAccess;

public interface IRecipesRepository
{
    List<int> Read(string filePath);

    void Write(string filePath, List<Recipe> numbers);
}


public class RecipesJsonRepository : IRecipesRepository
{
    private readonly string SEPARATOR = Environment.NewLine;

    public List<int> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        var fileContentsAsObjects = JsonSerializer.Deserialize(fileContents);
        return fileContentsAsObjects.Split(SEPARATOR).ToList();
    }

    public void Write(string filePath, List<Recipe> numbers)
    {
        var namesAsJson = JsonSerializer.Serialize(numbers);
        File.WriteAllText(
            filePath,
            string.Join(SEPARATOR, namesAsJson));
    }
}

public class RecipesTextRepository : IRecipesRepository
{
    private readonly string SEPARATOR = Environment.NewLine;
    public List<Recipe> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(SEPARATOR).ToList();
    }

    public void Write(string filePath, List<Recipe> numbers)
    {
        File.WriteAllText(filePath, string.Join(SEPARATOR, numbers));
    }
}

