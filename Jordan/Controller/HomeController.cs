using System;
using System.Diagnostics;
using System.IO;
using Core.Extention;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EventId = Domain.EventId;

namespace WebStore.Controller
{
   
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        { 
            _logger = logger;
        }
        public IActionResult Index()
        {
      
            return View();
        }
        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        [Route("/Error")]
        public IActionResult Error()
        {
            Activity? CurrentActivity = Activity.Current;
            string TraceId = HttpContext.TraceIdentifier;
            string path = HttpContext.Request.Path;
            _logger.LogError(EventId.Error, "(Exceptions)User={UserId} Request={RequestPath} with TraceId={TraceId} get Exception",User.GetUserId(), path, TraceId);
            return View(new ErrorViewModel()
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
        public IActionResult NotFound(string Path)
        {

            _logger.LogWarning(eventId: EventId.NotFound, "(Not Found)UserId={UserId} with Path={Path} ", User.GetUserId(), Path);
            return View();
        }
    }
}
