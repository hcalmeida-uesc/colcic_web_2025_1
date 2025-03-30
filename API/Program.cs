using Asp.Versioning;
using ddd_project.API.Configuration;
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

// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(0, 1);
})
.AddApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            var descriptions = app.DescribeApiVersions();
            foreach (var description in descriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
