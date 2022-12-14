using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using WebApplication5.Data;
using WebApplication5.Repository;
using WebApplication5.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ShoppingCartDbContext>
    (x => x.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingConnection")));

builder.Services.AddTransient<IUser, UserRepo>();
builder.Services.AddTransient<UserDetailsService, UserDetailsService>();


builder.Services.AddTransient<IProduct, ProductRepo>();
builder.Services.AddTransient<ProductService, ProductService>();

builder.Services.AddTransient<ICart, CartRepo>();
builder.Services.AddTransient<CartService, CartService>();

builder.Services.AddTransient<IOrder, OrderRepo>();
builder.Services.AddTransient<OrderService, OrderService>();

builder.Services.AddTransient<IPayment, PaymentRepo>();
builder.Services.AddTransient<PaymentService, PaymentService>();

builder.Services.AddTransient<IFeedback, FeedbackRepo>();
builder.Services.AddTransient<FeedbackService, FeedbackService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
