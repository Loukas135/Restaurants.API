namespace Restaurant.Application.Restaurants;

using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
	ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{
	public async Task<int> Create(CreateRestaurantDto dto)
	{
		logger.LogInformation("Creating Restaurant");
		var restaurant = mapper.Map<Restaurant>(dto);

		int id = await restaurantsRepository.Create(restaurant);
		return id;
	}

	public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
	{
		logger.LogInformation("Getting All Restaurants");
		var restaurants = await restaurantsRepository.GetAllAsync();

		var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

		return restaurantsDtos!;
	}

	public async Task<RestaurantDto?> GetRestaurant(int id)
	{
		logger.LogInformation($"Getting The Restaurant By {id}");
		var restaurant = await restaurantsRepository.GetByIdAsync(id);

		var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

		return restaurantDto;
	}
}
