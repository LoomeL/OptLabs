namespace OptLabs;

public class MidPointSearch : AbstractSearch
{
    public override double Function(double x)
    {
        return Math.Exp(-3 * x) + x * x;
    }

    private static double Derivative(Func func, double x)
    {
        var h = 1e-5;
        return (func.Invoke(x + h) - func.Invoke(x - h)) / (2 * h);
    }

    public override SearchResult Search(double a, double b, double epsilon, Func func)
    {
        var x = (a + b) / 2.0;

        while (Math.Abs(b - a) > epsilon)
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