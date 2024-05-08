using Application.MappingProfile.Admin;
using Application.MappingProfile.User;
using Application.Services;
using Application.Services.Implementations.Admin;
using Application.Services.Implementations.User;
using Application.Services.Interfaces;
using Application.Services.Interfaces.IRepository.Admin;
using Application.Services.Interfaces.IRepository.User;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.Interfaces.IServices.User;
using Application.UnitOfWork;
using CategoryAPI.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistance;
using Persistance.Context;
using Persistance.Repository;
using Persistance.Repository.Admin;
using Persistance.Repository.User;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<StoreLineContext>(options => options.UseNpgsql(connectionString));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Scheme = "Bearer"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
            };
        });

        builder.Services.AddAutoMapper(typeof(MappingAuthorization), typeof(MappingStore), typeof(MappingCatalog),
            typeof(MappingBasket), typeof(MappingProfile), typeof(MappingCategory), typeof(MappingSubCategory),
            typeof(MappingDeliveryOptions), typeof(MappingProduct));

        // Registering Scoped Services
        builder.Services.AddScoped(provider =>
        {
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var secretKey = jwtSettings["SecretKey"];
            var userManager = provider.GetRequiredService<UserManager<Users>>();
            return new JwtService(issuer, audience, secretKey, userManager);
        });
        builder.Services.AddScoped<UserManager<Users>>();
        builder.Services.AddScoped<UserManager<Users>, UserManager<Users>>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<IStoreService, StoreService>();
        builder.Services.AddScoped<ICatalogService, CatalogService>();
        builder.Services.AddScoped<IBasketService, BasketService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IProfileService, ProfileService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
        builder.Services.AddScoped<IDeliveryOptionService, DeliveryOptionService>();
        builder.Services.AddScoped<IProductService, ProductService>();

        //Registering Scoped Repositories
        builder.Services.AddScoped<IStoreRepository, StoresRepository>();
        builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
        builder.Services.AddScoped<IBasketRepository, BasketReporitory>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        builder.Services.AddScoped<IDeliveryOptionRepository, DeliveryOptionRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        // Identity Configuration
        builder.Services.AddIdentity<Users, IdentityRole>()
            .AddEntityFrameworkStores<StoreLineContext>()
            .AddRoles<IdentityRole>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("AllowAllOrigins");

        app.MapControllers();

        app.Run();
    }
}