using project.Contracts;
using project.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDVDRepository, DVDRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<IOnSiteRepository, OnSiteRepository>();
builder.Services.AddScoped<ISpacesRepository, SpacesRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAny",
    policy =>
    {
        policy.WithOrigins("https://localhost:7153", "http://localhost:5153")
     .AllowAnyOrigin()
     .AllowAnyHeader()
     .AllowAnyMethod();
     //.AllowCredentials();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAny");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
builder.Services.AddControllers();





