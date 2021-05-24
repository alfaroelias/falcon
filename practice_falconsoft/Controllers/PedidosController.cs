using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using practice_falconsoft.Entities;
using practice_falconsoft.Helpers;
using practice_falconsoft.Models;
using practice_falconsoft.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepo _pedidoRepo;

        public PedidosController(IPedidoRepo pedidoRepo)
        {
            _pedidoRepo = pedidoRepo;
        }

        [HttpGet(Name = "GetPedidoPaginado")]
        [HttpHead]
        public async Task<ActionResult<PagedList<Pedido>>> GetPedidoPaginado([FromQuery] PedidosParameters pedidosParameters)
        {
            var pedidos = await _pedidoRepo.GetPedidoPaginado(pedidosParameters);

            return Ok(pedidos);
        }
    }
}
