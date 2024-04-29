namespace Restaurant.Application.Restaurants;

using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Entities;

public interface IRestaurantsService
{
	Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
	Task<RestaurantDto?> GetRestaurant(int id);
	Task<int> Create(CreateRestaurantDto dto);
}