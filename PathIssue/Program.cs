var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#nullable enable
app.MapGet("/api/{group}/people_nullable_enabled", (string group) =>
{
    return TypedResults.Ok(new { GroupName = group });
})
.WithOpenApi();

#nullable disable
app.MapGet("/api/{group}/people_nullable_disabled", (string group) =>
{
    return TypedResults.Ok(new { GroupName = group });
})
.WithOpenApi();

app.Run();

