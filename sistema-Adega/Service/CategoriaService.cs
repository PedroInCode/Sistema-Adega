using Microsoft.EntityFrameworkCore;
using sistema_Adega.Banco;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sistema_Adega.Service;

public class CategoriaService
{

    private readonly AdegaDbContext _context;

    public CategoriaService(AdegaDbContext context)
    {
        this._context = context;
    }


    //Insert
    public void Insert(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
    }

    //Listar Todos
    public IEnumerable<Categoria> ListarTodos()
    {
        return _context.Categorias.ToList();
    }

    //Buscar por Id
    public Categoria? BuscarPorId(int id)
    {
        var categoria = _context.Categorias.Find(id);

        if (categoria == null) throw new KeyNotFoundException("A Categoria com o ID informado não foi encontrada no sistema!");

        return categoria;
    }

    //Atualizar
    public void Atualizar(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        _context.SaveChanges();
    }

    //Deletar
    public void Deletar(int id)
    {
        var categoria = _context.Categorias.Find(id);

        if (categoria == null) throw new KeyNotFoundException("A Categoria com o ID informado não foi encontrada no sistema!");

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
    }
}
