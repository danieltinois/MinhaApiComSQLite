using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApi.Data;
using ProdutosApi.Models;

namespace ProdutosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Construtor que recebe o contexto do banco de dados via injeção de dependência
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // Método para criar um novo produto
        [HttpPost]
        public IActionResult CriarProduto([FromBody] Produto produto)
        {
            // Validações para o nome e preço do produto
            if (string.IsNullOrWhiteSpace(produto.Nome))
                return BadRequest(new { error = "O nome não pode ser vazio ou nulo." });

            if (produto.Preco <= 0)
                return BadRequest(new { error = "O preço deve ser maior que zero." });

            // Ajusta o nome do produto para letras maiúsculas
            produto.Nome = produto.Nome.ToUpper();

            try
            {
                // Adiciona o produto ao banco e salva as alterações
                _context.Produtos.Add(produto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Retorna erro genérico caso ocorra falha no banco
                return StatusCode(500, new { error = "Erro ao salvar o produto no banco de dados", details = ex.Message });
            }

            // Retorna o produto criado e redireciona para o método ObterProdutoPorId
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = produto.Id }, produto);
        }

        // Método para obter produtos com paginação e ordenação
        [HttpGet]
        public IActionResult ObterProdutos([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            // Validações de entrada para paginação
            if (page <= 0 || pageSize <= 0)
                return BadRequest(new { error = "Página e tamanho da página devem ser maiores que zero." });

            // Obtém todos os produtos, ordena por preço e ajusta nomes contendo "PROMOÇÃO"
            var produtos = _context.Produtos
                .ToList()
                .OrderBy(page => page.Preco) // Ordenação por preço
                .ToList();

            foreach (var produto in produtos)
            {
                if (produto.Nome.Contains("PROMOÇÃO", StringComparison.OrdinalIgnoreCase))
                {
                    produto.Nome = $"{produto.Nome} [Em promoção]";
                }
            }

            // Aplica a lógica de paginação
            var paginados = produtos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Monta a resposta com metadados de paginação
            var totalProdutos = _context.Produtos.Count();
            var response = new
            {
                page,
                pageSize,
                totalProdutos,
                totalPages = (int)Math.Ceiling((double)totalProdutos / pageSize),
                data = paginados
            };

            return Ok(response);
        }

        // Método para filtrar produtos por critérios opcionais
        [HttpGet("filtrar")]
        public IActionResult FiltrarProdutos([FromQuery] string? nome, [FromQuery] decimal? precoMin, [FromQuery] decimal? precoMax, [FromQuery] string? ordem)
        {
            var query = _context.Produtos.AsQueryable();

            // Filtro por nome
            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(p => p.Nome.Contains(nome.ToUpper()));

            // Filtros por faixa de preço
            if (precoMin.HasValue)
                 query = query.Where(p => p.Preco >= precoMin.Value);

            if (precoMax.HasValue)
                query = query.Where(p => p.Preco <= precoMax.Value);

            // Obtém os produtos da base de dados
            var produtos = query.ToList();

            // Ordenação no lado do cliente
            if (!string.IsNullOrWhiteSpace(ordem))
            {
                produtos = ordem.ToLower() == "asc"
                 ? produtos.OrderBy(p => p.Preco).ToList()
                 : produtos.OrderByDescending(p => p.Preco).ToList();
            }

        // Retorna a lista de produtos filtrados e ordenados
        return Ok(produtos);
}

        // Método para obter um produto específico pelo ID
        [HttpGet("{id}")]
        public IActionResult ObterProdutoPorId(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            // Retorna 404 se o produto não for encontrado
            if (produto == null)
                return NotFound(new { error = "Produto não encontrado." });

            return Ok(produto);
        }

        // Método para atualizar um produto existente
        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, [FromBody] Produto produtoAtualizado)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            // Validações de existência e entrada
            if (produto == null)
                return NotFound(new { error = "Produto não encontrado." });

            if (string.IsNullOrWhiteSpace(produtoAtualizado.Nome))
                return BadRequest(new { error = "O nome não pode ser vazio ou nulo." });

            if (produtoAtualizado.Preco <= 0)
                return BadRequest(new { error = "O preço deve ser maior que zero." });

            // Atualiza os campos do produto
            if (!string.IsNullOrWhiteSpace(produtoAtualizado.Nome))
            {
                produto.Nome = char.ToUpper(produtoAtualizado.Nome[0]) + produtoAtualizado.Nome.Substring(1).ToLower();
            }
            produto.Preco = produtoAtualizado.Preco;

            // Salva as alterações no banco
            _context.SaveChanges();
            return Ok(produto);
        }

        // Método para remover um produto
        [HttpDelete("{id}")]
        public IActionResult RemoverProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            // Retorna 404 se o produto não existir
            if (produto == null)
                return NotFound(new { error = "Produto não encontrado." });

            // Remove o produto e salva as alterações
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
