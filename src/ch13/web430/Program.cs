var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// CORSを追加
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// CORSの設定
app.UseCors( options => options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader() );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
