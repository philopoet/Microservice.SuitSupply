using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Suitsupply.Application.Contracts.Suits;
using Suitsupply.Application.Suits;
using Suitsupply.Domain.Contracts;
using Suitsupply.Domain.Suits.Services;
using Suitsupply.Framework.Core.Commands;
using Suitsupply.Framework.Core.DependencyInjection;
using Suitsupply.Infrastructure.Persistence;
using Suitsupply.Infrastructure.Persistence.Suits;
using SuitSupply.AlterationService.Infrastrucutre;
using SuitSupply.Framework.Core.Events;
using SuitSupply.Framework.Core.Queries;
using SuitSupply.ReadModel.Contracts.Dtos;
using SuitSupply.ReadModel.Contracts.Filters;
using SuitSupply.ReadModel.QueryHandlers;

namespace SuitSupply.AlterationService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddScoped<ISuitSupplyUnitOfWork, SuitSupplyWriteContext>();
            services.AddScoped<ISuitRepository, SuitRepository>();
            services.AddScoped<IValidateAlterationService, ValidateAlterationService>();
            services.AddTransient<ICommandHandler<CreateAlterationCommand>, CreateAlterationCommandHandler>();
            services.AddTransient<ICommandHandler<PayAlteraionCommand>, PayAlteraionCommandHandler>();
            services.AddTransient<ICommandHandler<CheckSuitOutToTailorCommand>, CheckSuitOutToTailorCommandHandler>();
            services.AddTransient<ICommandHandler<SuitAlterationIsDoneCommand>, SuitAlterationIsDoneCommandHandler>();
            services.AddTransient<IQueryHandler<GetAlterationsFilter, CollectionQueryResult<GetAlterationsDto>>, GetAlterationsQueryHandler>();
            
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<ICommandBus, CommandBus>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IDotNetCoreContainer, DotNetCoreDefaultContainer>();

            services.Replace(ServiceDescriptor.Transient<IControllerFactory, CustomControllerFactory>());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

     
            app.UseMvc();
        }
    }
}
