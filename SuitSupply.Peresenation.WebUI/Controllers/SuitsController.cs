using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Suitsupply.Framework.Web.Utilities;
using SuitSupply.Peresenation.WebUI.Models.Alteration;

namespace SuitSupply.Peresenation.WebUI.Controllers
{
    public class SuitsController : Controller
    {
        private readonly IOptions<SuitSupplyConfig> _configs;
        private readonly IApiClient _apiClient;
        public SuitsController( 
            IOptions<SuitSupplyConfig> configs,
            IApiClient apiClient)
        {
            _configs = configs;
            _apiClient = apiClient;
        }

        public  IActionResult Index()
        {
            var apiUrl = $"{_configs.Value.AlterationServiceBaseUrl}/Alterations";
            var alterations = _apiClient.Get<IEnumerable<AlterationModel>>(apiUrl);
            return View(alterations);
        }

        public IActionResult CreateAlteration(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var apiUrl = $"{_configs.Value.AlterationServiceBaseUrl}/Alteration/{Id}";
            var alteration = _apiClient.Get<AlterationModel>(apiUrl);
            return View(alteration);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAlteration(AlterationModel model)
        {
            if (ModelState.IsValid)
            {
                var apiUrl = $"{_configs.Value.AlterationServiceBaseUrl}/Alteration";
                _apiClient.Post(apiUrl, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult CheckOutToTailor(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var apiUrl = $"{_configs.Value.AlterationServiceBaseUrl}/Alteration/{Id}";
            var alteration = _apiClient.Get<AlterationModel>(apiUrl);
            return View(alteration);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOutToTailor(AlterationModel model)
        {
            if (ModelState.IsValid)
            {
                var apiUrl = $"{_configs.Value.AlterationServiceBaseUrl}/CheckOut";
                _apiClient.Put(apiUrl, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
     
    }
}
