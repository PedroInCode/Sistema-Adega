using Microsoft.EntityFrameworkCore;
using sistema_Adega.Data;
using sistema_Adega.Model;
using sistema_Adega.Model.Enums.Tipo;
using sistema_Adega.Models.Enums.Tipo;
using sistema_Adega.Service;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== A INICIAR CICLO DE TESTES DA ADEGA ===");

        // Instancia o Contexto do Banco e o Serviço de Funcionários
        using var context = new AdegaDbContext();
        var funcionarioService = new FuncionarioService(context);

        // -------------------------------------------------------------
        // PASSO 1 & 2: Cadastrar o Funcionário e as Credenciais de Acesso
        // -------------------------------------------------------------
        Console.WriteLine("\n[PASSO 1 & 2] A cadastrar Funcionário e a associar o seu Usuário...");

        var novoFuncionario = new Funcionario
        {
            Nome = "Arthur Campos",
            Documento = "206.596.909-80",
            TipoDocumento = TipoDocumento.CPF,
            Telefone = "(11) 95678-6906",
            Email = "arthurcampos@adega.com",
            TipoCargo = TipoCargo.Gerente,
            Salario = 4500.00m,
            Ativo = true
        };

        string loginDesejado = "admin_arthur";
        string senhaTextoPuro = "123456"; // Palavra-passe que o funcionário vai usar para entrar

        try
        {
            // O serviço cria o registo em Usuarios com o hash BCrypt, gera o Id e vincula ao Funcionario
            funcionarioService.Inserir(novoFuncionario, loginDesejado, senhaTextoPuro);
            Console.WriteLine("-> Sucesso! Usuário criado, senha encriptada e funcionário cadastrado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"-> Erro ao cadastrar funcionário: {ex.Message}");
            return; // Interrompe o teste se falhar o cadastro
        }

        // -------------------------------------------------------------
        // PASSO 3: Testar o Ciclo de Autenticação (Login)
        // -------------------------------------------------------------
        Console.WriteLine("\n[PASSO 3] A testar o ciclo de Autenticação (Login)...");

        // Teste A: Tentativa com senha incorreta
        Console.WriteLine("\n   -> A testar login com senha ERRADA ('senha_errada')...");
        var tentativaFalha = funcionarioService.Autenticar(loginDesejado, "senha_errada");

        if (tentativaFalha == null)
        {
            Console.WriteLine("      [SUCESSO] O sistema rejeitou a senha incorreta corretamente.");
        }
        else
        {
            Console.WriteLine("      [ERRO] O sistema aceitou uma senha incorreta!");
        }

        // Teste B: Tentativa com senha correta
        Console.WriteLine("\n   -> A testar login com senha CORRETA ('123456')...");
        var funcionarioLogado = funcionarioService.Autenticar(loginDesejado, "123456");

        if (funcionarioLogado != null)
        {
            Console.WriteLine("      [SUCESSO] Login efetuado com sucesso!");
            Console.WriteLine($"      -> Nome: {funcionarioLogado.Nome}");
            Console.WriteLine($"      -> Cargo: {funcionarioLogado.TipoCargo}");
            Console.WriteLine($"      -> E-mail: {funcionarioLogado.Email}");
        }
        else
        {
            Console.WriteLine("      [ERRO] O sistema falhou ao autenticar com a senha correta.");
        }

        Console.WriteLine("\n=== CICLO DE TESTES CONCLUÍDO COM SUCESSO ===");
    }
}