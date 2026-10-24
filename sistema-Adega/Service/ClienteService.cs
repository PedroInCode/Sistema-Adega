using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using sistema_Adega.Banco;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Service;

public class ClienteService
{
    public void Insert(Cliente cliente)
    {
        using(var db = new AdegaDbContext())
        {
            db.Clientes.Add(cliente); 
            db.SaveChanges();
        }
    }

    public List<Cliente> ListarTodos()
    {
        using(var db = new AdegaDbContext())
        {
            return db.Clientes.ToList();
        }
    }

    public Cliente? BuscarPorID(int id)
    {
        using(var db = new AdegaDbContext())
        {
            return db.Clientes.Find(id);
        }
    }

    public Cliente? BuscarPorIdComRelacionamento(int id)
    {
        using(var db = new AdegaDbContext())
        {
            return db.Clientes
                .Include(c => c.Enderecos)
                .Include(c => c.Compras)
                .FirstOrDefault(c => c.Id == id);
        }
    }

    public void Atualizar(Cliente cliente)
    {
        using(var db = new AdegaDbContext())
        {
            db.Clientes.Update(cliente);
            db.SaveChanges();
        }
    }
    
    public void Deletar(int id)
    {
        using(var db = new AdegaDbContext())
        {
            var cliente = db.Clientes.Find(id);
            if(cliente != null)
            {
                db.Clientes.Remove(cliente);
                db.SaveChanges();
            }
        }
    }
}
