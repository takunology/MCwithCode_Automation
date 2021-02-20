using CoreRCON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part11
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //コマンド用インスタンス
            Commands command = new Commands();
            int x = 274;
            int y = 66;
            int z = 2902;

            await command.CreateFarmland(x, y, z);
            await command.Plant(x, y + 1, z);
        }
    }
}
