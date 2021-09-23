using System;
using System.Linq;
using GSK.HealthProfessional.Service;
using GSK.HealthProfessional.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace GSK.HealthProfessional.WebApp.Controllers
{
    public class ProfessionalRegistrationController : BaseController
    {


        private readonly IOccupationAreaService _occupationAreaService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        private readonly IConfiguration _configuration;
        private readonly IProfessionalService _professionalService;
        private readonly ICompanyService _companyService;

        public ProfessionalRegistrationController(IConfiguration configuration
            ,IProfessionalService professionalService
            ,IOccupationAreaService occupationAreaService
            ,ICompanyService companyService
            , IStateService stateService
            , INotifier notificador) :base(notificador)
        {
            _configuration = configuration;
            _occupationAreaService = occupationAreaService;
            _cityService = new CityService(_configuration, stateService);
            _professionalService =  professionalService;
            _stateService = stateService;
            _companyService = companyService;

        }
        public IActionResult Index()
        {
            ViewBag.CompanyId = _companyService.GetAll().Select(c => new SelectListItem() { Text = c.Description, Value = c.CompanyId.ToString() }).ToList();
            ViewBag.OccupationAreaID = _occupationAreaService.GetProfile().Select(c => new SelectListItem() { Text = c.Name, Value = c.ClientUniqueIdentifier }).ToList();
            ViewBag.StateId = _stateService.GetAll().Select(c => new SelectListItem() { Text = c.Description, Value = c.StateId }).ToList();

            return View();
        }

        public IActionResult GetCity(string stateId)
        {
            if(stateId != "")
                return  Ok(_cityService.GetByStateId(stateId));

            return null;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Model.HealthProfessionalModel professional)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CompanyId = _companyService.GetAll().Select(c => new SelectListItem() { Text = c.Description, Value = c.CompanyId.ToString(), Selected = (c.CompanyId.ToString() == professional.CompanyId) }).ToList();                
                ViewBag.OccupationAreaID = _occupationAreaService.GetProfile().Select(c => new SelectListItem() { Text = c.Name, Value = c.ClientUniqueIdentifier }).ToList();
                ViewBag.StateId = _stateService.GetAll().Select(c => new SelectListItem() { Text = c.Description, Value = c.StateId, Selected = (c.StateId == professional.StateId) }).ToList();
                return View("Index", professional);
            }

            _professionalService.Add(professional);

            if (!ValidOperation())
            {
                ViewBag.CompanyId = _companyService.GetAll().Select(c => new SelectListItem() { Text = c.Description, Value = c.CompanyId.ToString(), Selected = (c.CompanyId.ToString() == professional.CompanyId) }).ToList();                
                ViewBag.OccupationAreaID = _occupationAreaService.GetProfile().Select(c => new SelectListItem() { Text = c.Name, Value = c.ClientUniqueIdentifier }).ToList();
                ViewBag.StateId = _stateService.GetAll().Select(c => new SelectListItem() { Text = c.Description, Value = c.StateId, Selected = (c.StateId == professional.StateId) }).ToList();
                ViewBag.CityId = _cityService.GetByStateId(professional.CityId).Select(c => new SelectListItem() { Text = c.Nome, Value = c.Nome, Selected = (c.Nome == professional.CityId) }).ToList();

                foreach (var item in _notifier.GetNotifications())
                {
                    ModelState.AddModelError("", item.Message);
                }

                return View("Index", professional);
            }

            ViewBag.Url = _configuration.GetSection("AppSettings:UrlApiNeolude").Value;
            return View("Index", professional);
        }

    }
}