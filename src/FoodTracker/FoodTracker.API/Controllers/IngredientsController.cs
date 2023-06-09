using MediatR;
using Microsoft.AspNetCore.Mvc;
using src.FoodTracker.API.Commands.Ingredients.CreateIngredient;
using src.FoodTracker.API.Commands.Ingredients.DeleteIngredient;
using src.FoodTracker.API.Commands.Ingredients.DTOs;
using src.FoodTracker.API.Commands.Ingredients.UpdateIngredient;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Queries.Ingredients.GetIngredient;
using src.FoodTracker.API.Queries.Ingredients.GetIngredients;

namespace src.FoodTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetIngredients()
        {
            var ingredients = await _mediator.Send(new GetIngredientsQuery());
            return Ok(ingredients);
        }
        [HttpGet("{id:guid}", Name = "GetIngredientById")]
        public async Task<ActionResult> GetIngredient(Guid id)
        {
            var ingredient = await _mediator.Send(new GetIngredientQuery(id));
            if (ingredient == null)
            {
                return NotFound("Ingredient is not found");
            }
            return Ok(ingredient);
        }
        [HttpPost]
        public async Task<ActionResult> CreateIngredient(CreateIngredientDTO dto)
        {
            var ingredient = await _mediator.Send(new CreateIngredientCommand(dto));
            return CreatedAtRoute("GetIngredientById", new { Id = ingredient.Id }, ingredient);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateIngredient(UpdateIngredientDTO dto)
        {
            var ingredient = await _mediator.Send(new UpdateIngredientCommand(dto));
            if (ingredient == null)
                return NotFound("Ingredient is not found");
            return Ok(ingredient);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteIngredient(Guid id)
        {
            await _mediator.Send(new DeleteIngredientCommand(id));
            return Ok();
        }
    }
}