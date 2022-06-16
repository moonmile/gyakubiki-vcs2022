using Xunit;

namespace debug274;

public class UnitTest1  
{
    private int _a = 0;
    private int _b = 0;

    /// <summary>
    /// テスト前の初期化を行う
    /// </summary>
    public UnitTest1()
    {
        _a = 10;
        _b = 20;
    }


    [Fact]
    public void Test1()
    {
        var t = new Target();
        int ans = t.Add(_a, _b);
        Assert.Equal(30, ans);
    }
    [Fact]
    public void Test2()
    {
        var t = new Target();
        string ans = t.Add("マスダ", "トモアキ");
        Assert.Equal("マスダトモアキ", ans);
    }
    [Fact]
    public void Test3()
    {
        var t = Target.CreatePoint(-1, -1);
        Assert.Null(t);
        t = Target.CreatePoint(_a, _b);
        Assert.NotNull(t);
        Assert.Equal(10, t.X);
        Assert.Equal(20, t.Y);
    }
}

public class Target
{
    public int Add(int x, int y)
    {
        return x + y;
    }
    public string Add(string x, string y)
    {
        return x + y;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public static Target? CreatePoint(int x, int y)
    {
        if (x < 0 || y < 0) return null;
        return new Target { X = x, Y = y };
    }
}

