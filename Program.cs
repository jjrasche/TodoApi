using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire(conf => conf.UseSqlServerStorage("Data Source=srvr-ebsqldev;Initial Catalog=HangfireTest;Integrated Security=True;TrustServerCertificate=true;"));
builder.Services.AddHangfireServer();
// builder.Services.AddHostedService<Worker>();


// GlobalConfiguration.Configuration
//     .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
//     .UseSimpleAssemblyNameTypeSerializer()
//     .UseRecommendedSerializerSettings()
//     .UseSqlServerStorage("Data Source=srvr-ebsqldev;Initial Catalog=HangfireTest;Integrated Security=True");

// BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));
// RecurringJob.AddOrUpdate("powerfuljob", () => Console.Write("Powerful!"), "*/20 * * * * *");
var jobClass = new Job();
jobClass.EnqueueJob();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
