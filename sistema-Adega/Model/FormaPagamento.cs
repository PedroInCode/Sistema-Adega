using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class FormaPagamento
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;

    // Relacionamento com compras
    public ICollection<Compra> Compras { get; set; } = new List<Compra>(); 
}
