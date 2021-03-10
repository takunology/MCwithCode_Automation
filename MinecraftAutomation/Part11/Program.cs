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
            int x = 537;
            int y = 65;
            int z = 2953;

           /*for(int i = 0; i < 3; i++)
           {
                for(int j = 0; j < 6; j++)
                {
                    await command.CreateFarmland(x + i * 9, y, z + j * 9);
                    if (i == 0)
                        await command.Plant(x + i * 9, y + 1, z + j * 9, "minecraft:wheat");
                    else if(i == 1)
                        await command.Plant(x + i * 9, y + 1, z + j * 9, "minecraft:potatoes");
                    else
                        await command.Plant(x + i * 9, y + 1, z + j * 9, "minecraft:carrots");
                }
            }*/

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    await command.AutoGetCrops(x + i * 9, y + 1, z + j * 9);
                }
            }
        }
    }
}
