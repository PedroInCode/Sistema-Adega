using sistema_Adega.Models.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    // Documento e o Enum correspondente (CPF ou CNPJ)
    public string Documento { get; set; } = string.Empty;
    public TipoDocumento TipoDocumento { get; set; }

    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty; // Ex: "Atendente", "Gerente", "Motorista"
    public decimal Salario { get; set; }
    public DateTime DataAdmissao { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;

    // Credenciais para o app desktop
    public string Login { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public TipoUser TipoUser { get; set; }
}
