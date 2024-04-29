using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Restaurants;

namespace Restaurant.Application.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddApplicaiton(this IServiceCollection services)
	{
		services.AddScoped<IRestaurantsService, RestaurantsService>();

		services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
	}
}
