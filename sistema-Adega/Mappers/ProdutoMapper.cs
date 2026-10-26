using Riok.Mapperly.Abstractions;
using sistema_Adega.Dtos;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace sistema_Adega.Mappers;

//RequiredMappingStrategy = RequiredMappingStrategy.None : O Mapperly deixa de reclamar se houver propriedades na Model que não estão presentes no DTO (e vice-versa), focando-se apenas em mapear as que têm o mesmo nome.
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)] 
public partial class ProdutoMapper
{
    // Ensinamos o Mapperly a ligar os campos com nomes diferentes ou aninhados:
    [MapProperty("Categoria.Nome", nameof(ProdutoResponseDto.CategoriaNome))]
    [MapProperty("MarcaProduto.Nome", nameof(ProdutoResponseDto.MarcaProdutoNome))]

    //O Mapperly identifica automaticamente que 'CategoriaNome' no DTO mapeia para 'Categoria.Nome' na Model Produto!
    public partial ProdutoResponseDto ProdutoToDto(Produto produto);

    //Mapeando para lista completa
    public partial IEnumerable<ProdutoResponseDto> ProdutosToDtoList(IEnumerable<Produto> produtos);
}
