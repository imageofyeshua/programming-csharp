using CookieRecipe.Recipes;
using CookieRecipe.Recipes.Ingredients;

var cookieRecipesApp = new CookieRecipesApp(new RecipesRepository(), new RecipesUserInteraction());
cookieRecipesApp.Run("recipes.txt");

public class CookieRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookieRecipesApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        // _recipesConsoleUserInteraction.PromptToCreateRecipe();
        // var ingredients = _recipesConsoleUserInteraction.ReadIngredientsFromUser();

        // if (ingredients.Count() > 0)
        // {
        //     var recipes = new Recipe(ingredients);
        //     allRecipes.Add(recipes);
        //     _recipesRepository.Write(filePath, allRecipes);
        //     _recipesConsoleUserInteraction.ShowMessage("Recipe added:");
        //     _recipesConsoleUserInteraction.ShowMessage(recipes.ToString());
        // }
        // else
        // {
        //     _recipesConsoleUserInteraction.ShowMessage(
        //         "No ingredients have been selected. " +
        //         "Recipe will not be saved.");
        // }

        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
}

public class RecipesUserInteraction : IRecipesUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are:" + Environment.NewLine);

            var counter = 0;
            foreach(var recipe in allRecipes)
            {
                Console.WriteLine($"*******{counter + 1}*******");
                Console.WriteLine(recipe);
                Console.WriteLine();
                ++counter;
            }
        }
    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
}

public class RecipesRepository : IRecipesRepository
{
    public List<Recipe> Read(string filePath)
    {
        return new List<Recipe>
        {
            new Recipe(new List<Ingredient>
            {
                new WheatFlour(),
                new Butter(),
                new Sugar()
            }),
            new Recipe(new List<Ingredient>
            {
                new CocoaPowder(),
                new SpeltFlour(),
                new Cinnamon()
            })
        };
    }
}