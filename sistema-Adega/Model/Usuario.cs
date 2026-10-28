using sistema_Adega.Models.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class Usuario
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty; // Hash BCrypt

    // Relacionamentos inversos opcionais
    public Cliente? Cliente { get; set; }
    public Funcionario? Funcionario { get; set; }
}
