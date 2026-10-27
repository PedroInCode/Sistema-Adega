using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Dtos.Produtos;

public class ProdutoResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public bool StatusProduto { get; set; }

    //Em vez de trazer o obj Categoria inteiro, trazemos apenas o Nome!
    public string CategoriaNome { get; set; } = string.Empty;

    //Em vez de trazer o obj MarcaProduto inteiro, trazemos apenas o Nome!
    public string MarcaProdutoNome { get; set; } = string.Empty;
}
