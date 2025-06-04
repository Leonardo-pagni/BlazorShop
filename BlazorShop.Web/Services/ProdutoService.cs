using BlazorShop.Models.DTOS;
using System.Net;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        public HttpClient _httpClient;
        public ILogger<ProdutoService> _logger;

        public ProdutoService(HttpClient httpClient, ILogger<ProdutoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<ProdutoDto>> GetItens()
        {
            try
            {
                var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/Produtos");

                return produtosDto;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<ProdutoDto> GetItem(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Produtos/{id}");

                if (response.IsSuccessStatusCode)// Status code 200-299
                {
                    if (response.StatusCode == HttpStatusCode.NoContent) // Status 204
                    {
                        return default(ProdutoDto); // retorna nullo
                    }
                    return await response.Content.ReadFromJsonAsync<ProdutoDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter o produto pelo ID = {id} - {message}");
                    throw new Exception($"Status Code: {response.StatusCode} - {message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter o produto pelo ID = {id} - {ex.Message}");
                throw;
            }
        }
    }
}
