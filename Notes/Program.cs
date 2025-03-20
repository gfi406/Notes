using Notes;
using Microsoft.EntityFrameworkCore;
using Notes.Services;
using Notes.Services.Implementation;
using Notes.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.DocInclusionPredicate((docName, apiDesc) => true);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<INoteService, NoteService>();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        dbContext.Database.Migrate();
        dbContext.Database.CanConnect();

        Console.WriteLine("Connection is Ok");

        var initializer = new DatabaseInitializer(dbContext);
        await initializer.InitializeAsync();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        throw new Exception("Connection error");
    }
}

app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
