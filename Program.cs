using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire(conf => conf
    .UseSqlServerStorage("Data Source=srvr-ebsqldev;Initial Catalog=HangfireTest;Integrated Security=True;TrustServerCertificate=true;")
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()    
);
// add processing server
builder.Services.AddHangfireServer();

// builder.Services.AddHostedService<Worker>();
// BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));
// RecurringJob.AddOrUpdate("powerfuljob", () => Console.Write("Powerful!"), "*/20 * * * * *");
// var jobClass = new Job();
// jobClass.EnqueueJob();

var app = builder.Build();
// var timer = new System.Threading.Timer(
//     (sender) => {
//         BackgroundJob.Schedule(() => Console.WriteLine("hello bob"), TimeSpan.FromSeconds(20));
//     },
//     null,
//     1000,
//     Timeout.Infinite
// );
// RecurringJob.AddOrUpdate(() => Console.WriteLine("Hello, world!"), Cron.Minutely);
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
