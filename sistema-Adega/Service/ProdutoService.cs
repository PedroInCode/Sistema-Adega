using Microsoft.EntityFrameworkCore;
using sistema_Adega.Banco;
using sistema_Adega.Dtos;
using sistema_Adega.Mappers;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sistema_Adega.Service;

public class ProdutoService
{
    private readonly AdegaDbContext _context;
    private readonly ProdutoMapper _mapper;

    public ProdutoService(AdegaDbContext context)
    {
        this._context = context; //Credencial para entrar no banco de dados
        this._mapper = new ProdutoMapper(); //Instancia o mapper gerado automaticamente pelo Mapperly
    }

    public void Adicionar(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public IEnumerable<ProdutoResponseDto> ListarTodos()
    {
        //Busca os produtos no MySQL com máxima performance.
        var produtos = _context.Produtos
            .AsNoTracking() //Desliga o rastreamento do EF Core, poupando memória e acelarando a consulta de leitura.
            .Include(p => p.Categoria) //Include Garante que o EF Core traz os dados da Categoria ligadas ao produto.
            .Include(p => p.MarcaProduto)
            .ToList();

        //Converte instantaneamente a lista de Models para lista de DTOs
        return _mapper.ProdutosToDtoList(produtos); //Usa o código compilado pelo Mapperly para preencher o ProdutoResponseDto (incluindo CategoriaNome e o MarcaProdutoNome) a uma velocidade bem melhor que o AutoMapper.
    }

    public ProdutoResponseDto? BuscarPorId(int id)
    {
        var produto = _context.Produtos
            .AsNoTracking() //Boa prática também nas buscas individuais por ID de leitura!
            .Include(p => p.Categoria)
            .Include(p => p.MarcaProduto)
            .FirstOrDefault(p => p.Id == id);

        if(produto == null) throw new KeyNotFoundException("O produto com o ID informado não foi encontrado!");

        //Converte a Model para o DTO usando o Mapperly
        return _mapper.ProdutoToDto(produto);
    }

    public void Atualizar(Produto produto)
    {
        _context.Produtos.Update(produto);
        _context.SaveChanges(); //Salva as atualizações no banco    
    }

    public void Deletar(int id)
    {
        var produto = _context.Produtos.Find(id); //Busca rapida na tabela de Produtos atraves do ID

        if (produto == null) throw new KeyNotFoundException("O produto com o ID informado não foi encontrado!");

        _context.Produtos.Remove(produto); //Remove o produto da tabela
        _context.SaveChanges();
    }
}
