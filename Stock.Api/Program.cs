using Stock.Services;
using Stock.Services.Handlers;
using Stock.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => {
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));

SqliteHandler.ConnectionString = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddSingleton<ICategoriaRepository, CategoriaService>();
builder.Services.AddSingleton<IProductoRepository, ProductoService>();
builder.Services.AddSingleton<IMovimientoRepository, MovimientoService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock.Backend");
    c.RoutePrefix = string.Empty;
});
app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();
app.UseAuthentication();
app.Run();