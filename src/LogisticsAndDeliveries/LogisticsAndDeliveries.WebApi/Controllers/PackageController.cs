using LogisticsAndDeliveries.Application.Packages.CancelPackage;
using LogisticsAndDeliveries.Application.Packages.CreatePackages;
using LogisticsAndDeliveries.Application.Packages.MarkPackageDelivered;
using LogisticsAndDeliveries.Application.Packages.MarkPackageFailed;
using LogisticsAndDeliveries.Application.Packages.MarkPackageInTransit;
using LogisticsAndDeliveries.Application.Packages.RegisterPackageDeliveryIncident;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsAndDeliveries.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PackageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage([FromBody] CreatePackageCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("markInTransit")]
        public async Task<IActionResult> MarkPackageInTransit([FromBody] MarkPackageInTransitCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result.Value);
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelPackage([FromBody] CancelPackageCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result.Value);
        }

        [HttpPost("markDelivered")]
        public async Task<IActionResult> MarkPackageDelivered([FromBody] MarkPackageDeliveredCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result.Value);
        }

        [HttpPost("markFailed")]
        public async Task<IActionResult> MarkPackageFailed([FromBody] MarkPackageFailedCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result.Value);
        }

        [HttpPost("registerIncident")]
        public async Task<IActionResult> RegisterPackageDeliveryIncident([FromBody] RegisterPackageDeliveryIncidentCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result.Value);
        }
    }
}
