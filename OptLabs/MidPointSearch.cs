namespace OptLabs;

public class MidPointSearch : AbstractSearch
{
    public override double Function(double x)
    {
        return Math.Exp(-3 * x) + Math.Pow(x, 2);
    }

    private static double Derivative(Func func, double x)
    {
        return -3 * Math.Exp(-3 * x) + 2 * x;
    }

    public override SearchResult Search(double a, double b, double epsilon, Func func)
    {
        var x = (a + b) / 2.0;
        
        while (Math.Abs(Derivative(func, x)) > epsilon)
        {
            var df = Derivative(func, x);

            if (df > 0)
                b = x;
            else
                a = x;

            x = (a + b) / 2.0;
        }

        return new SearchResult
        {
            MinX = x,
            FunX = func.Invoke(x)
        };
    }
}