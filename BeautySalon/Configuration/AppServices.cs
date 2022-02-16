using Azure.Storage.Blobs;
using BeautySalon.Data;
using BeautySalon.Data.Models;
using BeautySalon.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BeautySalon.Configuration
{
    public static class AppServices
    {
        public static void AddDefaultServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var azureStorageConnection = configuration.GetValue<string>("AzureStorageConnection");

            serviceCollection.AddSingleton(x => new BlobServiceClient(azureStorageConnection));

            serviceCollection.AddTransient<IImageService, ImageService>();
            serviceCollection.AddTransient<IPostService, PostService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<ICommentService, CommentService>();

            serviceCollection.AddTransient<SendEmailService>();

            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddDatabaseDeveloperPageExceptionFilter();

            serviceCollection.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            serviceCollection.AddControllersWithViews();
        }
    }
}
