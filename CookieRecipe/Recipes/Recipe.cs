using CookieRecipe.Recipes.Ingredients;

namespace CookieRecipe.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }        

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
    }
}