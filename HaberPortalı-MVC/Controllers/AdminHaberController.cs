using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

namespace HaberPortal_MVC.Controllers
{
    public class AdminHaberController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl;

        public AdminHaberController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = configuration["ApiUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"{_apiUrl}/Haber");

            var haberler = JsonConvert.DeserializeObject<List<HaberDTO>>(response);
            return View(haberler);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HaberDTO haber)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(haber), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_apiUrl}/Haber", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(haber);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, HaberDTO haber)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(haber), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{_apiUrl}/Haber/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(haber);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiUrl}/Haber/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
