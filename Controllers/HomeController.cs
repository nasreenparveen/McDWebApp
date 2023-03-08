using McDonaldWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace McDonaldWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://receiptfunc.azurewebsites.net/api/Function1?code=kycLrwNQ608LORlT51-7bdPbArqd6rttz_yOGgoiNZdnAzFu3Sbw2w==");
                    var responseContent = await response.Content.ReadAsStringAsync();
                    ViewBag.MethodResponse = responseContent;
                }
            }
            catch(Exception ex)
            {
                ViewBag.MethodResponse = "Issue in method call "+ex.Message;
            }
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
