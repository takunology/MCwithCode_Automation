using CoreRCON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Part05
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
            await command.SearchBlocks(x, y, z, x + 10, 0, z + 10, blockName);
             
            Console.WriteLine($"\n{blockName} : {command.BlockCount}");

            foreach(string item in command.BlockCoordinate)
            {
                Console.WriteLine(item);
            }

            OutFiles outfile = new OutFiles();
            outfile.OutOreCoordinate(command.BlockCoordinate);
        }

    }
}
