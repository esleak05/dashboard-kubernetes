using Backend.Kubernetes.API.Application.Extensions;
using Backend.Kubernetes.API.Application.Handlers.Queries;
using Backend.Kubernetes.API.Application.RequestModels;
using Backend.Kubernetes.API.Application.ResponseModels;
using Backend.Kubernetes.API.Application.Utils;
using Backend.Kubernetes.API.Domain.Exceptions;
using Backend.Kubernetes.API.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Kubernetes.API.Controllers
{
    [ApiController]
    [Route("")]
    public class MandateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MandateController> _logger;

        public MandateController(IMediator mediator, ILogger<MandateController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Verifica si el rut califica para mandato y si tiene un mandato valido
        /// </summary>
        /// <param name="rut">Rut con digito verificador</param>
        /// <returns>HasMandateResponse</returns>
        [HttpGet]
        [Route("{rut}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HasMandateResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> HasMandate(string rut)
        {

            try
            {
                if (!RutUtils.IsValidRut(rut)) throw new InvalidRutException(rut);

                var response = await _mediator.Send(new HasMandateRequest { Rut = rut });
                return Ok(response);
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


        /// <summary>
        /// Retorna el mandato formato pdf listo para firmar 
        /// Solo utilizar si el rut aplica para mandato
        /// </summary>
        /// <param name="rut">Rut con digito verificador</param>
        /// <returns>File</returns>
        [HttpGet]
        [Route("pdf/{rut}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(File))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetMandatePdf(string rut)
        {
            try
            {
                if (!RutUtils.IsValidRut(rut)) throw new InvalidRutException(rut);

                var response = await _mediator.Send(new GetMandatePdfRequest { Rut = rut });
                return File(
                    response.MandatePdfBytes,
                    "application/octet-stream",
                    $"Mandato_Amplio_{RutUtils.FormatRutWithOutDots(rut)}_{DateTime.Now:ddMMyyyy-HHmm}.pdf"
                );
            }
            catch (Exception ex)
            {
                return ErrorHandling(ex);
            }
        }

        /// <summary>
        /// Crea registro de mandato asociado al rut, utilizar solo si rut califica para mandato
        /// </summary>
        /// <param name="rut">Rut con digito verificador</param>
        /// <param name="signed">true si firmo mandato, false no firmo mandato</param>
        /// <param name="executive">Nombre del ejecutiv@</param>
        /// <returns>SignMandateResponse</returns>
        [HttpPost]
        [Route("sign/{rut}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SignMandateResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]

        public async Task<IActionResult> SignMandate(string rut, [BindRequired] bool signed, [BindRequired] string executive)
        {
            try
            {
                if (!RutUtils.IsValidRut(rut)) throw new InvalidRutException(rut);

                var response = await _mediator.Send(new SignMandateRequest { Rut = rut, Signed = signed, Executive = executive });
                return Ok(response);
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
