using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using Zadania.Data;
using Zadania.Helpers.SRTProcessor;
using Zadania.Models;

namespace Zadania.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly SubtitleProcessor _subtitleProcessor;
        IWebHostEnvironment _hostingEnvironment;
        public HomeController(
            ILogger<HomeController> logger, 
            IHttpClientFactory clientFactory, 
            IMapper mapper, 
            DatabaseContext context,
             IWebHostEnvironment hostingEnvironment
            )
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _mapper = mapper;
            _context = context;
            _subtitleProcessor = new SubtitleProcessor();
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var startTime = new TimeSpan(00,00,00,03,640) ;

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