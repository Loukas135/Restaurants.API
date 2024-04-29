using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Repositories;
using Restaurant.Infrastructure.Seeders;
using Restaurants.Infrastructure.Persistence;
using System.Runtime.CompilerServices;

namespace Restaurant.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("RestaurantsDb");
		services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(connectionString));

		services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
		services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
	}
}
