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

            //除外するブロックリスト（ブロックだけに...w）
            List<string> blockList = new List<string>
            {
                "minecraft:water",
                "minecraft:lava",
            };

            //一旦整地してから湧きつぶす
            await command.GroundLeveling(x, y, z, x + 50, y + 20, z + 50);
            await command.SetTorch(x, z, x + 50, z + 50, blockList);
        }
    }
}
