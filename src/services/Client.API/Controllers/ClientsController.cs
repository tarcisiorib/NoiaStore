using Clients.API.Application.Commands;
using Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Core.Controllers;

namespace Clients.API.Controllers
{
    public class ClientsController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientsController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clients")]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler.SendCommand(
                new RegisterClientCommand(Guid.NewGuid(), "Tarcísio", "tarcisiorib@tfr.com", "34033787054"));

            return CustomResponse(result);
        }
    }
}
