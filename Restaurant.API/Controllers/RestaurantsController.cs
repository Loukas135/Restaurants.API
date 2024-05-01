using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Restaurants;
using Restaurant.Application.Restaurants.Commands.CreateRestaurantCommand;
using Restaurant.Application.Restaurants.Commands.DeleteRestaurantCommand;
using Restaurant.Application.Restaurants.Commands.UpdateRestaurantCommand;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurant.Application.Restaurants.Queries.GetRestaurantById;
using System.Reflection.Metadata.Ecma335;

namespace Restaurant.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
	{
		var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
		return Ok(restaurants);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<RestaurantDto>> GetById([FromRoute] int id)
	{
		var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
		if(restaurant == null)
		{
			return NotFound();
		}
		return Ok(restaurant);
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
	{
		bool isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
		if(isDeleted)
		{
			return NoContent();
		}
		return NotFound();
	}

	[HttpPost]
	public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
	{
		int id = await mediator.Send(command);
		return CreatedAtAction(nameof(GetById), new { id }, null);
	}

	[HttpPatch]
	[Route("{id}")]
	public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand command)
	{
		command.Id = id;
		bool isUpdated = await mediator.Send(command);
		if(isUpdated)
		{
			return NoContent();
		}
		return NotFound();
	}
}
