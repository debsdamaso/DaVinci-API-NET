<div align="center">
   <h2> DaVinci Insights </h2>
</div>

<h3> Integrantes </h3>

- RM550341 - Allef Santos (2TDSPV)
- RM551491 - Cassio Yuji Hirassike Sakai
- RM97836 - Debora Damasso Lopes
- RM550323 - Paulo Barbosa Neto
- RM552314 - Yasmin Araujo Santos Lopes

- --------------------------------------------------

## Arquitetura

A arquitetura do projeto **DaVinci Insights** adota uma abordagem monolítica, o que simplifica a comunicação interna entre os módulos, facilita o processo de desenvolvimento e reduz a complexidade dos testes. O sistema é composto por um backend em ASP.NET Core e um banco de dados Azure SQL.

- --------------------------------------------------

## Projeto

Bem-vindo ao **DaVinci Insights**. O projeto tem como objetivo processar dados de feedbacks de usuários que adquiriram produtos ou serviços. A análise desses feedbacks visa extrair insights para que as empresas possam entender as razões das avaliações (sejam elas positivas ou negativas), definir estratégias para melhorar a satisfação dos consumidores e conquistar novos compradores. As avaliações dos clientes são cruciais para a decisão de compra de novos clientes.

<br/>

- --------------------------------------------------

## Design Patterns

- **Singleton**: Garante que certas partes do sistema, como configurações, tenham apenas uma única instância, evitando duplicações.

- **Repository Pattern**: Cria uma camada que simplifica a forma como o sistema acessa e manipula os dados, separando isso da lógica de negócios.

- **Service Layer**: Organiza e isola a lógica de negócios em uma camada separada, facilitando a manutenção e a reutilização do código.

- --------------------------------------------------

## Endpoints

### **Clientes**
- `GET /api/Clientes` - Retorna todos os clientes.
- `POST /api/Clientes` - Cria um novo cliente.
- `GET /api/Clientes/{id}` - Retorna um cliente específico por ID.
- `PUT /api/Clientes/{id}` - Atualiza um cliente existente por ID.
- `DELETE /api/Clientes/{id}` - Exclui um cliente por ID.

### **Feedbacks**
- `GET /api/Feedbacks` - Retorna todos os feedbacks.
- `POST /api/Feedbacks` - Cria um novo feedback.
- `GET /api/Feedbacks/{id}` - Retorna um feedback específico por ID.
- `PUT /api/Feedbacks/{id}` - Atualiza um feedback existente por ID.
- `DELETE /api/Feedbacks/{id}` - Exclui um feedback por ID.

### **Produtos**
- `GET /api/Produtos` - Retorna todos os produtos.
- `POST /api/Produtos` - Cria um novo produto.
- `GET /api/Produtos/{id}` - Retorna um produto específico por ID.
- `PUT /api/Produtos/{id}` - Atualiza um produto existente por ID.
- `DELETE /api/Produtos/{id}` - Exclui um produto por ID.

- --------------------------------------------------

## Rodando a Aplicação

Passos:
1. Clonar o repositório:
   ```bash
   git clone https://github.com/seu-usuario/DaVinci-API-NET.git
   cd DaVinci-API-NET
   ```

2. Restaurar as dependências e executar a aplicação:
    ```bash
    dotnet restore
    dotnet run --project DaVinci/DaVinci.csproj
    ```

3. Acessar o Swagger:
    ```bash
    http://localhost:5004/swagger/index.html
    ```


    

   
  

