using FireForget.Worker;
using FireForget.Worker.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddWindowsService(o => o.ServiceName = "FireForget.FireForget.Worker");

builder.Services.Configure<RabbitOptions>(builder.Configuration.GetSection("RabbitMq"));
builder.Services.Configure<WorkerOptions>(builder.Configuration.GetSection("Worker"));
builder.Services.Configure<RouteOptions>(builder.Configuration.GetSection("Routing"));

builder.Services.AddSingleton<RouteResolver>();
builder.Services.AddSingleton<QueueRepository>();
builder.Services.AddHostedService<CallbackConsumer>();
builder.Services.AddHostedService<TimeoutSweeper>();

builder.Build().Run();
