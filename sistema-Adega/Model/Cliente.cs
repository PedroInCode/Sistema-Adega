using sistema_Adega.Models.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class Cliente 
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public TipoDocumento TipoDocumento { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Chave Estrangeira para Usuario (Pode ser nulo se nem todo cliente tiver conta de login)
    public int? UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }

    // Propriedades de navegação
    public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
    public ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
