var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddSwaggerGen(); 

builder.Services.AddScoped<ItemsService>(); 

builder.Services.AddServerSideBlazor(); 

builder.Services.AddSqlite<ItemsContext>("Data Source=todoitem.db"); 

var app = builder.Build(); 

app.UseSwagger(); 

app.MapHub<update_client>("/update_client"); 

app.UseSwaggerUI(); 

app.MapControllers(); 

app.Run();