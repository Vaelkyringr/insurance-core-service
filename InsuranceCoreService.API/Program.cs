using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;
using InsuranceCoreService.Infrastructure.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<InsuranceDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers(opt => opt.SuppressAsyncSuffixInActionNames = false);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();
builder.Services.AddScoped<IInsurerRepository, InsurerRepository>();

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
