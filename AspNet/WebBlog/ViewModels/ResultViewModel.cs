namespace WebBlog.ViewModels;

public class ResultViewModel<TKey>
{
    public ResultViewModel(TKey data, List<string> errors)
    {
        Data = data;
        Errors = errors;
    }

    public ResultViewModel(TKey data)
        => Data = data;
    
    public ResultViewModel(List<string> errors)
        => Errors = errors;
    
    public ResultViewModel(string error)
        => Errors.Add(error);
    
    public TKey Data { get; private set; } = default!;
    public List<string> Errors { get; private set; } = new();

}