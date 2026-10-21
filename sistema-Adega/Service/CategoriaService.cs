using Microsoft.EntityFrameworkCore.Metadata.Internal;
using sistema_Adega.Banco;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Service;

public class CategoriaService
{
    //Insert
    public void Insert(Categoria categoria)
    {
        using (var db = new AdegaDbContext())
        {
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }
    }

    //Listar Todos
    public List<Categoria> ListarTodos()
    {
        using(var db = new AdegaDbContext())
        {
            return db.Categorias.ToList();
        }
    }

    //Buscar por Id
    public Categoria? BuscarPorId(int id)
    {
        using(var db = new AdegaDbContext())
        {
            //O método .Find() do Entity Framework Core serve para buscar um único registo na base de dados através da sua Chave Primária(Primary Key / Id) de forma muito rápida e otimizada.
            return db.Categorias.Find(id);
        }
    }

    //Atualizar
    public void Atualizar(Categoria categoria)
    {
        using(var db = new AdegaDbContext())
        {
            db.Categorias.Update(categoria);
            db.SaveChanges();
        }
    }

    //Deletar
    public void Deletar(int id)
    {
        using(var db = new AdegaDbContext())
        {
            var categoria = db.Categorias.Find(id);
            if(categoria != null)
            {
                db.Categorias.Remove(categoria);
                db.SaveChanges();
            }
        }
    }
}
