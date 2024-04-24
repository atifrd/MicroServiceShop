using Product.Infrastructure;
using System.Reflection;
using model=Product.Domain.Products;
namespace Products.Api
{
    public static class Assemblies
    {
        public static readonly Assembly EntityAssembly = typeof(model.Product).Assembly;
       // public static readonly Assembly ApplicationAssembly = typeof(AddProductCommand).Assembly;
        public static readonly Assembly InfrastructureAssembly = typeof(ProductDbContext).Assembly;
    }
}
