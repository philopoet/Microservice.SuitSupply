using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Internal;
using Suitsupply.Framework.Core.DependencyInjection;

namespace SuitSupply.AlterationService.Infrastrucutre
{
    public class CustomControllerFactory : DefaultControllerFactory
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomControllerFactory(
            IControllerActivator controllerActivator,
            IEnumerable<IControllerPropertyActivator> propertyActivators,
            IHttpContextAccessor httpContextAccessor)
            : base(controllerActivator, propertyActivators)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override object CreateController(ControllerContext context)
        {
            var controller = (ControllerBase)base.CreateController(context);

            DotNetCoreServiceLocator.Initial(new HttpContextServiceLocator(_httpContextAccessor));

            return controller;
        }

        public override void ReleaseController(ControllerContext context, object controller)
        {
            base.ReleaseController(context, controller);
        }

    }
}
