﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Restaurants;
using Restaurant.Application.Restaurants.Dtos;
using System.Reflection.Metadata.Ecma335;

namespace Restaurant.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var restaurants = await restaurantsService.GetAllRestaurants();
		return Ok(restaurants);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute] int id)
	{
		var restaurant = await restaurantsService.GetRestaurant(id);
		if(restaurant == null)
		{
			return NotFound();
		}
		return Ok(restaurant);
	}

	[HttpPost]
	public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
	{
		int id = await restaurantsService.Create(createRestaurantDto);
		return CreatedAtAction(nameof(GetById), new { id }, null);
	}
}