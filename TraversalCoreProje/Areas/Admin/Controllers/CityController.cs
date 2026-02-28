using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Satus = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(destination);

        }

        public IActionResult GetById(int DestinationId)
        {
            var values = _destinationService.TGetById(DestinationId);
            var jsonValues= JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }


        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetById(id);
            _destinationService.TDelete(values);
            return NoContent();
        }


        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var valuesJson = JsonConvert.SerializeObject(destination);
            return Json(valuesJson);
        }






        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityId=1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityId=2,
        //        CityName="Saraybosna",
        //        CityCountry="Bosna Hersek"
        //    },
        //    new CityClass
        //    {
        //        CityId=3,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    }
        //};
    }
}
