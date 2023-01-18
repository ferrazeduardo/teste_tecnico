using API_ControleQualidade.Business;
using API_ControleQualidade.Models.Interfaces.Business;
using API_ControleQualidade.Models.Interfaces.Repository;
using API_ControleQualidade.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<ILoteBusiness, LoteBusiness>();
builder.Services.AddScoped<IEnsaioQualidadeBusiness, EnsaioQualidadeBusiness>();
builder.Services.AddScoped<IMetodologiaAvaliacaoBusiness, MetodologiaAvaliacaoBusiness>();

builder.Services.AddScoped<ILoteRepository, LoteRepository>();
builder.Services.AddScoped<IEnsaioQualidadeRepository, EnsaioQualidadeRepository>();
builder.Services.AddScoped<IMetodologiaAvaliacaoRepository, MetodologiaAvaliacaoRepository>();
builder.Services.AddScoped<IParametroRepository, ParametroRepository>();
builder.Services.AddScoped<IConnectionString, ConnectionString>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(
//       options => options.WithOrigins("http://localhost:4200/").AllowAnyMethod()
//   );

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
