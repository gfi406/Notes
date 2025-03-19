using Notes;
using Microsoft.EntityFrameworkCore;
using Notes.Services;
using Notes.Services.Implementation;

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
        dbContext.Database.CanConnect();
        Console.WriteLine("Connection is Ok");

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        throw new Exception("Connection error");
    }
}

app.UseSwagger();
app.UseSwaggerUI();
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes");
//    options.RoutePrefix = string.Empty; 
//});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
