namespace src.FoodTracker.API.Queries.Ingredients.DTOs;
public class IngredientDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Calories { get; set; }
    public double Proteins { get; set; }
    public double Carbs { get; set; }
    public double Fats { get; set; }
}