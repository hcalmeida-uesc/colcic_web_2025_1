using ddd_project.App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// ciclo de vida dos serviços
// Singleton: o objeto se mantém durante toda a execução da aplicação
// Transient: o objeto é criado toda vez que é solicitado
// Scoped: o objeto é criado uma vez por requisição HTTP
builder.Services.AddSingleton<IAlunoService, AlunoService>();
//builder.Services.AddTransient<IAlunoService, AlunoService>();
//builder.Services.AddScoped<IAlunoService, AlunoService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
