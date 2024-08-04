using PaystackIntegrateAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IPaystackService, PaystackService>();
builder.Services.AddHttpClient("paystack", client =>
{
    client.BaseAddress = new Uri($"https://api.paystack.co/");
    client.DefaultRequestHeaders.Add("Authorization", "Bearer sk_test_7d1407aead3c9580e3cae3fe284e7b4fadba69fd");
}
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
