using Riok.Mapperly.Abstractions;
using sistema_Adega.Dtos.Produtos;
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
    // 1. Converte um único produto do banco para o DTO de resposta da tela
    [MapProperty("Categoria.Nome", nameof(ProdutoResponseDto.CategoriaNome))]
    [MapProperty("MarcaProduto.Nome", nameof(ProdutoResponseDto.MarcaProdutoNome))]
    public partial ProdutoResponseDto ConverterParaDto(Produto produto);

    // 2. Converte uma lista inteira de produtos para uma lista de DTOs de resposta
    public partial IEnumerable<ProdutoResponseDto> ConverterListaParaDto(IEnumerable<Produto> produtos);

    // 3. Converte os dados do formulário de cadastro (CreateDto) para a Entidade do banco
    public partial Produto ConverterParaEntidade(ProdutoCreateDto dto);

    // 4. Atualiza uma entidade existente com os novos dados vindos do UpdateDto
    public partial void AtualizarEntidade(ProdutoUpdateDto dto, Produto produto);
}
