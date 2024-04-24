using Microsoft.EntityFrameworkCore;
using Product.Domain.Products;
using Product.Infrastructure;
using System.Text.Json.Serialization;

namespace Products.Api
{
    public static class ServiceRegistery
    {
        public static IServiceCollection AddServiceRegistery(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                option.JsonSerializerOptions.WriteIndented = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();
            return builder.Services;
        }


        public static IServiceCollection AddInfrastructureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(Assemblies.InfrastructureAssembly);

            builder.Services.AddDbContext<ProductDbContext>(option =>
            {

                option.UseNpgsql(builder.Configuration.GetConnectionString("ProductDbConn"));
            });

            builder.Services.AddScoped<IReadUnitOfWork, ReadUnitOfWork>();
            builder.Services.AddScoped<IWriteUnitOfWork, WriteUnitOfWork>();
            return builder.Services;
        }
    }
}
