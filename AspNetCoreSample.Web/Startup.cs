using AspNetCoreSample.Application.Categories;
using AspNetCoreSample.Application.Products;
using AspNetCoreSample.Core.Repositories;
using AspNetCoreSample.Core.Repositories.Base;
using AspNetCoreSample.Infrastructure.Data;
using AspNetCoreSample.Infrastructure.Repositories;
using AspNetCoreSample.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSample.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // aspnetrun dependencies
            ConfigureAspNetCoreSampleServices(services);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private void ConfigureAspNetCoreSampleServices(IServiceCollection services)
        {

            //Infrastructure Layer

            // in-memory database
            services.AddDbContext<AspNetCoreSampleContext>(c => c.UseInMemoryDatabase("AspNetCoreConnection"));

            // real database
            //services.AddDbContext<AspNetCoreSampleContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("AspNetCoreConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //Application Layer
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

        }
    }
}
