var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var app = builder.Build();


app.MapGet("/ready", () =>
{
    Console.WriteLine("Order Service is ready");
    return true;
});

app.MapGet("/commit", () =>
{
    Console.WriteLine("Order Service is committed");
    return true;
});

app.MapGet("/rollback", () =>
{
    Console.WriteLine("Order Service is rollbacked");
});

app.Run();
