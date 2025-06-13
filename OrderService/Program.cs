class Program
{
    public static void Main(string[] args)
    {
        var app = BuildApp(args);
        
        app.MapGet("/", () => "Welcome to the OrderService!");

        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.MapControllers();
        app.Run();
    }

    private static WebApplication BuildApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();   
        builder.Services.AddControllers();
        builder.Services.AddHttpClient<ProductClient>(client =>
            client.BaseAddress = new Uri("http://localhost:5000")
        );
        
        var app = builder.Build();
        return app;
    }
}