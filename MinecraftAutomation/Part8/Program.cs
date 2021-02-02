using CoreRCON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //コマンド用インスタンス
            Commands command = new Commands();
            await command.GetPosition("Takunology");

            int x = (int)command.PlayerPosX;
            int y = (int)command.PlayerPosY;
            int z = (int)command.PlayerPosZ + 3;

            string path = @"../../../BluePrints/oak_house.xlsx";
            string path2 = @"../../../BluePrints/jungle_house.xlsx";
            ReadFromExcel OakHouse = new ReadFromExcel(path);
            ReadFromExcel JungleHouse = new ReadFromExcel(path2);
            await command.Building(x, y, z, OakHouse);
            await command.Building(x + 10, y, z + 10, JungleHouse);
            await command.Building(x + 10, y, z, OakHouse);
            await command.Building(x, y, z + 10, JungleHouse);
        }
    }
}
