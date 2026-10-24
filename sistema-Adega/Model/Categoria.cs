using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Model;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    //Uma categoria possui vários produtos
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
