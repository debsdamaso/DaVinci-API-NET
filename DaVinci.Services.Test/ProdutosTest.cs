using Moq;
using DaVinci.Models;
using DaVinci.Service;
using DaVinci.Repository.Interfaces;

namespace DaVinci.Services.Test
{
    public class ProdutosTest
    {
        private readonly Mock<IProdutosRepository> _mockProdutosRepository;
        private readonly ProdutosService _produtosService;

        public ProdutosTest()
        {
            _mockProdutosRepository = new Mock<IProdutosRepository>();
            _produtosService = new ProdutosService(_mockProdutosRepository.Object);
        }

        [Fact]
        public async Task GetAllProdutos_ShouldReturnListOfProdutos()
        {
            var produtosList = new List<Produtos>
            {
                new Produtos { IdProduto = 1, Nome = "Produto 1", Valor = 100 },
                new Produtos { IdProduto = 2, Nome = "Produto 2", Valor = 200 }
            };

            _mockProdutosRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(produtosList);

            var result = await _produtosService.GetAllProdutosAsync();
            var resultList = result.ToList();

            Assert.NotNull(resultList);
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Produto 1", resultList[0].Nome);
        }

        [Fact]
        public async Task GetProdutoById_ShouldReturnProduto_WhenProdutoExists()
        {
            var produto = new Produtos { IdProduto = 1, Nome = "Produto 1", Valor = 100 };

            _mockProdutosRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(produto);

            var result = await _produtosService.GetProdutosByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Produto 1", result.Nome);
        }

        [Fact]
        public async Task GetProdutoById_ShouldReturnNull_WhenProdutoDoesNotExist()
        {
            _mockProdutosRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Produtos?)null);

            var result = await _produtosService.GetProdutosByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateProduto_ShouldAddProduto()
        {
            var newProduto = new Produtos { Nome = "Produto 3", Valor = 300 };

            await _produtosService.CreateProdutosAsync(newProduto);

            _mockProdutosRepository.Verify(repo => repo.AddAsync(newProduto), Times.Once);
        }
    }
}
