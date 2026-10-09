using sistema_Adega.Enums.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Models;

internal class Cliente : Usuario
{
    public int _pontosFidelidade { get; protected set; }

    public Cliente(int pontosFidelidade, string? nome, TipoDocumento? tipoDocumento, string? documento, bool ativo, DateTime? dataCadastro, DateTime dataNascimento, TipoUser tipoUser) : base(nome, tipoDocumento, documento, ativo, dataCadastro, dataNascimento, tipoUser)
    {
        this._pontosFidelidade = pontosFidelidade;
    }

    
    public void ConsultarPontos()
    {
        Console.WriteLine($"Total de pontos: {this._pontosFidelidade}");
    }

    
}
