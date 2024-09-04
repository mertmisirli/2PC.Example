var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

app.MapGet("/ready", () =>
{
    Console.WriteLine("Stock Service is ready");
    return true;
});

app.MapGet("/commit", () =>
{
    Console.WriteLine("Stock Service is committed");
    return true;
});

app.MapGet("/rollback", () =>
{
    Console.WriteLine("Stock Service is rollbacked");
});

app.Run();
