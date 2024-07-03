
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddControllers();

            // Regersting the scoped service
            builder.Services.AddScoped<IScopedService, ScopedService>();

            builder.Services.AddDbContext<MyDbContext>(
                options => options.UseInMemoryDatabase("MyInMemoryDb"));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            

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

             // Registering middleware
            /*app.UseMiddleware<CustomMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CustomMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
