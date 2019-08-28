using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab23_SWAPI.Models;
using System.Net.Http;

namespace Lab23_SWAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }

        public async Task<IActionResult> GetPersonById(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co");
            var response = await client.GetAsync($"/api/people/{id}/");
            var person = await response.Content.ReadAsAsync<People>();
            return View("Result", person);
        }

        public async Task<IActionResult> GetPlanetById(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co");
            var response = await client.GetAsync($"/api/planets/{id}/");
            var planet = await response.Content.ReadAsAsync<Planet>();
            return View("PlanetResult", planet);
        }
    }
}
