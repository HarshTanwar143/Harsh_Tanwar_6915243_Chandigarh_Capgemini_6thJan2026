using Microsoft.AspNetCore.Mvc;
using SmartRetailMVC.Models;
using Newtonsoft.Json;

namespace SmartRetailMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _client;
        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://10.0.2.4:5000/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("api/products");
            var json = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            return View(products);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Product p)
        {
            await _client.PostAsJsonAsync("api/products", p);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var resp = await _client.GetAsync($"api/products/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<Product>(json);
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product p)
        {
            await _client.PutAsJsonAsync($"api/products/{id}", p);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"api/products/{id}");
            return RedirectToAction("Index");
        }
    }
}

