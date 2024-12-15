using Management.Enums;
using Management.Execution.Room;
using Management.Message;
namespace Management.Execution;

public static class MainMenu
{
    public static void Run()
    {
        TargetingEnum option;
        do
        {
            GlobalMessage.Run();
            HandlingExceptions.Format(out option);
            Targeting(option);
            
        } while (option != TargetingEnum.Exit);
    }

    private static void Targeting(TargetingEnum value)
    {
        switch (value)
        {
            case TargetingEnum.AccessClass:
                RoomEntity.Run();
                break;
            case TargetingEnum.AccessCourse:
                break;
            case TargetingEnum.AccessStudent:
                break;
            case TargetingEnum.Exit:
                GlobalMessage.ClosingProgram();
                break;
            case TargetingEnum.Error:
                GlobalMessage.Information();
                break;
        }
    } 
}
