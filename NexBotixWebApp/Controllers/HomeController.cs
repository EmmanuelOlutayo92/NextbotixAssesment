using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NexBotixWebApp.Models;
using NexBotixWebApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NexBotixWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GetData _data;


        public HomeController(ILogger<HomeController> logger, GetData Data)
        {
            _logger = logger;
            _data = Data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Table()
        {
            return View(_data.keyValues());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
