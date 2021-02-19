using CoreRCON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part06
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

            await command.GroundLeveling(x, y, z, x + 10, y + 10, z + 10);

            //任意のブロックを除外した整地
            List<string> Blocks = new List<string>
            {
                "minecraft:birch_log",
                "minecraft:oak_log",
                "minecraft:jungle_log",
                "minecraft:acacia_log",
                "minecraft:dark_oak_log"
            };

            await command.GroundLeveling(x, y, z, x + 10, y + 10, z + 10, Blocks);

            //await command.GroundLeveling(x, y, z, x + 10, y + 10, z + 50);
            //await command.GroundLeveling(x, y, z, x + 20, y + 30, z + 20, "minecraft:oak_log");

        }


    }
}
