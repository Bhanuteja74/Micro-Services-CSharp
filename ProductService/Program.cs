using ProductService.Services;

class Program
{
    public static void Main(string[] args)
    {
        var app = BuildApp(args);
        
        app.MapGet("/", () => "Welcome to the ProductService!");

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
        builder.Services.AddSingleton<IProductService,ProductService.Services.ProductService>();
        
        var app = builder.Build();
        return app;
    }
}