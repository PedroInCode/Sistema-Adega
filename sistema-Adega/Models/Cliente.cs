using sistema_Adega.Models.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Models;

public class Cliente 
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    //PROPRIEDADE DE NAVEGAÇÃO PARA ENDEREÇOS E COMPRAS
    public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
    public ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
