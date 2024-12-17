using Balta.ContentContext;
using Balta.SubscriptionContext;

Console.Clear();

var articles = new List<Article>()
{
    new("Artigo sobre OOP", "orientacao-objetos"),
    new("Artigo sobre C#", "csharp"),
    new("Artigo sobre .NET", "dotnet")
};

/*foreach (var article in articles)
{
    Console.WriteLine($"\nArtigo: {article.Title}");
    Console.WriteLine($"ID: {article.Id}");
    Console.WriteLine($"URL: {article.Url}");
}*/

var courseOop = new Course("Fundamentos OOP", "fundamentos-oop");
var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");
var courseAspNet = new Course("Fundamentos ASP .NET", "fundamentos-aspnet");

var courses = new List<Course>() { courseOop, courseCsharp, courseAspNet };

var careerList = new List<Career>();
var careerDotnet = new Career("Especialista .NET", "especialista-dotnet");
var careerItem = new CareerItem(1, "Comece por aqui", "", null);
var careerItem2 = new CareerItem(2, "Siga por aqui", "", courseCsharp);
var careerItem3 = new CareerItem(3, "Finalize por aqui", "", courseAspNet);

careerDotnet.Items.Add(careerItem2);
careerDotnet.Items.Add(careerItem);
careerDotnet.Items.Add(careerItem3);

careerList.Add(careerDotnet);

foreach (var career in careerList)
{
    Console.WriteLine($"\nCareer: {career.Title}");
    foreach (var item in career.Items.OrderBy(x => x.Order))
    {
        Console.WriteLine($"\nOrdem: {item.Order} | Titulo: {item.Title}");
        if (item.Course is not null)
        {
            Console.WriteLine($"Informação curso: " +
                              $"\n\tID: {item.Course.Id}" +
                              $"\n\tTitulo: {item.Course.Title}" +
                              $"\n\tURL: {item.Course.Url}");
        }
        
        foreach (var notification in item.Notifications)
        {
            Console.WriteLine($"\u001b[31mNotificação\u001b[0m");
            Console.WriteLine($"\tPropriedade: {notification.Property}");
            Console.WriteLine($"\tMensagem: {notification.Message}");
        }
    }
}

var payPalSubscription = new PayPalSubscription();
var student = new Student();

student.CreateSubscription(payPalSubscription);