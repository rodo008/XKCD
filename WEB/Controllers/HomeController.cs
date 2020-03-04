using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private WebComicService _service;

        public HomeController(ILogger<HomeController> logger,WebComicService service)
        {
            _logger = logger;
            _service = service; 
        }

        public async Task<IActionResult> Index()
        {
            var response =await _service.GetActualWebComic();
            var model = response.GetData<WebComic>();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Comic(int code)
        {
            var response = await _service.GetWebComic(code);
            var model = response.GetData<WebComic>();

            return View(model);
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
