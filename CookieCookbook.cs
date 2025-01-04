public class CookieCookbook
{
    private readonly IRecipesRepository _recipeRepository;
    private readonly RecipesUserInteraction _recipesUserInteraction;

    public string _filePath;
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

    public CookieCookbook(recipesUserInteraction, IRecipeRepository recipeRepository, string filePath)
    {
        _receipeRepository = recipeRepository;
        _UserInteractions = UserInteractions;
        _filePath = filePath;
    }

    public void Open()
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _UserInteractions.PrintExisting(allRecipes);

        _UserInteractions.PromptToCreateRecipe();
        var selectedIngredients = SelectIngredients();
        if (selectedIngredients.Count == 0)
        {
            UserInteractions.ShowMessage("No ingredients selected. Recipe not created.");
            return;
        } 
        var recipe = new Recipe(selectedIngredients);
        allRecipes.Add(recipe);
        _receipesRepository.Write(filePath, allRecipes);
        // AddCurrentRecipe();
        _UserInteractions.ShowMessage("Recipe created:");
        _UserInteractions.ShowMessage(recipe.ToString());
        _UserInteractions.Exit();
    }



    // private void AddCurrentRecipe()
    // {
    //     var ingredientsList = _currentRecipe.GetIngredientList();

    //     _fileRepository.Write(_filePath, ingredientsList);
    // }
}