using CoreRCON;
using System.Net;

namespace Part3
{
    /// <summary>
    /// サーバ接続用の設定
    /// </summary>
    public class Rcon
    {
        private static IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
        private static ushort port = 25575;
        private static string password = "minecraft";

        protected RCON rcon = new RCON(ipaddress, port, password);
    }
}
