using BlazorShop.API.Mappings;
using BlazorShop.API.Repositories;
using BlazorShop.Models.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraRepository carrinhoCompraRepository;
        private readonly IProdutoRepository produtoRepository;

        private ILogger logger;

        public CarrinhoCompraController(ICarrinhoCompraRepository carrinhoCompraRepository, IProdutoRepository produtoRepository, ILogger logger)
        {
            this.carrinhoCompraRepository = carrinhoCompraRepository;
            this.produtoRepository = produtoRepository;
            this.logger = logger;
        }

        [HttpGet]
        [Route ("{usuarioId}/GetItens")]
        public async Task<ActionResult<IEnumerable<CarrinhoItemDto>>> GetItens(int usuarioId)
        {
            try
            {
                var carrinhoItens = await carrinhoCompraRepository.GetItens(usuarioId);
                if (carrinhoItens == null)
                {
                    return NoContent();
                }
                var produtos = await this.produtoRepository.GetItens();
                if (produtos == null)
                {
                    throw new Exception("Não existems produtos...");
                }

                var carrinhoItensDto = carrinhoItens.ConverterCarrinhoItensParaDto(produtos);
                return Ok(carrinhoItensDto);
            }
            catch (Exception ex)
            {
                logger.LogError("Erro ao obtes os itens do carrinho. Detalhes: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> GetItem(int id)
        {
            try
            {
                var carrinhoItem = await carrinhoCompraRepository.GetItem(id);
                if (carrinhoItem == null)
                {
                    return NotFound();
                }

                var produto = await this.produtoRepository.GetItem(carrinhoItem.ProdutoId);
                if (produto == null)
                {
                    return NotFound("produto não encontrado...");
                }

                var cartItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obtes o item {id} do carrinho. Detalhes: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDto>> PostItem([FromBody] CarrinhoItemAdicionaDto carrinhoItemAdiciona)
        {
            try
            {
                var novoCarrinhoitem = await carrinhoCompraRepository.AdicionaItem(carrinhoItemAdiciona);

                if(novoCarrinhoitem == null)
                {
                    return NoContent();
                }

                var Produto = await produtoRepository.GetItem(novoCarrinhoitem.ProdutoId);

                if(Produto == null)
                {
                    throw new Exception($"Produto não localizado (Id:({novoCarrinhoitem.ProdutoId})");
                }

                var novoCarrinhoitemDto = novoCarrinhoitem.ConverterCarrinhoItemParaDto(Produto);

                return CreatedAtAction(nameof(GetItem), new { id = novoCarrinhoitem.Id }, novoCarrinhoitemDto);
            }
            catch(Exception ex)
            {
                logger.LogError("Erro ao criar um novo item no carrinho. Detalhes : " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
