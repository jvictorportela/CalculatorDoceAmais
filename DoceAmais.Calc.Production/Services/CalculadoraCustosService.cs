using DoceAmais.Calc.Production.Models;

namespace DoceAmais.Calc.Production.Services;

public class CalculadoraCustosService
{
    public CustoProducao CalcularCustoTotal(CustoProducao producao)
    {
        // Aqui, o CustoTotal é calculado automaticamente pela propriedade na classe CustoProducao.
        return producao;
    }
}