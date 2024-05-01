using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper,
	IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
{
	public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
	{
		logger.LogInformation("Getting The Restaurant By {RestaurantId}", request.Id);
		var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

		var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

		return restaurantDto;
	}
}
