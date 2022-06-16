using Xunit;

namespace debug268;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var t = new Target();
        int ans = t.Add(10, 20);
        Assert.Equal(30, ans);
    }
}

public class Target
{
    public int Add( int x, int y )
    {
        return x + y;
    }
}
