using Xunit;

namespace debug269;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var t = new Target();
        int ans = t.Add(10, 20);
        Assert.Equal(30, ans);
    }
    [Fact]
    public void Test2()
    {
        var t = new Target();
        string ans = t.Add("マスダ", "トモアキ");
        Assert.Equal("マスダトモアキ", ans);
    }
}

public class Target
{
    public int Add(int x, int y)
    {
        return x + y;
    }
    public string Add( string x, string y )
    {
        return x + y;
    }
}
