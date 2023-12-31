using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UcakRezervasyon.Models;

namespace UcakRezervasyon.Controllers
{
    public class MesafeController : Controller
    {
        Uri uri = new Uri("https://localhost:7139/api/Guzergahs");
        private readonly HttpClient _clientx;
      
            public MesafeController()
            {
                _clientx = new HttpClient();
                _clientx.BaseAddress = uri;
            }
            public async Task<IActionResult> Index()
            {
                HttpResponseMessage response = await _clientx.GetAsync(uri);


                string data = await response.Content.ReadAsStringAsync();
                var mesafeolc = JsonConvert.DeserializeObject<IEnumerable<Guzergah>>(data);

                return View(mesafeolc);

            }
        
    }
}

