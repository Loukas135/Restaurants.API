using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.UpdateRestaurantCommand;

public class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
	ILogger<UpdateRestaurantCommandHandler> logger,
	IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
	public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
	{
		logger.LogInformation("Updating Restaurant with id: {RestaurantId} with {@UpdateRestaurant}", request.Id, request);
		var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
		if (restaurant == null)
		{
			return false;
		}
		mapper.Map(request, restaurant);
		await restaurantsRepository.SaveChanges();
		return true;
	}
}
