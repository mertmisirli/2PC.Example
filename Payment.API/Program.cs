var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

app.MapGet("/ready", () =>
{
    Console.WriteLine("Payment Service is ready");
    return true;
});

app.MapGet("/commit", () =>
{
    Console.WriteLine("Payment Service is committed");
    return true;
});

app.MapGet("/rollback", () =>
{
    Console.WriteLine("Payment Service is rollbacked");
});

app.Run();
