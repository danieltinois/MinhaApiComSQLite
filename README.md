🚀 API de Produtos - Um Sistema Simples de Cadastro de Produtos

Bem-vindo à nossa API! Aqui você pode criar, listar, atualizar e deletar produtos de maneira simples e eficaz. Tudo foi feito para garantir uma experiência de desenvolvimento tranquila e produtiva! 💻🎉
🧭 Endpoints
1. Criar Produto - POST /api/produtos

Adicione um produto à nossa base de dados com as informações necessárias.

    Body (JSON):

    {
      "nome": "Produto Exemplo",
      "preco": 99.99
    }

    Resposta: Produto criado com sucesso! 🏅

2. Obter Produtos - GET /api/produtos

Liste todos os produtos cadastrados com paginação.

    Parâmetros de consulta:
        page: Número da página (padrão 1)
        pageSize: Número de itens por página (padrão 10)

    Exemplo de resposta:

    {
      "page": 1,
      "pageSize": 10,
      "totalProdutos": 50,
      "totalPages": 5,
      "data": [
        {
          "id": 1,
          "nome": "Produto A",
          "preco": 50.00
        }
      ]
    }

3. Filtrar Produtos - GET /api/produtos/filtrar

Filtre produtos por nome, preço mínimo e máximo ou ordem de preço.

    Parâmetros de consulta:
        nome: Nome do produto (opcional)
        precoMin: Preço mínimo (opcional)
        precoMax: Preço máximo (opcional)
        ordem: Ordenação (opcional: "asc" ou "desc")

    Exemplo de resposta:

    [
      {
        "id": 1,
        "nome": "Produto Exemplo",
        "preco": 99.99
      }
    ]

4. Obter Produto por ID - GET /api/produtos/{id}

Recupere um produto específico pelo ID.

    Exemplo de resposta:

    {
      "id": 1,
      "nome": "Produto A",
      "preco": 50.00
    }

5. Atualizar Produto - PUT /api/produtos/{id}

Atualize as informações de um produto.

    Body (JSON):

    {
      "nome": "Produto Atualizado",
      "preco": 59.99
    }

    Resposta: Produto atualizado com sucesso! 🔄

6. Remover Produto - DELETE /api/produtos/{id}

Exclua um produto da base de dados.

    Resposta: Produto removido com sucesso! 🗑️

⚙️ Configuração

    Clone o repositório.

    Instale as dependências do projeto.

    Execute o comando abaixo para rodar o projeto:

    dotnet run --urls "http://localhost:5029"

    A API estará disponível em http://localhost:5029.

📝 Testando no Postman

    Abra o Postman.
    Acesse os endpoints conforme descrito acima.
    Envie as requisições para a porta 5029!

🚀 Sucesso! 🎉

Se você chegou até aqui, parabéns! Agora você tem uma API poderosa e bem estruturada para gerenciar produtos. Espero que você se divirta com ela! 🏆


