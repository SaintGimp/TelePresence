using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TelePresence.Models;

namespace TelePresence.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient client = new HttpClient();
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            client.BaseAddress = new Uri($"https://api.particle.io/v1/devices/{configuration["device"]}/");
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("api/moveleft")]
        public async Task MoveLeft()
        {
            await DoMove("left");
        }

        [Route("api/moveright")]
        public async Task MoveRight()
        {
            await DoMove("right");
        }

        private async Task DoMove(string direction)
        {
            var content = $"access_token={configuration["access_token"]}&args={direction}";
            await client.PostAsync("move", new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded"));
        }
    }
}
