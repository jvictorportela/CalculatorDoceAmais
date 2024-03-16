using System.Globalization;
using System.Text;
using DoceAmais.Calc.Production.Models;

namespace DoceAmais.Calc.Production.Repositories;

public class CsvGenerate
{
    public string GerarArquivoCSV(CustoProducao producao)
    {
        StringBuilder csvContent = new StringBuilder();
        csvContent.AppendLine("NomeProducao,NomeItem,Quantidade,CustoUnitario,CustoTotalDeItem,CustoProducao");

        decimal custoProducaoTotal = producao.ItensCusto.Sum(item => item.CustoTotalItem);

        foreach (var item in producao.ItensCusto)
        {
            csvContent.AppendLine($"{producao.NomeProducao},{item.Nome},{item.Quantidade}, " +
                                  $" R${item.Custo.ToString("F2", CultureInfo.InvariantCulture)}, " +
                                  $" R${item.CustoTotalItem.ToString("F2", CultureInfo.InvariantCulture)}," +
                                  $"{(producao.ItensCusto.IndexOf(item) == 0 ? $"R${custoProducaoTotal.ToString("F2", CultureInfo.InvariantCulture)}" : "")}");
        }

        string filePath = Path.Combine(Environment.CurrentDirectory, $"{producao.NomeProducao.Replace(" ", "_")}_CustoProducao.csv");
        File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);

        return filePath;
    }
}