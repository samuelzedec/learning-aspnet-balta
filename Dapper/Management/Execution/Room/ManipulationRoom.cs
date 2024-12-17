using Microsoft.Data.SqlClient;
using Dapper;
using Management.Message;
using Management.Models;
namespace Management.Execution.Room;

public static partial class RoomEntity
{
    private static void Read()
    {
        List<RoomModel> rooms;
        using (var connection = new SqlConnection(ConnectionString))
        {
            rooms = connection.Query<RoomModel>(SqlMessage.SelectInRoomModel()).ToList();
        };

        int option;
        do
        {
            GlobalMessage.ReadRoom(rooms);
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                GlobalMessage.Information();
                option = -1;
                continue;
            }
            
            HandlingExceptions.Format(
                DirectingChoice, 
                option - 1, 
                rooms);
            
        } while (option != 0);
    }

    private static async Task DirectingChoice(int index, List<RoomModel> rooms)
    {
        if (index >= rooms.Count || index < 0)
            throw new ArgumentException("\u001b[31mValor forá do intervalo de opções disponíveis!\u001b[0m");
        
        var taskRooms  = SearchingRoomsInTheDatabase(index, rooms);
        var taskStudents  =  SearchingForStudentsInTheDatabase(index, rooms);
        
        await Task.WhenAll(taskRooms, taskStudents);
        
        var listRooms = await taskRooms;
        var listStudents = await taskStudents;
        
        GlobalMessage.InfoRoom(listRooms, listStudents);
    }

    private static async Task<List<VwInfo>> SearchingRoomsInTheDatabase(int index, List<RoomModel> rooms)
    {
        List<VwInfo> info = new();
        using (var connection = new SqlConnection(ConnectionString))
        {
            var items = connection.Query<VwInfo, CourseVwInfo, VwInfo>(
                SqlMessage.SelectInVwInfo(),
                (room, courses) =>
                {
                    var item = info.FirstOrDefault(x => x.RoomCode == room.RoomCode);
                    if (item is null)
                    {
                        item = room;
                        item.Courses.Add(courses);
                        info.Add(item);
                    }
                    else
                    {
                        item.Courses.Add(courses);
                    }
                    return room;
                },
                new { RoomCode = rooms[index].Code },
                splitOn: "CourseName"
            );
            return info;
        }
    }

    private static async Task<List<Student>> SearchingForStudentsInTheDatabase(int index, List<RoomModel> rooms)
    {
        var studentsInTheRoom = new List<Student>();
        using (var connection = new SqlConnection(ConnectionString))
        {
            var students = connection.Query<Student>(
                SqlMessage.SelectStudents(),
                new { Room = rooms[index].Code});
            studentsInTheRoom = students.ToList();
        }
        return studentsInTheRoom;
    }
}
