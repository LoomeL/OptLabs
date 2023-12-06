namespace OptLabs;

public class BitwiseSearch
{
    public delegate double Func(double x);

    public double Function(double x)
    {
        return Math.Sqrt(x * x + 1) / (5 * x + 2);
    }

    public double FunctionX(double x)
    {
        return x;
    }

    public double FunctionNegativeX(double x)
    {
        return -x;
    }

    public SearchResult Search(double a, double b, double epsilon, Func func)
    {
        var d = (b - a) / 2;
        var x0 = a;
        var fx0 = func.Invoke(x0);

        while (Math.Abs(d) > epsilon / 10)
        {
            var x1 = x0 + d;
            var fx1 = func.Invoke(x1);
            if (fx0 > fx1)
            {
                if (d > 0)
                {
                    if (Math.Abs(b - x0) < epsilon) break;
                }
                else
                {
                    if (Math.Abs(a - x0) < epsilon) break;
                }

                x0 = x1;
                fx0 = fx1;
            }
            else
            {
                x0 = x1;
                fx0 = fx1;
                d = -d / 4;
            }
        }


        return new SearchResult
        {
            MinX = x0,
            FunX = fx0
        };
    }
}