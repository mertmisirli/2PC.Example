using Coordinator.Models.Contexts;
using Coordinator.Services;
using Coordinator.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TwoPhaseCommitDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")));


builder.Services.AddHttpClient("OrderAPI", client => client.BaseAddress = new("https://localhost:7261/"));
builder.Services.AddHttpClient("StockAPI", client => client.BaseAddress = new("https://localhost:7062/"));
builder.Services.AddHttpClient("PaymentAPI", client => client.BaseAddress = new("https://localhost:7064/"));


builder.Services.AddTransient<ITransactionService, TransactionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/create-order-transaction", async (ITransactionService transactionService) =>
{
    var transactionId = await transactionService.CreateTransactionAsync();
    await transactionService.PrepareServicesAsync(transactionId);

    bool transactionState = await transactionService.CheckReadyServicesAsync(transactionId);

    if(transactionState)
    {
        await transactionService.CommitAsync(transactionId);
        transactionState = await transactionService.CheckTransactionStateServicesAsync(transactionId);

    }

    if(!transactionState)
        await transactionService.RollbackAsync(transactionId);


}); 

app.Run();
