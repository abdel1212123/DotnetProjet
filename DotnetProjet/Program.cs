using DotnetProjet.Structure;
using DotnetProjet.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "Root"
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

var railwayUrl = Environment.GetEnvironmentVariable("MYSQL_URL");
var cnx = !string.IsNullOrEmpty(railwayUrl)
    ? ConvertMysqlUrl(railwayUrl)
    : builder.Configuration.GetConnectionString("cnx");

builder.Services.AddDbContext<AppContex>(options =>
    options.UseMySql(cnx, ServerVersion.AutoDetect(cnx)));

builder.Services.AddScoped<IDao, DaoImpl>();
builder.Services.AddScoped<IServices, VService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppContex>();
    db.Database.Migrate();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();

static string ConvertMysqlUrl(string url)
{
    var uri = new Uri(url);
    var userInfo = uri.UserInfo.Split(':');
    return $"server={uri.Host};port={uri.Port};database={uri.AbsolutePath.TrimStart('/')};user={userInfo[0]};password={Uri.UnescapeDataString(userInfo[1])}";
}