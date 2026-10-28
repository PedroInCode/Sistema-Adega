using sistema_Adega.Model.Enums.Tipo;
using sistema_Adega.Models.Enums.Status;
using sistema_Adega.Models.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class Compra
{
    public int Id { get; set; }
    public DateTime DataCompra { get; set; } = DateTime.Now;
    public decimal ValorTotal { get; set; }

    // Utilizando os Enums organizados nas pastas
    public StatusCompra Status { get; set; }
    public TipoCompra TipoCompra { get; set; } // Ex: Presencial ou Online
    public FormaPagamento FormaPagamento { get; set; }

    // --- Chaves Estrangeiras ---
    public int ClienteId { get; set; }
    public int? FuncionarioId { get; set; } // Pode ser nulo caso seja uma compra 100% online feita pelo site sem vendedor direto
    public int? CupomDescontoId { get; set; }

    // --- Propriedades de Navegação (EF Core) ---
    public Cliente Cliente { get; set; } = null!;
    public Funcionario? Funcionario { get; set; }
    public CupomDesconto? CupomDesconto { get; set; }
    public Entrega? Entrega { get; set; }
    public ICollection<ItemCompra> ItensCompra { get; set; } = new List<ItemCompra>();

}
