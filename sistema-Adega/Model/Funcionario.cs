using sistema_Adega.Model.Enums.Tipo;
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
    public string Documento { get; set; } = string.Empty;
    public TipoDocumento TipoDocumento { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Credenciais de Acesso (para o login com BCrypt)
    public string Login { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;

    // Dados Profissionais
    public TipoCargo TipoCargo { get; set; }
    public decimal Salario { get; set; }
    public DateTime DataAdmissao { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;

    // Chave Estrangeira para Usuario (Obrigatório para funcionários, pois precisam de login)
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;

    // Relacionamentos
    public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
}
