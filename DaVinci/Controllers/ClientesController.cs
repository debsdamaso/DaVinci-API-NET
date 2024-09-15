using Microsoft.AspNetCore.Mvc;
using DaVinci.Models;
using DaVinci.Service.InterfacesService;

namespace DaVinci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
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
    }
}
