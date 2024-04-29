namespace Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;


public interface IRestaurantsRepository
{
	public Task<IEnumerable<Restaurant>> GetAllAsync();
	public Task<Restaurant?> GetByIdAsync(int id);
	public Task<int> Create(Restaurant entity);
}
