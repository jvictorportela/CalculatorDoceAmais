using DoceAmais.Calc.Production.Models;
using DoceAmais.Calc.Production.Repositories;
using DoceAmais.Calc.Production.Services;

class Program
{
    static void Main(string[] args)
    {
        var calculadoraService = new CalculadoraCustosService();
        var outlook = new EmailModel("smtp.office365.com", "jvictorportela30@outlook.com",
            "senhadoEmail");

        Console.WriteLine("Bem-vindo à Calculadora de Custo de Produção de Doces");

        var producao = new CustoProducao();

        Console.Write("Informe o nome da produção: ");
        producao.NomeProducao = Console.ReadLine();

        bool adicionarMaisCustos = true;
        while (adicionarMaisCustos)
        {
            var itemCusto = new ItemCusto();

            Console.Write("Informe o nome do custo (ex: Leite Condensado, Embalagens, Gás de cozinha): ");
            itemCusto.Nome = Console.ReadLine();

            Console.Write($"Informe o custo unitário de {itemCusto.Nome}: R$");
            itemCusto.Custo = Convert.ToDecimal(Console.ReadLine());

            Console.Write($"Informe a quantidade de {itemCusto.Nome}: ");
            itemCusto.Quantidade = Convert.ToInt32(Console.ReadLine());

            producao.ItensCusto.Add(itemCusto);

            Console.Write("Deseja adicionar mais custos? (S/N): ");
            adicionarMaisCustos = Console.ReadLine().Trim().ToUpper() == "S";
        }

        var producaoCalculada = calculadoraService.CalcularCustoTotal(producao);
        CsvGenerate csv = new CsvGenerate();
        string filePath = csv.GerarArquivoCSV(producaoCalculada);
        Console.WriteLine($"Arquivo gerado com sucesso!");
        
        outlook.SendEmail(
            emailsTo: new List<string>
            {
                "contatodoceamais@gmail.com",
                "devjvictorportela@gmail.com",
            },
            subject: producao.NomeProducao,
            body: "Segue em anexo o relat´roio de custo da produção",
            attachments: new List<string> {filePath}
            );

        Console.WriteLine("Relatório enviado com sucesso!");
    }
}
