namespace OptLabs;

internal static class Program
{
    public static void Main(string[] args)
    {
        Lab3();
        //Lab4();
    }

    private static void Lab3()
    {
        var leftInterval = 2;
        double rightInterval = 4;
        var epsilon = 1e-5;
        var search = new BitwiseSearch();
        foreach (var function in new Dictionary<AbstractSearch.Func, string>()
                 {
                     { AbstractSearch.FunctionX, "x" },
                     { AbstractSearch.FunctionNegativeX, "-x" },
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
        foreach (var function in new Dictionary<AbstractSearch.Func, string>()
                 {
                     { AbstractSearch.FunctionX, "x" },
                     { AbstractSearch.FunctionNegativeX, "-x" },
                     { search.Function, "12 вариант" }
                 })
        {
            var result = search.Search(leftInterval, rightInterval, epsilon, function.Key);
            Console.WriteLine($"Функция: {function.Value}, Точка минимума: {result.MinX}, Значение: {result.FunX}");
        }
    }
}