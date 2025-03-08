using Microsoft.AspNetCore.Mvc;
using S71500.RestApi.Application.Models;
using S71500.RestApi.Application.Services;
using S71500.RestApi.Contracts.Requests;
using S71500.RestApi.Contracts.Responses;
using S71500.RestApi.Mapping;

namespace S71500.RestApi.Controllers
{
    [ApiController]
    public class ApiRequestController : ControllerBase
    {
        private readonly IApiMethodService _methodService;
        private readonly IApiWebAppService _webAppService;

        public ApiRequestController(IApiMethodService methodService, IApiWebAppService webAppService)
        {
            _methodService = methodService;
            _webAppService = webAppService;
        }

        [HttpGet(ApiEndpoints.Methods.GetAll)]
        [ProducesResponseType(typeof(ApiMethodsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMethods([FromQuery] GetAllMethodsRequest request,
            CancellationToken cancellationToken = default)
        {
            var options = request.MapToOptionsBase();
            var methods = await _methodService.GetAllAsync(options, cancellationToken);
            var response = methods.MapToResponse();
            return Ok(response);
        }


        [HttpGet(ApiEndpoints.Methods.Get)]
        [ProducesResponseType(/*typeof(ApiMethodResponse), */StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] string name,
        [FromQuery] bool includingErrorCodes = true,
        [FromQuery] bool includingParameters = true,
        [FromQuery] bool includingResultType = true,
        CancellationToken cancellationToken = default)
        {
            var options = new GetMethodOptions() { IncludingErrorCodes = true, IncludingParameters = true, IncludingResultType = true, MethodName = name };
            var method = await _methodService.GetAsync(options, cancellationToken);
            if (method is null)
            {
                return NotFound();
            }
            return Ok(method);
        }

        [HttpGet(ApiEndpoints.WebApps.GetAll)]
        [ProducesResponseType(typeof(ApiWebAppsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var webApps = await _webAppService.GetAllAsync(cancellationToken);
            var response = webApps.MapToResponse();
            return Ok(response);
        }


    }
}
