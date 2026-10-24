
using Microsoft.EntityFrameworkCore;
using sistema_Adega.Banco;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sistema_Adega.Service;

public class ClienteService
{
    private readonly AdegaDbContext _context;

    public ClienteService(AdegaDbContext context)
    {
        this._context = context;
    }

    public void Insert(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }

    public List<Cliente> ListarTodos()
    {
        return _context.Clientes.ToList();
    }

    public Cliente? BuscarPorID(int id)
    {
        var cliente = _context.Clientes.Find(id);

        if(cliente == null)
        {
            throw new Exception("O cliente com o ID informado não foi encontrado!");
        }

        return cliente;
    }

    public Cliente? BuscarPorIdComRelacionamento(int id)
    {
        var cliente = _context.Clientes
            .Include(c => c.Enderecos)
            .Include(c => c.Compras)
            .FirstOrDefault(c => c.Id == id);

        if (cliente == null) throw new KeyNotFoundException("O cliente não  foi encontrado no sistema!");

        return cliente;
    }

    public void Atualizar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
    }

    public void Deletar(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return;
        }

        throw new KeyNotFoundException("O cliente não foi encontrado no sistema!");
    }
}
