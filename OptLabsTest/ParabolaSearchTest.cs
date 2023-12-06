namespace OptLabsTest;

public class ParabolaSearchTest
{
    [Fact(DisplayName = "Поиск методом параболы")]
    public void Test1()
    {
        var epsilon = 1e-3;
        var search = new ParabolaSearch();
        var result = search.Search(-1, -.11, 1,epsilon);
        Assert.Equal(-3.673, result.FunX, epsilon);
    }
}