using CoreRCON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Part5
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

            string blockName = "minecraft:diamond_ore";
            await command.SearchBlocks(x, y-30, z, x + 100, 0, z + 100, blockName);
            //Console.WriteLine($"\n{blockName} : {command.BlockCount}");

            OutFiles outfile = new OutFiles();
            outfile.OutOreCoordinate(command.BlockCoordinate);
        }

    }
}
