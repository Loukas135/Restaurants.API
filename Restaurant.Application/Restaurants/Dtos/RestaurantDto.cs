﻿using Restaurant.Application.Dishes;


namespace Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Entities;
public class RestaurantDto
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public string Category { get; set; } = default!;
	public bool? HasDelivery { get; set; }
	public string? City { get; set; }
	public string? Street { get; set; }
	public string? PostalCode { get; set; }

	public List<DishDto>? Dishes { get; set; } = [];

}
