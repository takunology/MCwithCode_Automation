using CoreRCON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //コマンド用インスタンス
            Commands command = new Commands();
            await command.GetPosition("Takunology");

            int x = (int)command.PlayerPosX + 1;
            int y = (int)command.PlayerPosY;
            int z = (int)command.PlayerPosZ;

            await command.GroundLeveling(x, y, z, x + 100, y + 2, z + 100);

            //await command.SetTorch(x, z, x + 100, z + 100);
        }
    }
}
