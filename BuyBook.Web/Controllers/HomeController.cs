using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BuyBook.Web.Models;
using MediatR;
using BuyBook.Application.PopulateDatabase;

namespace BuyBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly UserPopulate _userPopulate;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, UserPopulate populate)
        {
            _logger = logger;
            _userPopulate = populate;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            _userPopulate.PopulateTable();
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
