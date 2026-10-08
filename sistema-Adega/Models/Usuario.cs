using sistema_Adega.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Models;

internal abstract class Usuario
{
    public string? _nome { get; protected set; }
    public TipoDocumento? _tipoDocumento { get; protected set; }
    public string? _documento { get; protected set; }
    public bool _ativo { get; protected set; }
    public DateTime? _dataCadastro { get; protected set; }
    public DateTime _dataNascimento { get; protected set; }

    public TipoUser _tipoUser { get; protected set; }

    public Usuario(string? nome, TipoDocumento? tipoDocumento, string? documento, bool ativo, DateTime? dataCadastro, DateTime dataNascimento, TipoUser tipoUser)
    {
        _nome = nome;
        _tipoDocumento = tipoDocumento;
        _documento = documento;
        _ativo = ativo;
        _dataCadastro = dataCadastro;
        _dataNascimento = dataNascimento;
        _tipoUser = tipoUser;
    }

    public bool MaiorDeIdade()
    {
        DateTime dataAtual = DateTime.Now;
        int idade = dataAtual.Year - _dataNascimento.Year;
        if (dataAtual < _dataNascimento.AddYears(idade))
        {
            idade--;
        }
        return idade >= 18;
    }
}
