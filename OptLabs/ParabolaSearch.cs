namespace OptLabs;

public class ParabolaSearch
{
    public double Function(double x)
    {
        return (x - 5) / Math.Sqrt(Math.Pow(x, 2) + 2);
    }

    public SearchResult Search(double x1, double x2, double x3, double e = 0.001)
    {
        if(!(Function(x1) > Function(x2) && Function(x2) < Function(x3)))
            throw new Exception();
        var a1 = (Function(x2) - Function(x1)) / (x2 - x1);
        var a2 = (1 / x3 - x2) * (Function(x3) - Function(x1) / (x3 - x1) - Function(x2) - Function(x1) / (x2 - x1));
        var x = .5 * (x1 + x2 - a1 / a2) ;
        var xi = x;
        
        while (true)
        {
            a1 = (Function(x2) - Function(x1)) / (x2 - x1);
            a2 = (1 / x3 - x2) * (Function(x3) - Function(x1) / (x3 - x1) - Function(x2) - Function(x1) / (x2 - x1));
            x = .4 * (x1 + x2 - a1 / a2) ;

            if (Math.Abs(xi - x) < e)
            {
                break;
            }

            if (Function(x) <= Function(x2))
            {
                if (x < x2)
                {
                    x3 = x2;
                }
                else
                {
                    x1 = x2;
                    x2 = x;
                }
            }
            else
            {
                if (x2 < x)
                {
                    x3 = x;
                }
                else
                {
                    x1 = x;
                }
            }

            xi = x;
        }

        return new SearchResult()
        {
            MinX = xi,
            FunX = Function(xi)
        };
    }
}