using Lazar_Horatiu_Lab5_Master.Models;
using Lazar_Horatiu_Lab5_Master.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lazar_Horatiu_Lab5_Master.Controllers
{
    public class RiskPredictionController : Controller
    {
        private readonly IRiskPredictionService _riskService;
        public RiskPredictionController(IRiskPredictionService riskService)
        {
            _riskService = riskService;
        }

        //GET: RiskPrediction/index
        [HttpGet]
        public IActionResult Index()
        {
            var model = new RiskPredictionViewModel();
            return View();
        }

        //POST: RiskPrediction/index
        [HttpPost]
        public async Task<IActionResult> Index(RiskPredictionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var input = new RiskInput
            {
                InspectionType = model.InspectionType,
                ViolationDescription = model.ViolationDescription
            };

            var prediction = await _riskService.PredictRiskAsync(input);
            model.PredictedRisk = prediction;
            
            return View(model);
        }
    }
}
