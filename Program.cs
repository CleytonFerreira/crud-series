using System.Data.SqlClient;


string connString = @"Data Source=<digite o servidor aqui>; Initial Catalog=SERIES; Integrated Security=True";
SqlConnection conexao = new SqlConnection(connString);
conexao.Open();

try
{
    System.Console.WriteLine("Conexão realizada com sucesso\n");
    string? resposta;

    do
    {
        System.Console.WriteLine("Escolha uma das opções abaixo: \n1.Cadastrar nova série \n2.Listar séries \n3.Atualizar dados de série \n4.Excluir série");
        int op = Convert.ToInt32(Console.ReadLine());
        switch (op)
        {
            case 1:
                System.Console.WriteLine("Digite o nome da série: ");
                string? nome = Console.ReadLine();
                System.Console.WriteLine("Digite o gênero da série: ");
                string? genero = Console.ReadLine();
                System.Console.WriteLine("Digite a sinopse da série: ");
                string? sinopse = Console.ReadLine();
                System.Console.WriteLine("Digite o ano de estréia da série: ");
                int ano = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Digite quantas temporadas a série possui: ");
                int temporadas = Convert.ToInt32(Console.ReadLine());
                string consultaCriar = $"INSERT INTO SERIE (NOME, GENERO, SINOPSE, ANO, TEMPORADAS) VALUES ('{nome}', '{genero}', '{sinopse}', {ano}, {temporadas} )";
                SqlCommand comandoCriar = new SqlCommand(consultaCriar, conexao);
                comandoCriar.ExecuteNonQuery();
                System.Console.WriteLine("Dados inseridos com êxito.");
                break;

            case 2:
                string consultaListar = "SELECT * FROM SERIE";
                SqlCommand comandoListar = new SqlCommand(consultaListar, conexao);
                SqlDataReader dataReader = comandoListar.ExecuteReader();
                while (dataReader.Read())
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine($"ID: {dataReader.GetValue(0).ToString()}");
                    System.Console.WriteLine($"NOME: {dataReader.GetValue(1).ToString()}");
                    System.Console.WriteLine($"GENERO: {dataReader.GetValue(2).ToString()}");
                    System.Console.WriteLine($"SINOPSE: {dataReader.GetValue(3).ToString()}");
                    System.Console.WriteLine($"ANO: {dataReader.GetValue(4).ToString()}");
                    System.Console.WriteLine($"TEMPORADAS: {dataReader.GetValue(5).ToString()}");
                    System.Console.WriteLine();
                }
                dataReader.Close();
                break;

            case 3:
                int idSerie;
                string? novoNome;
                string? novoGenero;
                string? novaSinopse;
                int novoAno;
                int novasTemporadas;

                System.Console.WriteLine("Informe o id da série que você quer atualizar: ");
                idSerie = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Digite o nome da série:  ");
                novoNome = Console.ReadLine();
                System.Console.WriteLine("Digite o gênero da série: ");
                novoGenero = Console.ReadLine();
                System.Console.WriteLine("Digite a sinopse da série: ");
                novaSinopse = Console.ReadLine();
                System.Console.WriteLine("Digite o ano de estréia da série: ");
                novoAno = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Digite quantas temporadas a série possui: ");
                novasTemporadas = Convert.ToInt32(Console.ReadLine());

                string consultaAtualizar = $"UPDATE SERIE SET NOME = '{novoNome}', GENERO = '{novoGenero}', SINOPSE = '{novaSinopse}', ANO = {novoAno}, TEMPORADAS = {novasTemporadas } WHERE ID_SERIE = {idSerie}";
                SqlCommand comandoAtualizar = new SqlCommand(consultaAtualizar, conexao);
                comandoAtualizar.ExecuteNonQuery();
                System.Console.WriteLine("Dados atualizados com êxito.");
                break;

            case 4:
                int idExclusao;
                System.Console.WriteLine("Informe o id da série que você quer excluir: ");
                idExclusao = Convert.ToInt32(Console.ReadLine());
                string consultaExclusao = $"DELETE FROM SERIE WHERE ID_SERIE = {idExclusao}";
                SqlCommand comandoExclusao = new SqlCommand(consultaExclusao, conexao);
                comandoExclusao.ExecuteNonQuery();
                System.Console.WriteLine("Dados excluídos com êxito");
                break;

            default:
                System.Console.WriteLine("Opção inválida");
                break;
        }

        System.Console.WriteLine("\nDeseja realizar outra operação? \nPressione qualquer tecla para continuar, 0 para sair");
        resposta = Console.ReadLine();

    } while (resposta != "0");
}
catch (Exception e)
{
    System.Console.WriteLine(e.Message);
}
finally
{
    conexao.Close();
    System.Console.WriteLine("Obrigado por utilizar nossos serviços :)");
}