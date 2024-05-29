using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var AllowAnyOrigin = "_allowAnyOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAnyOrigin, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

});

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .Build();

builder.Services.AddOcelot(configuration);

var app = builder.Build();

app.UseCors(AllowAnyOrigin);

await app.UseOcelot();

app.Run();
