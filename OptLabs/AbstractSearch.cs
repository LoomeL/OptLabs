namespace OptLabs;

public abstract class AbstractSearch
{
    public delegate double Func(double x);

    public abstract double Function(double x);

    public static double FunctionX(double x)
    {
        return x;
    }

    public static double FunctionNegativeX(double x)
    {
        return -x;
    }

    public abstract SearchResult Search(double a, double b, double epsilon, Func func);
}