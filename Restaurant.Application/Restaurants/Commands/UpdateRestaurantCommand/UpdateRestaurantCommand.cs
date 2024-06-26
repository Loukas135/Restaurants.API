﻿using MediatR;

namespace Restaurant.Application.Restaurants.Commands.UpdateRestaurantCommand;

public class UpdateRestaurantCommand : IRequest<bool>
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public bool HasDelivery { get; set; }
}
