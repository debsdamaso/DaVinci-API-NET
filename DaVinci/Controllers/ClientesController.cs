using Microsoft.AspNetCore.Mvc;
using DaVinci.Models;
using DaVinci.Service.InterfacesService;
using System.Collections.Generic;
using System.Threading.Tasks;
using DaVinci.Service;

namespace DaVinci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;
        private readonly MLService _mlService;

        public ClientesController(IClientesService clientesService, MLService mlService)
        {
            _clientesService = clientesService;
            _mlService = mlService;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            var clientes = await _clientesService.GetAllClientesAsync();
            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetCliente(int id)
        {
            var cliente = await _clientesService.GetClientesByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostCliente([FromBody] Clientes cliente)
        {
            var createdCliente = await _clientesService.CreateClientesAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = createdCliente.IdCliente }, createdCliente);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] Clientes cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }
            try
            {
                await _clientesService.UpdateClientesAsync(id, cliente);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                await _clientesService.DeleteClientesAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Clientes/predicao
        [HttpPost("predicao")]
        public IActionResult Predicao([FromBody] string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return BadRequest("O texto de entrada não pode ser vazio.");
            }

            var resultado = _mlService.PredizerSentimento(texto);
            return Ok(new { Sentimento = resultado });
        }
    }
}
