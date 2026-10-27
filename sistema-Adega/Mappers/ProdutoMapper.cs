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
    // 1. Transforma o produto do banco num formato pronto para ser exibido na tela (DTO de Resposta)
    [MapProperty("Categoria.Nome", nameof(ProdutoResponseDto.CategoriaNome))]
    [MapProperty("MarcaProduto.Nome", nameof(ProdutoResponseDto.MarcaProdutoNome))]
    public partial ProdutoResponseDto MapearParaResponse(Produto produto);

    // 2. Transforma uma lista inteira de produtos do banco numa lista de respostas para a tela
    public partial IEnumerable<ProdutoResponseDto> MapearListaParaResponse(IEnumerable<Produto> produtos);

    // 3. Transforma os dados que vieram do formulário de cadastro num Produto pronto para ir para o banco
    public partial Produto MapearParaEntidade(ProdutoCreateDto dto);

    // 4. Atualiza os dados de um produto existente com as novas informações vindas da tela (Update)
    public partial void AtualizarProdutoComDto(ProdutoUpdateDto dto, Produto produto);
}
