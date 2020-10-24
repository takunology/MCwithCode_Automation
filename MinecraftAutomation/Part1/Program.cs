using CoreRCON;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Part1
{
    class Program
    {
        // サーバのIPアドレス、RCONのポート番号、パスワードの3つが必要です。
        static IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
        static ushort port = 25575;
        static string password = "minecraft";
        // 上記3つの情報をもとに RCON インスタンスを作成します。
        static RCON rcon = new RCON(ipaddress, port, password);

        // RCON自体が非同期なので async Task を付けます（非同期なタスクとして与えます）
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start!");
            
            // await を設定し、Task の完了を待機します。
            await rcon.ConnectAsync();
            
            // 天候は weather コマンドを使用します。
            var weather_result = await rcon.SendCommandAsync("/weather rain");
            Console.WriteLine(weather_result);
            // 時間は time コマンドを使用します。
            var timeset_result = await rcon.SendCommandAsync("/time set night");
            Console.WriteLine(timeset_result);
        }
    }
}
