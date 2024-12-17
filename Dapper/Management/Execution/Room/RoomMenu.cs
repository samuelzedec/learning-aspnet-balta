using Management.Enums;
using Management.Message;
namespace Management.Execution.Room;

public static partial class RoomEntity
{
    public static string ConnectionString =
        "Server=localhost,9090;Database=Management;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
    public static void Run()
    {
        TargetingRoomEnum option;
        do
        {
            GlobalMessage.RunRoom();
            HandlingExceptions.Format(out option);
            Targeting(option);
        } while (option != TargetingRoomEnum.Exit);
    }

    private static void Targeting(TargetingRoomEnum choice)
    {
        switch (choice)
        {
            case TargetingRoomEnum.ClassInformation:
                Read();
                break;
            case TargetingRoomEnum.CreateClass:
                break;
            case TargetingRoomEnum.UpdateClass:
                break;
            case TargetingRoomEnum.DeleteClass:
                break;
            case TargetingRoomEnum.Exit:
                GlobalMessage.Returning();
                break;
            case TargetingRoomEnum.Error:
                GlobalMessage.Information();
                break;
        }
    }
}
