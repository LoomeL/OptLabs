namespace OptLabs;

public class MidPointSearch
{
    public double Function(double x)
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

    public SearchResult Search(double a, double b, double epsilon)
    {
        var x = (a + b) / 2.0;
        var aX = a;
        var bX = b;
        while (Math.Abs(Derivative(x)) > epsilon)
        {
            var df = Derivative(x);

            if (df > 0)
            {
                bX = x;
                if (Math.Abs(a - x) < epsilon) break;
            }
            else
            {
                aX = x;
                if (Math.Abs(b - x) < epsilon) break;
            }

            x = (aX + bX) / 2.0;
        }

        return new SearchResult
        {
            MinX = x,
            FunX = Function(x)
        };
    }
}