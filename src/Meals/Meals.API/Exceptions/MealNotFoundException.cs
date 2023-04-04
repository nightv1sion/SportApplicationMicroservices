namespace src.Meals.Meals.API.Exceptions
{
    public class MealNotFoundException : NotFoundException
    {
        public MealNotFoundException(Guid id) : base($"Meal with id: {id} not found")
        { }
    }
}
