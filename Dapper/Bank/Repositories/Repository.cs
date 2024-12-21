using Bank.Shared;
using Bank.Shared.Interfaces;
using Dapper.Contrib.Extensions;

namespace Bank.Repositories;
public class Repository<TModel> 
	where TModel : class, IRequiredField
{
	public TModel? Get(int id)
		=> AppSettings.Connection.Get<TModel>(id);

	public IEnumerable<TModel> GetAll()
		=> AppSettings.Connection.GetAll<TModel>();

	public long Create(TModel model)
		=> AppSettings.Connection.Insert<TModel>(model);
		
	public bool Update(TModel model) 
	{
		if (model.Id == 0) 
			return false;

		return AppSettings.Connection.Update<TModel>(model);
	}

	public bool Delete(int id)
	{
		var model = AppSettings.Connection.Get<TModel>(id);

		if (model is null) 
			return false;
		
		return AppSettings.Connection.Delete<TModel>(model);
	}
}