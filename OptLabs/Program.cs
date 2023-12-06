namespace OptLabs;

internal static class Program
{
    public static void Main(string[] args)
    {
        // Lab3();
        // Lab4();
        // Lab5();
        //Lab6();
         Lab7();
    }

    private static void Lab3()
    {
        var leftInterval = 2;
        double rightInterval = 4;
        var epsilon = 1e-3;
        var search = new BitwiseSearch();
        foreach (var function in new Dictionary<BitwiseSearch.Func, string>
                 {
                     { search.FunctionX, "x" },
                     { search.FunctionNegativeX, "-x" },
                     { search.Function, "12 вариант" }
                 })
        {
            var result = search.Search(leftInterval, rightInterval, epsilon, function.Key);
            Console.WriteLine($"Функция: {function.Value}, Точка минимума: {result.MinX}, Значение: {result.FunX}");
        }
    }

    private static void Lab4()
    {
        var leftInterval = -1;
        double rightInterval = 1;
        var epsilon = 1e-3;
        var search = new MidPointSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon);
        Console.WriteLine($"Точка минимума: {result.MinX}, Значение: {result.FunX}");
    }

    private static void Lab5()
    {
        var x = -1;
        var epsilon = 1e-3;
        var search = new NewtonSearch();
        var result = search.Search(x, epsilon);
        Console.WriteLine($"Точка минимума: {result.MinX}, Значение: {result.FunX}");
    }

    private static void Lab6()
    {
        var leftInterval = 9;
        double rightInterval = 11;
        var epsilon = 0.005;
        var search = new MultimodalFunctionSearch();
        var constant = search.BruteforceMethod(leftInterval, rightInterval);
        var uniform = search.UniformSampling(leftInterval, rightInterval, epsilon);
        var lipShitzMethod = search.LipshitzMethod(leftInterval, rightInterval, epsilon);
        Console.WriteLine($"Константа: {constant}");
        Console.WriteLine($"Минимум функции перебором: {uniform.FunX}");
        Console.WriteLine($"Минимум функции: {lipShitzMethod.FunX}");
    }

    private static void Lab7()
    {
        var epsilon = 1e-3;
        var search = new ParabolaSearch();
        var result = search.Search(-1, -.1, 1, epsilon);
        Console.WriteLine($"Точка минимума: {result.MinX}, Значение: {result.FunX}");
    }
}