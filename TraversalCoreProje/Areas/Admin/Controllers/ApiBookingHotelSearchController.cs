using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ApiBookingHotelSearchController : Controller
    {
        private readonly IConfiguration _configuration;

        public ApiBookingHotelSearchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IActionResult> Index()
        {

            var apiKey = _configuration["RapidApiKey"];
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?adults_number=2&children_number=2&units=metric&page_number=0&checkin_date=2026-03-13&checkout_date=2026-03-15&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&dest_type=city&dest_id=-1456928&order_by=popularity&include_adjacency=true&room_number=1&filter_by_currency=EUR&locale=en-gb"),
                Headers =
                {
                   { "x-rapidapi-key", apiKey },
                   { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyReplace);
                return View(values.result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCityDestId()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetCityDestId(string p)
        {
            var apiKey = _configuration["RapidApiKey"];
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={p}&locale=en-gb"),
                Headers =
                {
                   { "x-rapidapi-key", apiKey },
                   { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return View();
            }
        }
    }

}
