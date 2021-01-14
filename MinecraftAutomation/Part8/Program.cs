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

            //除外するブロックリスト
            List<string> blockList = new List<string>
            {
                "minecraft:cave_air",
                "minecraft:air",
                "minecraft:water",
                "minecraft:lava"
            };
            //一旦整地してから湧きつぶす(必要な場合)
            await command.GroundLeveling(x, y, z, x + 100, y + 1, z + 100);
            await command.SetTorch(x, z, x + 100, z + 100, blockList);
        }
    }
}
