using Microsoft.EntityFrameworkCore;
using Product.Infrastructure;

namespace Products.Api
{
    public static class ServiceRegistery
    {
        public static IServiceCollection AddServiceRegistery(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<ProductDbContext>(option =>
            {

                option.UseNpgsql(builder.Configuration.GetConnectionString("ProductDbConn"));
            });
            return builder.Services;
        }
    }
}
