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
using DataAccess;

namespace CookieCookbook;


const FileFormat FILE_FORMAT = FileFormat.Text;
const string FILE_PATH = "recipes.txt";

IRecipesRepository recipesRepository = (FILE_FORMAT == FileFormat.Text) ? 
    new RecipesTextRepository() :
    new RecipesJsonRepository();

IRecipesConsoleUserInteraction userInteractions = new();

var recipes = new List<Recipe>();
var cookieCookbook = new CookieCookbook(recipesUserInteraction, recipesRepository, FILE_PATH);
cookieCookbook.Open();




