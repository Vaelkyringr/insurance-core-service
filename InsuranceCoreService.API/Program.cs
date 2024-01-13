using InsuranceCoreService.Domain.Aggregates.Insurance;
using InsuranceCoreService.Infrastructure.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<InsuranceDbContext>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();

var app = builder.Build();

var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
mapperConfig.CreateMapper();


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