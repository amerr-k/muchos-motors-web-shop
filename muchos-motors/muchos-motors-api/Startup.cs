using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using muchos_motors_api.EntityFramework;
using AutoMapper;
using muchos_motors_api.Services;
using muchos_motors_api.Configurations;
using muchos_motors_api.EntityFramework.Repositories;
using Microsoft.Extensions.Logging;
using muchos_motors_api.AuthHelper;

namespace muchos_motors_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnvironment { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<DataDbContext>(x =>
            //     x.UseSqlServer(Configuration.GetConnectionString("localDB"))
            // );
            if (CurrentEnvironment.IsDevelopment())
            {
                services.AddDbContext<DataDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("localDB")));
            }
            else
            {
                // Use a different connection string for non-development environments
                services.AddDbContext<DataDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("productionDB")));
            }

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = new Mapper(mappingConfig);
            services.AddSingleton(mapper);

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AuthenticationService>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<OrderService>();
            services.AddScoped<OrderItemRepository>();
            services.AddScoped<CarPartRepository>();
            services.AddScoped<CarPartService>();
            services.AddScoped<CarBrandRepository>();
            services.AddScoped<CarBrandService>();
            services.AddScoped<GenericCarModelRepository>();
            services.AddScoped<GenericCarModelService>();
            services.AddScoped<CityRepository>();
            services.AddScoped<CityService>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<CustomerService>();
            services.AddScoped<InventoryLogRepository>();
            services.AddScoped<InventoryLogService>();
            services.AddScoped<InventoryCarPartLogRepository>();
            services.AddScoped<ImageService>();
            services.AddScoped<InvoiceService>();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll",
            //        builder =>
            //        {
            //            builder.AllowAnyOrigin()
            //                   .AllowAnyMethod()
            //                   .AllowAnyHeader();
            //        });
            //});

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
                c.OperationFilter<AuthSwaggerHeader>();
            });

            services.AddLogging(builder =>
            {
                builder.AddConsole();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataDbContext>();
                dbContext.Database.Migrate();
            }

            //app.UseCors(
            //    options => options
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowAnyOrigin()
            //);

            app.UseCors(
                options => options
                    .SetIsOriginAllowed(x => _ = true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );

            //app.UseCors(options => options
            //    .WithOrigins("https://muchos-motors-web.p1824.app.fit.ba")
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials()
            //);

            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
