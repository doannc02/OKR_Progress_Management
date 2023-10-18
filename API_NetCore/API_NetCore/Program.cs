using API_NetCore.Models.Entitiess;
using API_NetCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;
using API_NetCore.Common.Provider;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using OKEA.Library.Common.Providers;
using OKEA.Service.Main.API.ActionFilter;
using Oracle.ManagedDataAccess.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OKEAContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("OKEA")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IOkrRepository, OkrRepository>();

builder.Services.AddScoped<IRegisterRepository<object>,  RegisterRepository>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<CookieProvider>();

builder.Services.AddTransient<CacheProvider>();

builder.Services.AddControllers();

builder.Services.AddMemoryCache();


builder.Services.AddMvc(options =>
{
    options.Filters.Add<AuthApiActionFilter>();

    options.MaxModelBindingCollectionSize = 20480;
});

// setup cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


builder.Services.Configure<FormOptions>(x =>
{
    x.BufferBody = false;
    x.KeyLengthLimit = 2048 * 10; // 2 KiB
    x.ValueLengthLimit = 4194304 * 10; // 32 MiB
    x.ValueCountLimit = 2048 * 10;// 1024
    x.MultipartHeadersCountLimit = 32 * 10; // 16
    x.MultipartHeadersLengthLimit = 32768 * 10; // 16384
    x.MultipartBoundaryLengthLimit = 256 * 100; // 128
    x.MultipartBodyLengthLimit = 134217728 * 10; // 128 MiB
});



var app = builder.Build() ;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("MyPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
