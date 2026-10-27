using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public bool StatusProduto { get; set; }

    //Chave Estrangeira

    //O EF Core reconhece pelo padrão "NomeDaClasse + Id"
    public int CategoriaId { get; set; }
    public int MarcaProdutoId { get; set; }

    //PROPRIEDADE DE NAVEGAÇÃO
    public Categoria Categoria { get; set; } = null!;
    public MarcaProduto MarcaProduto { get; set; } = null!;

    //Permite acessar os dados da categoria direto do produto
    public ICollection<ItemCompra> ItemCompra { get; set; } = new List<ItemCompra>();

}
