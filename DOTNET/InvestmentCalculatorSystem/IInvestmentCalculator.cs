namespace InvestmentCalculatorSystem
{
    interface IInvestmentCalculator
    {
        double CalculateReturn(double principal, double rate, double years);
    }
}