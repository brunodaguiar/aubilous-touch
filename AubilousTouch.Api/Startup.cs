using AubilousTouch.App.Services;
using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Intra.Consumers;
using AubilousTouch.Intra.Context;
using AubilousTouch.Intra.Readers.CSVHelper;
using AubilousTouch.Intra.Repositories;
using AubilousTouch.Intra.Senders;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AubilousTouch.Api
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
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Implement Swagger UI",
                    Description = "A simple example to Implement Swagger UI",
                });
            });

            services.AddMassTransit(x =>
            {
                x.AddConsumer<ExampleConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });

            });


            services.AddDbContext<AubilousTouchDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                       .EnableSensitiveDataLogging()
                       .EnableDetailedErrors());
            

            //Dependency Injection
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessagesChannelService, MessagesChannelService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageCenterRepository, MessageCenterRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessagesChannelRepository, MessagesChannelRepository>();
            services.AddScoped<IMessagesChannelPerEmployeeRepository, MessagesChannelPerEmployeeRepository>();
            services.AddScoped<IFileReader, CSVHelperReader>();
            services.AddScoped<IMessageSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
                });
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
