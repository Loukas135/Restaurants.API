using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.CreateRestaurantCommand;
using Restaurant.Domain.Entities;
public class CreateRestaurantCommandHandler(IMapper mapper, ILogger<CreateRestaurantCommandHandler> logger,
	IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
{
	public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
	{
		logger.LogInformation("Creating Restaurant: {@Restaurant}", request);
		var restaurant = mapper.Map<Restaurant>(request);

		int id = await restaurantsRepository.Create(restaurant);
		return id;
	}
}
