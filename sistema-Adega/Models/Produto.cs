using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int qtdEstoque { get; set; }
    public bool statusProduto { get; set; }

    //Chave Estrangeira

    //O EF Core reconhece pelo padrão "NomeDaClasse + Id"
    public int CategoriaId { get; set; }
    public int MarcaProdutoId { get; set; }

    //PROPRIEDADE DE NAVEGAÇÃO

    //Permite acessar os dados da categoria direto do produto
    public ICollection<ItemCompra> ItensCompra { get; set; } = new List<ItemCompra>();

}
