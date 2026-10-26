using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Dtos.Produtos;

public class ProdutoCreateDto
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int QuantidadeEstoque { get; set; }
    public bool StatusProduto { get; set; } = true; // <--- Já nasce ativo por padrão
    public int CategoriaId { get; set; }
    public int MarcaProdutoId { get; set; }
}
