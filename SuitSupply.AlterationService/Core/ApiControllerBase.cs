
using Microsoft.AspNetCore.Mvc;
using Suitsupply.Framework.Core.Commands;
using SuitSupply.Framework.Core.Events;
using SuitSupply.Framework.Core.Queries;

namespace Suitsupply.AlterationService.Core
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly ICommandBus CommandBus;
        protected readonly IEventBus EventBus;
        protected readonly IQueryBus QueryBus;


        protected ApiControllerBase(ICommandBus commandBus, IEventBus eventBus, IQueryBus queryBus)
        {
            CommandBus = commandBus;
            EventBus = eventBus;
            QueryBus = queryBus;
        }
    }
}
