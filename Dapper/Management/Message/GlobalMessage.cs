using Management.Models;

namespace Management.Message;

public static class GlobalMessage
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();
        Console.WriteLine("Bem vindo ao menu principal!\u001b[0m" +
                          "\nInforme a opção desejada:" +
                          "\n[1] - Acessar turma" +
                          "\n[2] - Acessar curso" +
                          "\n[3] - Acessar aluno" +
                          "\n[4] - Encerrar programa");
        Console.Write("> ");
    }

    public static void RunRoom()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();
        Console.WriteLine("Menu\u001b[0m" +
                          "\nInforme a opção desejada:" +
                          "\n[1] - Ver dados das turmas" +
                          "\n[2] - Criar nova turma" +
                          "\n[3] - Atualizar dados da turma" +
                          "\n[4] - Deletar turma" +
                          "\n[5] - Voltar");
        Console.Write("> ");
    }

    public static void Continue()
    {
        Console.WriteLine("\n\u001b[32mPressione Enter para continuar...\u001b[0m");
        Console.ReadKey();
    }
    
    public static void Information()
    {
        Console.Clear();
        Console.WriteLine("Valor Inválido, insira um valor válido para prosseguir!");
        Continue();
    }

    public static void ClosingProgram()
    {
        Console.Clear();
        Console.WriteLine("Programa Encerrado!");
        Continue();
    }

    public static void Returning()
    {
        Console.Clear();
        Console.WriteLine("Voltando ao menu anterior!");
        Continue();
    }

    public static void ReadRoom(List<RoomModel> rooms)
    {
        var choice = 1;
        Console.Clear();
        Console.WriteLine("\u001b[31mCaso queira sair pressione zero!\u001b[m");
        Console.WriteLine("Informe qual sala você deseja saber mais:");
        foreach (var room in rooms)
        {
            Console.WriteLine($"[{choice}] - {room.Code}");
            ++choice;
        }
        Console.Write("> ");
    }

    public static void InfoRoom(List<VwInfo> listRooms, List<Student> students)
    {
        Console.Clear();
        Console.WriteLine("\u001b[33mInformações de cursos:\u001b[0m");
        foreach (var room in listRooms)
        {
            Console.WriteLine($"\u001b[32mID da sala:\u001b[0m {room.RoomId}");
            Console.WriteLine($"\u001b[32mSala:\u001b[0m {room.RoomCode}");
            Console.WriteLine("\u001b[32mCurso abordados na sala:\u001b[0m");
            foreach (var course in room.Courses)
            {
                Console.WriteLine($"\t- \u001b[32mNome:\u001b[0m {course.CourseName}");
                Console.WriteLine($"\t- \u001b[32mDescrição:\u001b[0m {course.CourseDescription}\n");
            }
        }
        Continue();
        Console.Clear();
        Console.WriteLine("\u001b[33mInformações de alunos\u001b[0m");
        foreach (var student in students)
        {
            Console.WriteLine($"\t- \u001b[32mNome:\u001b[0m {student.Name}");
            Console.WriteLine($"\t- \u001b[32mEmail:\u001b[0m {student.Email}\n");
        }
        Continue();
    }
}
