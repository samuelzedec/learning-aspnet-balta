internal static class Program
{
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Eventos\n");
        var classe = new OK();
        var actions = new Actions()
        {
            Events = new(classe.Name)
        };
        actions.AddMethod(classe.Message);
        
        actions.ChamarEvento();
    }
}


public class Actions
{
    public required EventHandler<DataArgs> Events;

    public void AddMethod(EventHandler<DataArgs> eventHandler)
    {
        Events += eventHandler;
    }

    public void ChamarEvento()
    {
        Events.Invoke(this, new DataArgs()
        {
            Message = "Hello, World!",
            Name = "Samuel"
        });
        
    }
        
}

public class DataArgs : EventArgs
{
    public required string Message { get; set; }
    public required string Name { get; set; }
}

public class OK
{
    public void Message(object? sender, DataArgs e)
    {
        Console.WriteLine(e.Message);
    }

    public void Name(object? sender, DataArgs e)
    {
        Console.WriteLine(e.Name);
    }
}
