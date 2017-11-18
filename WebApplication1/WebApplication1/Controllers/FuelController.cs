using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLogic;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class FuelController : Controller
    {
        private readonly FuelBusinessLogic _businessLogic;

        public FuelController()
        {
            _businessLogic = new FuelBusinessLogic();
        }
        // GET: Fuel
        public ActionResult Index()
        {
            var model = new FuelViewModel { FuelModel = new Models.FuelModel() };
            return View("View", model);
        }
        [HttpPost]
        public ActionResult FuelCalculate(FuelViewModel model)
        {
            if(model.FuelModel != null && model.FuelModel.Distance != 0)
            {
                model.FuelModel.AvgConsumption =
                    _businessLogic.CalculateAvgConsumption(model.FuelModel.Fuel, model.FuelModel.Distance);
                model.ShowResult = true;
                return View("view", model);
            }
            model.ShowResult = false;
            ViewBag.ERROR = "Błędne dane";
            return View("View", model);
        }
    }
}