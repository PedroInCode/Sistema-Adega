using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class CupomDesconto
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public decimal PercentualDesconto { get; set; }
    public DateTime DataValidade { get; set; }
    public bool Ativo { get; set; }

    public ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
