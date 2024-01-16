using Agenda.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


// Para dizer ao Asp.Net que estamos usando Controllers
builder.Services.AddControllers();

// Add essa linha abaixo
// Aqui estamos deixando o DbContext como um serviço.
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Essa linha faz aquela vez quando a gente usava o mapget, mappost, etc...
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
