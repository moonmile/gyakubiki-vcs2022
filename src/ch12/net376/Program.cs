// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;

Console.WriteLine("TCP/IP Client");

var client = new TcpClient();
client.Connect("localhost", 9000);
var stream = client.GetStream();

// 10回送信する
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Send Data {i}");
    byte[] data = System.Text.Encoding.ASCII.GetBytes("Hello");
    byte type = 0x02;
    stream.WriteByte((byte)data.Length);
    stream.WriteByte(type);
    stream.Write(data);
    stream.Flush();
    // サーバーからのデータを受信する

    // 受信データの読み出し
    // 1バイト目 : 長さ
    // 2バイト目 : タイプ
    // 3バイト以降: データ
    int length2 = stream.ReadByte();
    int type2 = stream.ReadByte();
    byte[] data2 = new byte[length2];
    stream.Read(data2, 0, length2);
    Console.WriteLine("Receive Data");
    Console.WriteLine($"  Length: {length2}");
    Console.WriteLine($"  Type: {type2}");
    Console.WriteLine("  Data: " + BitConverter.ToString(data2));

    Task.Delay(1000).Wait();
}
// クローズ用のコマンドを送信
stream.Write(new byte[] { 0x00, 0x00, });
// クローズ
stream.Close();
Console.WriteLine("  Close");

