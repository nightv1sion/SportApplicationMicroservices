namespace src.FoodTracker.API.Commands.Ingredients.DTOs
{
    public class CreateIngredientDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
    }
}