namespace OptLabs;

public class MultimodalFunctionSearch
{
    private double Function(double x)
    {
        return -Math.Sqrt(20 * x - Math.Pow(x, 2)) + 0.01 * Math.Sin(x);
    }

    private double Derivative(double x)
    {
        return (x - 10) / Math.Sqrt(-(x - 20) * x) + 0.01 * Math.Cos(x);
    }

    public double BruteforceMethod(double a, double b, double step = 1e-6)
    {
        var max = double.MinValue;
        var x = a;

        while (x <= b)
        {
            var value = Math.Abs(Derivative(x));

            if (value > max) max = value;

            x += step;
        }

        return max;
    }

    public SearchResult UniformSampling(double a, double b, double epsilon)
    {
        var min = double.MaxValue;
        var L = BruteforceMethod(a, b);

        var step = 2 * epsilon / L;

        var x = a + step / 2.0;

        while (x <= b)
        {
            var value = Function(x);

            if (value < min) min = value;

            x += step;
        }

        return new SearchResult
        {
            MinX = x - step,
            FunX = min
        };
    }

    public SearchResult LipshitzMethod(double a, double b, double epsilon)
    {
        List<(double x, double p)> pairs = new();
        var L = BruteforceMethod(a, b);
        var x = 1 / (2 * L) * (Function(a) - Function(b) + L * (a + b));
        var y = 0.5 * (Function(a) + Function(b) + L * (a - b));

        var p = y;

        var delta = 1 / (2 * L) * (Function(x) - p);
        var x1 = x - delta;
        var x2 = x + delta;
        pairs.Add((x1, 0.5 * (Function(x) + p)));
        pairs.Add((x2, 0.5 * (Function(x) + p)));


        while (true)
        {
            foreach (var tuple in pairs)
            {
                delta = 1 / (2 * L) * (Function(tuple.x) - tuple.p);
                var deltaK = 2 * L * delta;

                if (deltaK < epsilon)
                {
                    foreach (var pdd in pairs) Console.WriteLine(pdd.x + " " + pdd.p);
                    Console.WriteLine($"Точка минимума: {tuple.x}, Значение: { Function(tuple.x) }");
                    return new SearchResult
                    {
                        MinX = pairs.MinBy(valueTuple => Function(valueTuple.x)).x,
                        FunX = Function(pairs.MinBy(valueTuple => Function(valueTuple.x)).x)
                    };
                }
            }

            var pair = pairs.MinBy(valueTuple => valueTuple.p);
            pairs = pairs.Where(valueTuple => valueTuple != pair).ToList();

            x1 = pair.x - delta;
            x2 = pair.x + delta;
            p = 0.5 * (Function(pair.x) + pair.p);

            pairs.Add((x1, p));
            pairs.Add((x2, p));
        }
    }
}