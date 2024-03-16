namespace DoceAmais.Calc.Production.Models;

public class ItemCusto
{
    public string Nome { get; set; }
    public decimal Custo { get; set; } // valor unitário 
    public int Quantidade { get; set; }
    public decimal CustoTotalItem => Custo * Quantidade;
}