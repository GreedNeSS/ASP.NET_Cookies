using Sessions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "Person.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(20);
    options.Cookie.IsEssential = true;

});

var app = builder.Build();

app.UseSession();

app.Run(async context =>
{
    if (context.Session.Keys.Contains("person"))
    {
        var person = context.Session.Get<Person>("person");
        await context.Response.WriteAsync($"Hello {person?.Name}, your age: {person?.Age}");
    }
    else
    {
        Person person = new Person { Name = "GreedNeSS", Age = 30 };
        context.Session.Set<Person>("person", person);
        await context.Response.WriteAsync("Hello new User!");
    }
});

app.Run();
