﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Models.DTOS
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? ImagemUrl { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public string? CategoriaNome { get; set; }

    }
}
