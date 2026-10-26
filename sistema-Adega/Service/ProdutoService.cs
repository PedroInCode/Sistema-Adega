using Microsoft.EntityFrameworkCore;
using sistema_Adega.Banco;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sistema_Adega.Service;

public class ProdutoService
{
    private readonly AdegaDbContext _context;

    public ProdutoService(AdegaDbContext context)
    {
        this._context = context;
    }

    public void Insert(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public IEnumerable<Produto> ListarTodos()
    {
        return _context.Produtos
            .Include(p => p.Categoria) 
            .Include(p => p.MarcaProduto)
            .ToList();
    }

    public Produto? BuscarPorId(int id)
    {
        var produto = _context.Produtos
            .Include(p => p.Categoria)
            .Include(p => p.MarcaProduto)
            .FirstOrDefault(p => p.Id == id);

        if(produto == null) throw new KeyNotFoundException("O produto com o ID informado não foi encontrado!");

        return produto;
    }

    public void Atualizar(Produto produto)
    {
        _context.Produtos.Update(produto);
        _context.SaveChanges();    
    }

    public void Deletar(int id)
    {
        var produto = _context.Produtos.Find(id);

        if (produto == null) throw new KeyNotFoundException("O produto com o ID informado não foi encontrado!");

        _context.Produtos.Remove(produto);
        _context.SaveChanges();
    }
}
