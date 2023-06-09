using MediatR;
using src.FoodTracker.API.Exceptions;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Commands.Meals.DeleteMeal;

public class DeleteMealCommandHandler : IRequestHandler<DeleteMealCommand>
{
    private readonly IMealRepository _mealRepository;

    public DeleteMealCommandHandler(IMealRepository mealRepository)
    {
        _mealRepository = mealRepository;
    }
    public async Task Handle(DeleteMealCommand request, CancellationToken cancellationToken)
    {
        var meal = await _mealRepository.GetMealAsync(request.Id, false);
        if (meal == null)
        {
            throw new MealNotFoundException(request.Id);
        }
        _mealRepository.DeleteMeal(meal);
        await _mealRepository.SaveChangesAsync();
    }
}
