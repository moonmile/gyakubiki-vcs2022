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
    byte type = 0x01;
    stream.WriteByte((byte)data.Length);
    stream.WriteByte(type);
    stream.Write(data);
    stream.Flush();
    Task.Delay(1000).Wait();
}
stream.Write(new byte[] { 0x00, 0x00, });
stream.Close();
Console.WriteLine("  Close");

