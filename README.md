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

O projeto **DaVinci Insights** utiliza uma arquitetura monolítica, o que simplifica a comunicação interna entre os módulos, facilita o processo de desenvolvimento e reduz a complexidade dos testes. O sistema é composto por um backend em ASP.NET Core e um banco de dados Azure SQL.

- --------------------------------------------------

## Projeto   

O projeto tem como objetivo processar dados de feedbacks de usuários que adquiriram produtos ou serviços. A análise desses feedbacks visa extrair insights para que as empresas possam entender as razões das avaliações (sejam elas positivas ou negativas), definir estratégias para melhorar a satisfação dos consumidores e conquistar novos compradores. As avaliações dos clientes são cruciais para a decisão de compra de novos clientes.

<br/>

- --------------------------------------------------

## Design Patterns

- **Repository Pattern**: Isola a lógica de acesso aos dados das entidades (Produtos, Clientes, Feedbacks) da lógica de negócios, facilitando a manutenção e testabilidade.

- **Dependency Injection (DI)**: As dependências (repositórios e serviços) são injetadas nos controladores, permitindo maior modularidade e facilidade nos testes, seguindo o princípio de inversão de controle.

- **Service Layer**: A lógica de negócios é centralizada em serviços, como ClientesService, ProdutosService e FeedbacksService, separados da camada de apresentação, mantendo o código mais limpo e organizado.

- **Unit of Work**: Utiliza o DbContext do Entity Framework para tratar múltiplas operações de banco de dados como uma única transação, garantindo consistência dos dados.

- **CQRS**: A API separa parcialmente operações de leitura e escrita, onde as leituras são feitas sem alterar o estado do sistema e as operações de escrita seguem um fluxo específico.

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

4. Testar Endpoints:
   ### Listar Clientes

   `GET` /api/Clientes : Retorna os dados do cliente
   
   #### Exemplo de Resposta
   
   ```js
   [
   	{
     		"idCliente": 1,
     		"nome": "Cliente Exemplo",
     		"email": "cliente@exemplo.com",
     		"sexo": "M",
     		"cidade": "Cidade Exemplo",
     		"cpf": "12345678900"
   	}
   ]
   ```
   
   ### Detalhar Cliente
   
   `GET` /api/Clientes/`{id}`
   
   Retorna os detalhes do cliente com o `id` informado no path.
   
   #### Exemplo de Resposta
   ```js
   // GET /api/Clientes/1
   {
     	"idCliente": 1,
    	"nome": "Cliente Exemplo",
     	"email": "cliente@exemplo.com",
     	"sexo": "M",
     	"cidade": "Cidade Exemplo",
     	"cpf": "12345678900"
   }
   ```
   
   ### Cadastrar Cliente
   
   `POST` /api/Clientes
   
   Cadastre um cliente com os dados enviados no corpo da requisição.
   
   #### Exemplo de Requisição
   ```js
   // Post /api/Clientes
   {
       "nome": "Cliente Exemplo",
       "email": "cliente@exemplo.com",
       "sexo": "M",
       "cidade": "Cidade Exemplo",
       "cpf": "12345678900"
   }
   
   ```
   
   ### Atualizar Cliente
   `PUT` /api/Clientes/`{id}`
   
   Atualiza os dados do cliente com o `id` informado no path, utilizando as informações do corpo da requisição
   
   #### Exemplo de Requisição
   ```js
   // PUT /api/Clientes/1
   {
       "idCliente": 1,
       "nome": "Cliente Atualizado",
       "email": "cliente.atualizado@exemplo.com",
       "sexo": "F",
       "cidade": "Nova Cidade",
       "cpf": "98765432100"
   }
   ```
   
   ### Apagar Cliente
   
   `DELETE` /api/Clientes/`{id}`
   
   Apaga o cliente com o `id` informado no path

   ----------------------------------------

   ### Listar Feedbacks

   `GET` /api/Feedbacks : Retorna a lista de feedbacks.
   
   #### Exemplo de Resposta
   
   ```js
   [
       {
           "idFeedback": 1,
           "comentario": "Excelente produto!",
           "dataFeedback": "2024-09-15T22:15:25.912Z",
           "avaliacao": 5
       }
   ]
   ```
   
   ### Detalhar Feedback

   `GET` /api/Feedbacks/`{id}` : Retorna os detalhes do feedback com o `id` informado no path.
   
   #### Exemplo de Resposta
   
   ```js
   // GET /api/Feedbacks/1
   {
       "idFeedback": 1,
       "comentario": "Excelente produto!",
       "dataFeedback": "2024-09-15T22:15:25.912Z",
       "avaliacao": 5
   }
   ```
   
   ### Cadastrar Feedback
   
   `POST` /api/Feedbacks : Cadastra um feedback com os dados enviados no corpo da requisição.
   
   #### Exemplo de Requisição
   
   ```js
   // POST /api/Feedbacks
   {
       "comentario": "Excelente produto!",
       "dataFeedback": "2024-09-15T22:15:25.912Z",
       "avaliacao": 5
   }
    ```
   
   ### Atualizar Feedback
   
   `PUT` /api/Feedbacks/`{id}` : Atualiza os dados do feedback com o `id` informado no path, utilizando as informações do corpo da requisição.
   
   #### Exemplo de Requisição
   
   ```js
   // PUT /api/Feedbacks/1
   {
       "idFeedback": 1,
       "comentario": "Produto bom, mas pode melhorar.",
       "dataFeedback": "2024-09-16T10:00:00.000Z",
       "avaliacao": 4
   }
   ```

   ### Apagar Feedback

   `DELETE` /api/Feedbacks/`{id}` : Apaga o feedback com o `id` informado no path.

   ----------------------------------------

   ### Listar Produtos

   `GET` /api/Produtos : Retorna a lista de produtos.
   
   #### Exemplo de Resposta
   
   ```js
   [
       {
           "idProduto": 1,
           "nome": "Produto Exemplo",
           "valor": 100.00,
           "categoria": "Eletrônicos",
           "modelo": "EX123"
       }
   ]
   ```

   ### Detalhar Produto

   `GET` /api/Produtos/`{id}` : Retorna os detalhes do produto com o `id` informado no path.
   
   #### Exemplo de Resposta
   
   ```js
   // GET /api/Produtos/1
   {
       "idProduto": 1,
       "nome": "Produto Exemplo",
       "valor": 100.00,
       "categoria": "Eletrônicos",
       "modelo": "EX123"
   }
   ```

   ### Cadastrar Produto

   `POST` /api/Produtos : Cadastra um produto com os dados enviados no corpo da requisição.
   
   #### Exemplo de Requisição
   
   ```js
   // POST /api/Produtos
   {
       "nome": "Produto Exemplo",
       "valor": 100.00,
       "categoria": "Eletrônicos",
       "modelo": "EX123"
   }
   ```

   ### Atualizar Produto

   `PUT` /api/Produtos/`{id}` : Atualiza os dados do produto com o `id` informado no path, utilizando as informações do corpo da requisição.
   
   #### Exemplo de Requisição
   
   ```js
   // PUT /api/Produtos/1
   {
       "idProduto": 1,
       "nome": "Produto Atualizado",
       "valor": 120.00,
       "categoria": "Eletrônicos",
       "modelo": "EX124"
   }
   ```

   ### Apagar Produto

   `DELETE` /api/Produtos/`{id}` : Apaga o produto com o `id` informado no path.


    
   


    

   
  

