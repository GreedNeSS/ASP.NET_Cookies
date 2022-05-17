var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    if (context.Request.Cookies.TryGetValue("name", out string? name))
    {
        await context.Response.WriteAsync($"Hello {name}");
    }
    else
    {
        context.Response.Cookies.Append("name", "GreedNeSS");
        await context.Response.WriteAsync("Hello new User!");
    }
});

app.Run();
