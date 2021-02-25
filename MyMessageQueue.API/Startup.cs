using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyMessageQueue.BLL;
using MyMessageQueue.DAL;
using MyMessageQueue.SAL;


namespace MyMessageQueue.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            ConfigureServicesBLL(services);
            ConfigureServicesDAL(services);
            ConfigureServicesSAL(services);
            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureServicesBLL(IServiceCollection services)
        {
            services.AddTransient<IMessageQueueLogic, MessageQueueLogic>();
            services.AddTransient<IErrorLogLogic, ErrorLogLogic>();
        }

        private void ConfigureServicesDAL(IServiceCollection services)
        {
            services.AddDbContext<MyMessageQueueDBContext>((services, options) =>
            {
                var configuration = services.GetService<IConfiguration>();
                options.UseSqlServer(configuration["ConnectionStrings:defaultConnection"]);
            });
            services.AddTransient<IMessageQueueDataManager, MessageQueueDataManager>();
            services.AddTransient<IErrorLogDataManager, ErrorLogDataManager>();
        }
        private void ConfigureServicesSAL(IServiceCollection services)
        {
            services.AddSingleton<IQueueConnectionFactory, QueueConnectionFactory>();
            services.AddSingleton<IMessageQueueServiceManager>(x =>
            {
                var hostName = x.GetService<IConfiguration>()["queueHostName"];
                var connection = x.GetService<IQueueConnectionFactory>().GetConnection(hostName);
                return new MessageQueueServiceManager(connection);
            });
        }

    }
}
