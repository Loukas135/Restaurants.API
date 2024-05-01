using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.DeleteRestaurantCommand;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
	IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
{
	public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
	{
		logger.LogInformation("Getting Restaurant By Id: {RestaurantId} to Delete It", request.Id);
		var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

		if (restaurant == null)
		{
			return false;
		}
		await restaurantsRepository.Delete(restaurant);
		return true;
	}
}
