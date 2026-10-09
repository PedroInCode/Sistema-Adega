using Microsoft.AspNetCore.Mvc;
using sistema_Adega.Enums;
using sistema_Adega.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Models;

internal class Compra
{
    private List<ItemCompra> _itensCompra;

    public int idCompra { get; protected set; }
    public DateTime dataCompra { get; protected set; }
    public TipoCompra tipoCompra { get; protected set; }
    public TipoFrete tipoFrete { get; protected set; }
    public double valorFrete { get; protected set; }
    public double valorTotal { get; protected set; }

    public IReadOnlyList<ItemCompra> ItensCompra => _itensCompra.AsReadOnly();


    public Compra(int idCompra, TipoCompra tipoCompra, TipoFrete tipoFrete, double valorFrete)
    {
        this.idCompra = idCompra;
        this.dataCompra = DateTime.Now;
        this.tipoCompra = tipoCompra;
        this.tipoFrete = tipoFrete;
        this.valorFrete = valorFrete;
        this.valorTotal = 0;
        this._itensCompra = new List<ItemCompra>();
    }

    public void AdicionarItem(ItemCompra itemCompra)
    {
        var itemExistente = BuscarItem(itemCompra._idItemCompra);

        if(itemCompra._qtdItens <= 0)
        {

        }

        if (itemExistente != null)
        {
            this._itensCompra.Add(itemExistente);
        }
    }

    public ItemCompra? BuscarItem(int idItem)
    {
        return _itensCompra.FirstOrDefault(item => item._idItemCompra == idItem);
    }

    public bool RemoverItem(int idItem)
    {
        var itemExistente = BuscarItem(idItem);

        if( itemExistente != null )
        {
            return this._itensCompra.Remove(itemExistente);
        }

        return false;
    }

    public void CalcularTotal()
    {
        decimal vTotal = 0;

        foreach(var item in _itensCompra)
        {
            vTotal += item._precoUnitario
        }
    }
}
