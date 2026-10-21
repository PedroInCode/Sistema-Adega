using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Models;

public class Entrega
{
    public int Id { get; set; }
    public string StatusEntrega { get; set; } = "Pendente";
    public DateTime? DataPrevisao { get; set; }
    public string CodigoRastreio { get; set; } = string.Empty;

    // Chave Estrangeira (Ligação 1 para 1 com Compra)
    public int CompraId { get; set; }
    public Compra Compra { get; set; } = null!;
}
