using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Restaurants;

namespace Restaurant.Application.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddApplicaiton(this IServiceCollection services)
	{
		var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
		services.AddAutoMapper(applicationAssembly);
	}
}
