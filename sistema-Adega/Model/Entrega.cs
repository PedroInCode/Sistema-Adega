using sistema_Adega.Models.Enums.Status;
using sistema_Adega.Models.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class Entrega
{
    public int Id { get; set; }
    public DateTime? DataPrevisao { get; set; }

    public StatusEntrega StatusEntrega { get; set; }
    public TipoFrete TipoFrete { get; set; }

    // Chave Estrangeira para a Compra
    public int CompraId { get; set; }
    public Compra Compra { get; set; } = null!;

    // --- NOVO: Qual funcionário (motorista) vai realizar essa entrega? ---
    public int? FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }

    public int EnderecoId { get; set; }
    public Endereco Endereco { get; set; } = null!;
}
