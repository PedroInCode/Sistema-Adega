using Microsoft.EntityFrameworkCore;
using sistema_Adega.Data;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Service;

public class FuncionarioService
{
    private readonly AdegaDbContext _context;

    public FuncionarioService(AdegaDbContext context)
    {
        _context = context;
    }

    // 1. Inserir funcionário já gerando o Hash da senha com BCrypt
    public void Inserir(Funcionario funcionario, string loginDigitado, string senhaTextoLimpo)
    {
        if (string.IsNullOrWhiteSpace(loginDigitado))
            throw new Exception("O login não pode ser vazio.");
        if (string.IsNullOrWhiteSpace(senhaTextoLimpo))
            throw new Exception("A senha não pode ser vazia.");

        // 1. Cria o registo de Acesso na tabela Usuarios com a senha em Hash (BCrypt)
        var novoUsuario = new Usuario
        {
            Login = loginDigitado,
            Senha = BCrypt.Net.BCrypt.HashPassword(senhaTextoLimpo)
        };

        _context.Usuarios.Add(novoUsuario);
        _context.SaveChanges(); 

        // 2. Associa o Id gerado do usuário ao Funcionário
        funcionario.UsuarioId = novoUsuario.Id;

        // 3. Salva o Funcionário na  tabela 
        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();
    }

    public Funcionario? Autenticar(string loginDigitado, string senhaTextoLimpo)
    {
        if (string.IsNullOrWhiteSpace(loginDigitado) || string.IsNullOrWhiteSpace(senhaTextoLimpo))
            return null;

        // Procura o usuário pelo login
        var usuario = _context.Usuarios
            .Include(u => u.Funcionario) // Traz o funcionário associado (se existir)
            .FirstOrDefault(u => u.Login == loginDigitado);

        if (usuario == null || usuario.Funcionario == null || !usuario.Funcionario.Ativo)
        {
            return null;
        }

        // Valida a senha usando o Hash guardado na tabela Usuarios
        bool senhaValida = BCrypt.Net.BCrypt.Verify(senhaTextoLimpo, usuario.Senha);

        if (senhaValida)
        {
            return usuario.Funcionario; // Retorna o funcionário logado!
        }

        return null;
    }
}

