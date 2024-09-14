using Moq;
using DaVinci.Models;
using DaVinci.Service;
using DaVinci.Repository.Interfaces;

namespace DaVinci.Services.Test
{
    public class ClientesTest
    {
        private readonly Mock<IClientesRepository> _mockClientesRepository;
        private readonly ClientesService _clientesService;

        public ClientesTest()
        {
            _mockClientesRepository = new Mock<IClientesRepository>();
            _clientesService = new ClientesService(_mockClientesRepository.Object);
        }

        [Fact]
        public async Task GetAllClientes_ShouldReturnListOfClientes()
        {
            var clientesList = new List<Clientes>
            {
                new Clientes { IdCliente = 1, Nome = "Cliente 1", Email = "cliente1@example.com" },
                new Clientes { IdCliente = 2, Nome = "Cliente 2", Email = "cliente2@example.com" }
            };

            _mockClientesRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(clientesList);

            var result = await _clientesService.GetAllClientesAsync();
            var resultList = result.ToList();

            Assert.NotNull(resultList);
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Cliente 1", resultList[0].Nome);
            Assert.Equal("Cliente 2", resultList[1].Nome);
        }

        [Fact]
        public async Task GetClienteById_ShouldReturnCliente_WhenClienteExists()
        {
            var cliente = new Clientes { IdCliente = 1, Nome = "Cliente 1", Email = "cliente1@example.com" };

            _mockClientesRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(cliente);

            var result = await _clientesService.GetClientesByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Cliente 1", result?.Nome);
        }

        [Fact]
        public async Task GetClienteById_ShouldReturnNull_WhenClienteDoesNotExist()
        {
            _mockClientesRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Clientes?)null);

            var result = await _clientesService.GetClientesByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateCliente_ShouldAddCliente()
        {
            var newCliente = new Clientes { Nome = "Cliente 3", Email = "cliente3@example.com" };

            await _clientesService.CreateClientesAsync(newCliente);

            _mockClientesRepository.Verify(repo => repo.AddAsync(newCliente), Times.Once);
        }
    }
}
