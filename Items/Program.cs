var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Items.Add("main", "Main Page");
    context.Items.Add("user", new { name = "GreedNeSS", age = 30 });
    await next();
});

app.MapGet("/", (HttpContext context) =>
{
    if (context.Items.ContainsKey("main"))
    {
        return context.Items["main"];
    }
    else
    {
        return "Not Found!";
    }
});

app.MapGet("/user", (HttpContext context) =>
{
    if (!context.Items.TryGetValue("user", out object user))
    {
        user = new { name = "Undefined", age = -1 };
    }

    return user;
});

app.Run();
