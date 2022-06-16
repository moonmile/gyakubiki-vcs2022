// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;

Console.WriteLine("TCP/IP Client");

var client = new TcpClient();
client.Connect("localhost", 9000);
var stream = client.GetStream();

Console.WriteLine("Send Data");
byte[] data = new byte[4] { 1, 2, 3, 4 };
byte type = 0xFF;
stream.WriteByte((byte)data.Length);
stream.WriteByte(type);
stream.Write(data);
stream.Flush();
stream.Close();
Console.WriteLine("  Close");

