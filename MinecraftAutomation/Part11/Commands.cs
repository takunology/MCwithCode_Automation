using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part11
{
    /// <summary>
    /// Minecraft に投げるコマンド
    /// </summary>
    public class Commands : Rcon
    {
        public async Task SetBlock(float x, float y, float z, string blockName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/setblock {x} {y} {z} {blockName}");
            Console.WriteLine(result);
        }
        //↑ ここまで Part10 (省略)

        //ここから Part11
        public async Task CreateFarmland(int x, int y, int z)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (i == 4 && j == 4)
                    {
                        await SetBlock(x + i, y, z + j, "minecraft:water");
                        break;
                    }
                    await SetBlock(x + i, y, z + j, "minecraft:farmland");
                }
            }
        }

        public async Task Plant(int x, int y, int z)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 4 && j == 4) break;
                    await SetBlock(x + i, y, z + j, "minecraft:wheat[age=0]");
                }
            }
        }
    }
}