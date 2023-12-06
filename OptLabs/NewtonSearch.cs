namespace OptLabs;

public class NewtonSearch
{
    private double Function(double x)
    {
        return Math.Exp(-3 * x) + Math.Pow(x, 2);
    }

    private static double Derivative(double x)
    {
        return -3 * Math.Exp(-3 * x) + 2 * x;
    }

    private static double SecondDerivative(double x)
    {
        return 9 * Math.Exp(-3 * x) + 2;
    }

    public SearchResult Search(double x, double epsilon)
    {
        while (Math.Abs(Derivative(x)) > epsilon) x -= Derivative(x) / SecondDerivative(x);

        return new SearchResult
        {
            MinX = x,
            FunX = Function(x)
        };
    }
}