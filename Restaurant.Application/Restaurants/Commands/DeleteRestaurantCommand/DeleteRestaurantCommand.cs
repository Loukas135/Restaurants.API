using MediatR;

namespace Restaurant.Application.Restaurants.Commands.DeleteRestaurantCommand;

public class DeleteRestaurantCommand(int id) : IRequest<bool>
{
	public int Id { get; } = id;
}
