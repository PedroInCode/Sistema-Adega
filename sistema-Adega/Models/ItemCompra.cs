using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Models;

internal class ItemCompra
{

    public int _idItemCompra { get; protected set; }
    public int _qtdItens {  get; protected set; }
    public decimal _precoUnitario { get; protected set; }
    public Produto _produto { get; protected set; }
    public decimal subtotal { get; protected set; }

    public ItemCompra(int idItemCompra, int qtdItens, decimal precoUnitario, Produto produto, decimal subtotal)
    {
        _idItemCompra = idItemCompra;
        _qtdItens = qtdItens;
        _precoUnitario = precoUnitario;
        _produto = produto;
        this.subtotal = subtotal;
    }
}
