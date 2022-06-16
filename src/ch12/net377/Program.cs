
// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Threading.Tasks;

Console.WriteLine("TCP/IP server");
// TCP/IPのサーバーを起動する
var server = new TcpListener(System.Net.IPAddress.Loopback, 9000);
server.Start();
Console.WriteLine("Listen...");
while ( true )
{
    // クライアントからの受信を受け付ける
    var client = server.AcceptTcpClient();
    var stream = client.GetStream();
    Task.Factory.StartNew(() => { 
        while( stream.Socket.Connected )
        {
            // 受信データの読み出し
            // 1バイト目 : 長さ
            // 2バイト目 : タイプ
            // 3バイト以降: データ
            int length = stream.ReadByte();
            int type = stream.ReadByte();
            byte[] data = new byte[length];
            stream.Read(data, 0, length);
            Console.WriteLine("Receive Data");
            Console.WriteLine($"  Length: {length}");
            Console.WriteLine($"  Type: {type}");
            Console.WriteLine("  Data: " + BitConverter.ToString(data));
            if ( type == 0x02 )
            {
                // クライアントにデータを返す
                byte[] data2 = System.Text.Encoding.ASCII.GetBytes("HELLO");
                byte type2 = 0x02;
                stream.WriteByte((byte)data2.Length);
                stream.WriteByte(type2);
                stream.Write(data);
                stream.Flush();
            }
            if ( type == 0x00 )
            {
                // クローズ処理
                break;
            }
        }
        Console.WriteLine(" Close");
        stream.Close();
    });

}
