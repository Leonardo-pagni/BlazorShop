﻿using BlazorShop.Models.DTOS;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorShop.Web.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly HttpClient httpClient;

        public CarrinhoCompraService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<CarrinhoItemAdicionaDto>("api/CarrinhoCompra", carrinhoItemAdicionaDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CarrinhoItemDto);
                    }

                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"status: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CarrinhoItemDto> AtualizaQuantidade(CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            try
            {
                var jsonRequest = JsonSerializer.Serialize(carrinhoItemAtualizaQuantidadeDto);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"api/CarrinhoCompra/{carrinhoItemAtualizaQuantidadeDto.CarringoItemId}", content);

                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }

                return null;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<CarrinhoItemDto> DeletaItem(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/CarrinhoCompra/{id}");

                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                return default(CarrinhoItemDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CarrinhoItemDto>> getItens(int usuarioId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/CarrinhoCompra/{usuarioId}/GetItens");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CarrinhoItemDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CarrinhoItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} mensagem: {message}");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
