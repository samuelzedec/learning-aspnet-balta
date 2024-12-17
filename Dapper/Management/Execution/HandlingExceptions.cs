using Management.Enums;
using Management.Message;
using Management.Models;

namespace Management.Execution;

public delegate Task Validation(int index, List<RoomModel> rooms);

public static class HandlingExceptions
{
    public static void Format(out TargetingEnum value)
    {
        if (!int.TryParse(Console.ReadLine(), out var choice))
            value = TargetingEnum.Error;

        value = Enum.IsDefined(typeof(TargetingEnum), choice)
            ? (TargetingEnum)choice
            : TargetingEnum.Error;
    }
    
    public static void Format(out TargetingRoomEnum value)
    {
        if (!int.TryParse(Console.ReadLine(), out var choice))
            value = TargetingRoomEnum.Error;

        value = Enum.IsDefined(typeof(TargetingRoomEnum), choice)
            ? (TargetingRoomEnum)choice
            : TargetingRoomEnum.Error;
    }
    
    public static void Format(Validation method, int index, List<RoomModel> rooms)
    {
        try
        {
            method.Invoke(index, rooms);
        }
        catch (ArgumentException ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
            GlobalMessage.Continue();
        }
    }
}
