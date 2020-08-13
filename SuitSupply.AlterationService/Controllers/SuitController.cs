using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Suitsupply.AlterationService.Core;
using Suitsupply.Application.Contracts.Suits;
using Suitsupply.Framework.Core.Commands;
using SuitSupply.Framework.Core.Events;
using SuitSupply.Framework.Core.Queries;
using SuitSupply.ReadModel.Contracts.Dtos;
using SuitSupply.ReadModel.Contracts.Filters;

namespace SuitSupply.AlterationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuitController : ApiControllerBase
    {
        public SuitController(
            ICommandBus commandBus, 
            IEventBus eventBus, 
            IQueryBus queryBus) : base(commandBus, eventBus, queryBus)
        {
        }
        [HttpGet]
        [Route("Alterations")]
        public ActionResult<string> GetAllAlterations()
        {
            var filter = new GetAlterationsFilter();
            try
            {
                var alterations = QueryBus
                                 .Dispatch<GetAlterationsFilter, CollectionQueryResult<GetAlterationsDto>>
                                 (filter);
    
                    return Ok(alterations.Items);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("Alteration/{suitId}")]
        public ActionResult<string> GetAlteration(Guid? suitId)
        {
            if (suitId == null)
            {
                return StatusCode(500, "Invalid SuitId");
            }
            var filter = new GetAlterationsFilter()
            {
                SuitId = suitId,
            };
            try
            {
                var alterations = QueryBus
                                 .Dispatch<GetAlterationsFilter, CollectionQueryResult<GetAlterationsDto>>
                                 (filter);

                return Ok(alterations.Items.FirstOrDefault());
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("Alteration")]
        public ActionResult<string> CreateAlteration(CreateAlterationCommand command)
        {
            try
            {
                CommandBus.Dispatch(command);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500,ex.Message);
            }  
        }
        [HttpPut]
        [Route("PayAlteration")]
        public ActionResult<string> PayAlteraion(PayAlteraionCommand command)
        {
            try
            {
                CommandBus.Dispatch(command);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("CheckOut")]
        public ActionResult<string> CheckOut(CheckSuitOutToTailorCommand command)
        {
            try
            {
                CommandBus.Dispatch(command);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("AlterationIsDone")]
        public ActionResult<string> PayAlteraion(SuitAlterationIsDoneCommand command)
        {
            try
            {
                CommandBus.Dispatch(command);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}