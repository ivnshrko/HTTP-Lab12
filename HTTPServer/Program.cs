var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string[] names =
{
    "Иван Иванов",
    "Петр Петров",
    "Анна@Смирнова",
    "Олег#Сидоров",
    "Мария!Кузнецова"
};

app.MapGet("/", () =>
{
    Random random = new Random();
    string name = names[random.Next(names.Length)];

    return new Person(name, 19, true);
});

app.Run();

record Person(string Name, int Age, bool IsStudent);
