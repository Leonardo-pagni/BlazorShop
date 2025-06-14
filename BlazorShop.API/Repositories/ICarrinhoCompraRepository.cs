﻿using BlazorShop.API.Entities;
using BlazorShop.Models.DTOS;

namespace BlazorShop.API.Repositories
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);

        Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);

        Task<CarrinhoItem> DeletaItem(int id);

        Task<CarrinhoItem> GetItem(int id);

        Task<IEnumerable<CarrinhoItem>> GetItens(int usuarioId);
    }
}
