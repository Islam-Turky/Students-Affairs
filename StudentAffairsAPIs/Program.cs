using StudentAffairsAPIs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*IConfiguration? Conf = default;*/
//"Data Source=.;Initial Catalog=StudentsAffairsDB;User Id=ISLAM;Password=It9103092#;Timout=60;Encrypt=false;TrustServerCertificate=false"
IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                        .AddJsonFile("appsettings.json")
                                        .Build();
builder.Services.AddDbContext<DbStudent>(options => 
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .EnableServiceProviderCaching()
                .EnableThreadSafetyChecks()
        );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
