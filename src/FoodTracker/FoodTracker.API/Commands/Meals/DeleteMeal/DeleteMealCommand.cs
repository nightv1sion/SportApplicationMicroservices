using MediatR;

namespace src.FoodTracker.API.Commands.Meals.DeleteMeal;

public class DeleteMealCommand : IRequest
{
    public DeleteMealCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
