using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Dtos.Produtos;

public class ProdutoUpdateDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; } 
    public int QuantidadeEstoque { get; set; }
    public bool StatusProduto { get; set; } //ativo ou inativo
    public int CategoriaId { get; set; }
    public int MarcaProdutoId { get; set; }
}
