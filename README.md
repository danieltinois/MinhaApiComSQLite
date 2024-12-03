# 🚀 API de Produtos - Um Sistema Simples de Cadastro de Produtos

Bem-vindo à minha API! Aqui você pode criar, listar, atualizar e deletar produtos de maneira simples e eficaz. Tudo foi feito para garantir uma experiência de desenvolvimento tranquila e produtiva! 💻🎉

## 🧭 Endpoints

### 1. **Criar Produto** - `POST /api/produtos`
Adicione um produto à nossa base de dados com as informações necessárias.

<p><strong>Body (JSON):</strong></p>
<pre>
{
  "nome": "Produto Exemplo",
  "preco": 99.99
}
</pre>

<p><strong>Resposta:</strong> Produto criado com sucesso! 🏅</p>

---

### 2. **Obter Produtos** - `GET /api/produtos`
Liste todos os produtos cadastrados com paginação.

<p><strong>Parâmetros de consulta:</strong></p>
<ul>
  <li><strong>page</strong>: Número da página (padrão 1)</li>
  <li><strong>pageSize</strong>: Número de itens por página (padrão 10)</li>
</ul>

<p><strong>Exemplo de resposta:</strong></p>
<pre>
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
</pre>

---

### 3. **Filtrar Produtos** - `GET /api/produtos/filtrar`
Filtre produtos por nome, preço mínimo e máximo ou ordem de preço.

<p><strong>Parâmetros de consulta:</strong></p>
<ul>
  <li><strong>nome</strong>: Nome do produto (opcional)</li>
  <li><strong>precoMin</strong>: Preço mínimo (opcional)</li>
  <li><strong>precoMax</strong>: Preço máximo (opcional)</li>
  <li><strong>ordem</strong>: Ordenação (opcional: "asc" ou "desc")</li>
</ul>

<p><strong>Exemplo de resposta:</strong></p>
<pre>
[
  {
    "id": 1,
    "nome": "Produto Exemplo",
    "preco": 99.99
  }
]
</pre>

---

### 4. **Obter Produto por ID** - `GET /api/produtos/{id}`
Recupere um produto específico pelo ID.

<p><strong>Exemplo de resposta:</strong></p>
<pre>
{
  "id": 1,
  "nome": "Produto A",
  "preco": 50.00
}
</pre>

---

### 5. **Atualizar Produto** - `PUT /api/produtos/{id}`
Atualize as informações de um produto.

<p><strong>Body (JSON):</strong></p>
<pre>
{
  "nome": "Produto Atualizado",
  "preco": 59.99
}
</pre>

<p><strong>Resposta:</strong> Produto atualizado com sucesso! 🔄</p>

---

### 6. **Remover Produto** - `DELETE /api/produtos/{id}`
Exclua um produto da base de dados.

<p><strong>Resposta:</strong> Produto removido com sucesso! 🗑️</p>

---

## ⚙️ Configuração

1. Clone o repositório.
2. Instale as dependências do projeto.
3. Execute o comando abaixo para rodar o projeto:
   <pre><code>dotnet run --urls "http://localhost:5029"</code></pre>

4. A API estará disponível em <strong>http://localhost:5029</strong>.

---

## 📝 Testando no Postman

1. Abra o Postman.
2. Acesse os endpoints conforme descrito acima.
3. Envie as requisições para a porta <strong>5029</strong>!

---

## 🚀 Sucesso! 🎉

Se você chegou até aqui, parabéns! Agora você tem uma API poderosa e bem estruturada para gerenciar produtos. Espero que você se divirta com ela! 🏆
