using Backend.Kubernetes.API.Application.Extensions;
using Backend.Kubernetes.API.Domain.Exceptions;
using Backend.Kubernetes.API.Infraestructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Kubernetes.API.Controllers
{
    [ApiController]
    [Route("pod")]
    public class PodController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PodController> _logger;
        private readonly IKubernetesService _kubernetesService;

        public PodController(IMediator mediator, 
                            ILogger<PodController> logger,
                            IKubernetesService kubernetesService)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
            _logger = logger ?? throw new ArgumentNullException();
            _kubernetesService = kubernetesService ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// get information of all pod in the cluster
        /// </summary>
        /// <param name="ns">namespace inside of kubernetes Cluster</param>
        /// <returns>Pods</returns>
        [HttpGet]
        [Route("ns")]      
        public async Task<IActionResult> GetByNamespace(string ns = "default")
        {
            try
            {
                var pods = await _kubernetesService.GetPodsByNamespace(ns);

                return Ok(pods);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.ToError());
            }
            catch (Exception ex)
            {
                return ErrorHandling(ex);
            }
        }


        private ObjectResult ErrorHandling(Exception ex, [CallerMemberName] string callerName = "")
        {
            string message = $"{Assembly.GetEntryAssembly().GetName().Name}:{callerName}: {ex.Message}";
            // Si es excepcion de rut invalido no se deja log
            if (ex.GetType() != typeof(InvalidRutException)) _logger.LogError(ex, message);
            return BadRequest(ex.ToError(message));
        }

    }
}
