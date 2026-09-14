
using CodePlusS1.API.Features.CreateOrder;
using CodePlusS1.API.Features.GetAllOrders;
using CodePlusS1.Application.Features.CreateOrder;
using CodePlusS1.Application.Features.GetAllOrders;
using CodePlusS1.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CodePlusS1.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //dbcontext


            builder.Services.AddDbContext<TaskDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            
            builder.Services.AddScoped<GetAllOrdersHandler>();
            builder.Services.AddScoped<GetOrderDetailsQueryHandler>();

            // Add services to the container.
            builder.Services.AddAuthorization();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //fluent validation

            builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);



            builder.Services.addcash

            var app = builder.Build();

            CreatOrderEndPoint.MapCreateOrderEndPoint(app);
            GetAllOrdersEndPoint.MapGetAllOrdersEndPoint(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();

          
            app.Run();
        }
    }
}
