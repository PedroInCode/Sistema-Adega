using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class ItemCompra
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }

    // Chaves Estrangeiras
    public int CompraId { get; set; }
    public int ProdutoId { get; set; }

    // Propriedades de Navegação
    public Compra Compra { get; set; } = null!;
    public Produto Produto { get; set; } = null!;
}
