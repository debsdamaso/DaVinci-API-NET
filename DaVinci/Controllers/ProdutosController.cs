using Microsoft.AspNetCore.Mvc;
using DaVinci.Models;
using DaVinci.Service.InterfacesService;

namespace DaVinci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
        {
            var produtos = await _produtosService.GetAllProdutosAsync();
            return Ok(produtos);
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> GetProduto(int id)
        {
            var produto = await _produtosService.GetProdutosByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        // POST: api/Produtos
        [HttpPost]
        public async Task<ActionResult<Produtos>> PostProduto([FromBody] Produtos produto)
        {
            var createdProduto = await _produtosService.CreateProdutosAsync(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = createdProduto.IdProduto }, createdProduto);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, [FromBody] Produtos produto)
        {
            if (id != produto.IdProduto)
            {
                return BadRequest();
            }
            try
            {
                await _produtosService.UpdateProdutosAsync(id, produto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                await _produtosService.DeleteProdutosAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
