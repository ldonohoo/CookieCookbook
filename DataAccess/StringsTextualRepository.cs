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

public interface IStringsTextualRepository
{
    const string SEPARATOR = Environment.NewLine;

    List<string> Read(string filePath);

    void Write(string filePath, List<string> names);
}

public class JsonStringsRepository : IStringsTextualRepository
{
    public override List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        var fileContentsAsObjects = JsonSerializer.Deserialize(fileContents);
        return fileContentsAsObjects.Split(SEPARATOR).ToList();
    }

    public override void Write(string filePath, List<string> names)
    {
        var namesAsJson = JsonSerializer.Serialize(names);
        File.WriteAllText(
            filePath,
            string.Join(SEPARATOR, namesAsJson));
    }
}

public class TextStringsRepository : IStringsTextualRepository
{
    public override List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(SEPARATOR).ToList();
    }

    public override void Write(string filePath, List<int> numbers)
    {
        File.WriteAllText(
            filePath,
            string.Join(SEPARATOR, numbers));
    }
}

