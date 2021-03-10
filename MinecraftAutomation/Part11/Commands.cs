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
                        continue;
                    }
                    await SetBlock(x + i, y, z + j, "minecraft:farmland");
                }
            }
        }

        public async Task WheatsStatus(int x, int y, int z)
        {
            await rcon.ConnectAsync();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 4 && j == 4)
                    {
                        Console.Write("W ");
                        continue;
                    }
                    for(int k = 0; k < 8; k++)
                    {
                        string result = await rcon.SendCommandAsync($"/execute if block {x + i} {y} {z + j} minecraft:wheat[age={k}]");
                        if (result.Contains("passed"))
                        {
                            Console.Write(k + " ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public async Task Plant(int x, int y, int z)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 4 && j == 4) continue;
                    await SetBlock(x + i, y, z + j, "minecraft:wheat[age=0]");
                }
            }
        }

        public async Task GetWheat(int x, int y, int z)
        {
            await rcon.ConnectAsync();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 4 && j == 4) continue;

                    string result = await rcon.SendCommandAsync($"/execute if block {x + i} {y} {z + j} minecraft:wheat[age=7]");
                    if (result.Contains("passed"))
                    {
                        //収穫したら種を植える
                        await rcon.SendCommandAsync("/give Takunology minecraft:wheat");
                        await SetBlock(x + i, y, z + j, "minecraft:wheat[age=0]");
                    }
                }
            }
        }

        public async Task Plant(int x, int y, int z, string Seeds)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 4 && j == 4) continue;
                    await SetBlock(x + i, y, z + j, Seeds);
                }
            }
        }

        public async Task AutoGetCrops(int x, int y, int z)
        {
            await rcon.ConnectAsync();

            List<string> Crops = new List<string>
            {
                "minecraft:wheat",
                "minecraft:potatoes",
                "minecraft:carrots",
            };

            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (i == 4 && j == 4) continue;

                    foreach(var Crop in Crops)
                    {
                        //作物の種類を調べる
                        string result = await rcon.SendCommandAsync($"/execute if block {x + i} {y} {z + j} {Crop}");
                        if (result.Contains("passed"))
                        {
                            result = await rcon.SendCommandAsync($"/execute if block {x + i} {y} {z + j} {Crop}[age=7]");
                            if (result.Contains("passed"))
                            {
                                //ブロック名とアイテム名が異なるので分岐させる
                                if(Crop == "minecraft:potatoes")
                                    await rcon.SendCommandAsync($"/give Takunology potato");
                                else if(Crop == "minecraft:carrots")
                                    await rcon.SendCommandAsync($"/give Takunology carrot");
                                else
                                    await rcon.SendCommandAsync($"/give Takunology wheat");
                                await SetBlock(x + i, y, z + j, $"{Crop}[age=0]");
                                await Task.Delay(50);
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}