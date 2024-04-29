using Restaurants.Infrastructure.Persistence;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
	public async Task Seed()
	{
		if (await dbContext.Database.CanConnectAsync())
		{
			if (!dbContext.Restaurants.Any())
			{
				var restaurants = GetRestaurants();
				dbContext.Restaurants.AddRange(restaurants);
				await dbContext.SaveChangesAsync();
			}
		}
	}

	private IEnumerable<Restaurant.Domain.Entities.Restaurant> GetRestaurants()
	{
		List<Restaurant.Domain.Entities.Restaurant> restaurants = [
			new()
			{
				Name = "KFC",
				Category = "Fast Food",
				Description = "Kentucky Fried Chicken",
				HasDelivery = true,
				ContactEmail = "KFC-aburemaneh@kentuckyfriedchicken.com",
				Dishes = [
					new()
					{
						Name = "Nashville Hot Chicken",
						Description = "10 pcs",
						Price = 10.34M,
					},
					new()
					{
						Name = "Chicken Nuggets",
						Description = "5 pcs",
						Price = 5.30M,
					}
				],
				Address = new ()
				{
					City = "Damascus",
					Street = "Abu Remaneh",
					PostalCode = "WC25 5DU"
				}
			},
			new()
			{
				Name = "McDonald",
				Category = "Fast Food",
				Description = "Very Delicious Food Here",
				HasDelivery = false,
				ContactEmail = "McDonald-London@kentuckyfriedchicken.com",
				Dishes = [
					new()
					{
						Name = "Hot Wings",
						Description = "Very Hot",
						Price = 12.40M,
					},
					new()
					{
						Name = "Cheese Burger",
						Description = "Cheesy",
						Price = 2.50M,
					}
				],
				Address = new ()
				{
					City = "London",
					Street = "Prince Harry",
					PostalCode = "BC30 3DD"
				}
			}
		];

		return restaurants;
	}

}
