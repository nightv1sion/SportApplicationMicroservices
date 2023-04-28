namespace src.ApiGateways.APIGateway.DataTransferObjects.FoodTracker.API;

public class CreateMealDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Guid> IngredientsIds { get; set; }
}