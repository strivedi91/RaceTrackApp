using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RaceTrack.Web.CQRS;
using RaceTrack.Web.CQRS.Commands;
using RaceTrack.Web.CQRS.DTO;
using RaceTrack.Web.CQRS.Queries;
using RaceTrack.Web.Models;

namespace RaceTrack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Route("GetVehiclesOnTracksAsync")]
        [HttpGet]
        public async Task<ActionResult> GetVehiclesOnTracksAsync()
        {
            var data = await _mediator.Send(new GetAllVehiclesOnTrack());
            return Json(data);
        }

        public async Task<IActionResult> AddVehicleOnTrack()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicleOnTrack(AddVehicleOnTrackCommand request)
        {
            var result = await _mediator.Send(request);
            if (string.IsNullOrEmpty(result.Error))
            {
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.ErrorMessage = result.Error;
                return View(result.Data);
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
