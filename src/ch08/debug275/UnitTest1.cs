using System;
using Xunit;

namespace debug275;

public class UnitTest1 : IDisposable
{
    const string _path = "test.txt";

    /// <summary>
    /// テスト前の初期化を行う
    /// </summary>
    public UnitTest1()
    {
        System.IO.File.WriteAllText(_path, "10,20");
    }

    /// <summary>
    /// 後処理を行う
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void Dispose()
    {
        System.IO.File.Delete(_path);
    }

    /// <summary>
    /// 入力をファイルから読み込む
    /// </summary>
    [Fact]
    public void Test1()
    {
        var text = System.IO.File.ReadAllText(_path);
        var lst = text.Split(",");
        int a = int.Parse( lst[0] );
        int b = int.Parse(lst[1]);
        var t = new Target();
        int ans = t.Add(a, b);
        Assert.Equal(30, ans);
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

