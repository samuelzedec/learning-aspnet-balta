namespace Library.Repository;
public interface IRepository<TModel> where TModel : class
{
	public Task<bool> Create();
	public Task<bool> Update(int id, TModel model);
	public Task<bool> Delete(int id);
	public Task<TModel?> Get(int id);
	public Task<IEnumerable<TModel>> GetAll(int skip, int take);
}
