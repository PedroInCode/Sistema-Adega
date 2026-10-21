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
    public string Documento { get; set; } = string.Empty; // Número do CPF ou CNPJ

    // Utilizando o Enum para saber se o documento é CPF ou CNPJ
    public TipoDocumento TipoDocumento { get; set; }

    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Propriedades de navegação
    public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
    public ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
