using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application;
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

            //get data from remote using comic service
            var response =await _service.GetTodayComic(GeneralSettings.Instance.TodayComicUrl);


            if (response.Success) 
            {
                
                var model = response.GetData<WebComic>();

                _logger.LogInformation($"Getting remote resource is completed!. Sending Data to User -> Comic:{model.Num} {(model.IsTodayComic?"-> Is Today's Comic":"")}");
                return View(model);
            }
            else
            {

                //write info into log
                _logger.LogInformation($"Response Status: {response.StatusCode}. Comic Resource was not found! Redirect to {1} Comic.");

                //Redirect to next or previous comic resource
                return RedirectToAction("Comic", new { code = 1 });
            }

        }



        [HttpGet(Name ="comic")]
        public async Task<IActionResult> Comic(int code)
        {

            //get data from remote using comic service
            var response = await _service.GetComicByCode(code, GeneralSettings.Instance.ComicUrlTpl);
            

            if (response.Success)
            {                
                var model = response.GetData<WebComic>();

                _logger.LogInformation($"Getting remote resource is completed!. Sending Data to User -> Comic:{model.Num} {(model.IsTodayComic ? "-> Is Today's Comic" : "")}");
                return View(model);
            }
            else
            {
                
                //built the next or prev num code comic
                code += (response.NextAction ? 1 : -1);

                //write info into log
                _logger.LogInformation($"Response Status: {response.StatusCode}. Comic Resource was not found! Redirect to {code} Comic.");

                //Redirect to next or previous comic resource
                return RedirectToAction("Comic", new { code = code }); //Redirect to next or previous comic 

            }
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
