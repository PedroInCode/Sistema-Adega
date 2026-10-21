using Microsoft.AspNetCore.Mvc;
using sistema_Adega.Models.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Models;

public class Compra
{
    public int Id { get; set; }
    public DateTime DataCompra { get; set; } = DateTime.Now;
    public decimal ValorTotal { get; set; }

    // Chaves Estrangeiras
    public int ClienteId { get; set; }
    public int FormaPagamentoId { get; set; }

    // Ocupa opcionalmente um cupom de desconto
    public int? CupomDescontoId { get; set; }

    // Propriedades de Navegação
    public Cliente Cliente { get; set; } = null!;
    public FormaPagamento FormaPagamento { get; set; } = null!;
    public CupomDesconto? CupomDesconto { get; set; }

    // Relação 1 para N com os itens da compra
    public ICollection<ItemCompra> ItensCompra { get; set; } = new List<ItemCompra>();

    // Relação 1 para 1 (ou 1 para N) com Entrega
    public Entrega? Entrega { get; set; }

}
