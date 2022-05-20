using BookingHotelAPI.DAL.Context;
using BookingHotelAPI.DAL.Entitis;
using BookingHotelAPI.Mapper;
using BookingHotelAPI.Repository.Interfaces;
using BookingHotelAPI.Repository.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(builder.Configuration
                .GetConnectionString("BookingHotel")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
     options =>
       {

           options.Password.RequireDigit = false;
           options.Password.RequireLowercase = true;
           options.Password.RequireNonAlphanumeric = false;
           options.Password.RequireUppercase = false;
           options.Password.RequiredLength = 6;
           options.Password.RequiredUniqueChars = 0;

       })
       .AddEntityFrameworkStores<ApplicationDbContext>()
       .AddDefaultTokenProviders();

builder.Services.AddAuthentication(option =>
{

    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.RequireHttpsMetadata = false;
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(HotelAPIMapper));
builder.Services.AddScoped(typeof(IGenericRepository<>), 
                         typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped<IAccount, Account>();


var app = builder.Build();

                // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
  {
app.UseSwagger();
app.UseSwaggerUI();
   }
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();