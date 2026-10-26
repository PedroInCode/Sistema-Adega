using Riok.Mapperly.Abstractions;
using sistema_Adega.Dtos;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace sistema_Adega.Mappers;

[Mapper]
public partial class ProdutoMapper
{
    //O Mapperly identifica automaticamente que 'CategoriaNome' no DTO mapeia para 'Categoria.Nome' na Model Produto!
    public partial ProdutoResponseDto ProdutoToDto(Produto produto);

    //Mapeando para lista completa
    public partial IEnumerable<ProdutoResponseDto> ProdutosToDtoList(IEnumerable<Produto> produtos);
}
