namespace DoceAmais.Calc.Production.Models;

public class CustoProducao
{
    public string NomeProducao { get; set; }
    public List<ItemCusto> ItensCusto { get; set; } = new List<ItemCusto>();
    public decimal CustoTotal => ItensCusto.Sum(item => item.Custo);
}