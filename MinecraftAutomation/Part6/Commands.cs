using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part6
{
    /// <summary>
    /// Minecraft に投げるコマンド
    /// </summary>
    public class Commands : Rcon
    {
        public float PlayerPosX;
        public float PlayerPosY;
        public float PlayerPosZ;

        public int BlockCount;
        public List<string> BlockCoordinate = new List<string>();

        public async Task Teleport(string playerName, float x, float y, float z)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/tp {playerName} {x} {y} {z}");
            Console.WriteLine(result);
        }

        public async Task GetPosition(string playerName)
        {
            await rcon.ConnectAsync();
            // Minecraft 1.13 以降では data コマンドで座標を得られる
            // 1.12 以前では tp ~ ~ ~ で現在地へテレポートして座標を得る
            string result = await rcon.SendCommandAsync($"/data get entity {playerName} Pos");
            string filterResult = Regex.Replace(result, @"[^0-9-,.]", "");
            string[] splitResult = filterResult.Split(",");

            PlayerPosX = float.Parse(splitResult[0]);
            PlayerPosY = float.Parse(splitResult[1]);
            PlayerPosZ = float.Parse(splitResult[2]);
        }

        public async Task SetBlock(float x, float y, float z, string blockName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/setblock {x} {y} {z} {blockName}");
            Console.WriteLine(result);
        }

        public async Task SetIchimatsu(int x, int y, int z, int range)
        {
            await rcon.ConnectAsync();
            
            for(int i = 0; i < range; i++)
            {
                if(i % 2 == 0)
                {
                    for (int j = 0; j < range; j++)
                    {
                        if (j % 2 == 0)
                        {
                            string result = await rcon.SendCommandAsync($"/setblock {x + i} {y} {z + j} minecraft:oak_planks");
                            Console.WriteLine(result);
                        }
                        else
                        {
                            string result = await rcon.SendCommandAsync($"/setblock {x + i} {y} {z + j} minecraft:spruce_planks");
                            Console.WriteLine(result);
                        }
                    }

                }
                else
                {
                    for (int j = 0; j < range; j++)
                    {
                        if (j % 2 == 0)
                        {
                            string result = await rcon.SendCommandAsync($"/setblock {x + i} {y} {z + j} minecraft:spruce_planks");
                            Console.WriteLine(result);
                        }
                        else
                        {
                            string result = await rcon.SendCommandAsync($"/setblock {x + i} {y} {z + j} minecraft:oak_planks");
                            Console.WriteLine(result);
                        }
                    }

                }
            }
        }

        public async Task NetherGate()
        {
            await rcon.ConnectAsync();

            int x = (int)PlayerPosX + 3;
            int y = (int)PlayerPosY;
            int z = (int)PlayerPosZ;

            string result;

            //黒曜石を配置
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    result = await rcon.SendCommandAsync($"/setblock {x} {y + j} {z + i} minecraft:obsidian");
                    Console.WriteLine(result);
                }
            }

            //空気ブロック配置
            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    result = await rcon.SendCommandAsync($"/setblock {x} {y + j} {z + i} minecraft:air");
                    Console.WriteLine(result);
                }
            }
            //火をつける
            result = await rcon.SendCommandAsync($"/setblock {x} {y + 1} {z + 2} minecraft:fire");
            Console.WriteLine(result);
        }

        public async Task CreatePond(int range)
        {
            await rcon.ConnectAsync();

            int x = (int)PlayerPosX + 2;
            int y = (int)PlayerPosY;
            int z = (int)PlayerPosZ;

            string result;

            // 2×2以上のみ受け付ける
            if (range < 4)
                return;

            //石ブロックの配置
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < range; j++)
                {
                    for (int k = 0; k < range; k++)
                    {

                        result = await rcon.SendCommandAsync($"/setblock {x + j} {(y - 1) + i} {z + k} minecraft:stone");
                        Console.WriteLine(result);
                    }
                }
            }

            //中身をくり抜く
            for(int i = 1; i < range - 1; i++)
            {
                for(int j = 1; j < range - 1; j++)
                {
                    result = await rcon.SendCommandAsync($"/setblock {x + i} {y} {z + j} minecraft:air");
                    Console.WriteLine(result);
                }
            }

            //水源を配置
            for(int i = 1; i < range - 1; i++)
            {
                for (int j = 1; j < range - 1; j++)
                {
                    if(i == j)
                    {
                        result = await rcon.SendCommandAsync($"/setblock {x + i} {y} {z + j} minecraft:water");
                        Console.WriteLine(result);
                    }
                }
            }
        }

        public async Task TestForBlock(int x, int y, int z, string blockName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/execute if block {x} {y} {z} {blockName}");
            
            Console.Write($"Search for {x} {y} {z} ");

            if (result.Contains("passed"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hit!");
                Console.ForegroundColor = ConsoleColor.White;
                BlockCount++;

                //このままでは面白くないので座標を吐き出す
                BlockCoordinate.Add($"{blockName} : {x} {y} {z}");
            }
            else
                Console.WriteLine();
        }

        public async Task SearchBlock(int Sx, int Sy, int Sz, int Ex, int Ey, int Ez, string blockName)
        {
            if (Sx > Ex || Sy < Ey || Sz > Ez)
                return;

            await rcon.ConnectAsync();

            for (int y = Sy; y > Ey; y--)
            {
                for (int x = Sx; x < Ex; x++)
                {
                    for (int z = Sz; z < Ez; z++)
                    {
                        await TestForBlock(x, y, z, blockName);
                    }
                }
            }
        }

        //ここからPart6
        //座標が大きくなる方向で使用する
        public async Task GroundLeveling(int Sx, int Sy, int Sz, int Ex, int Ey, int Ez)
        {
            if (Sx > Ex || Sy > Ey || Sz > Ez)
                return;

            await rcon.ConnectAsync();

            for(int y = Sy; y < Ey; y++)
            {
                for(int x = Sx; x < Ex; x++)
                {
                    for (int z = Sz; z < Ez; z++)
                    {
                        string result = await rcon.SendCommandAsync($"/setblock {x} {y} {z} minecraft:air");
                        Console.WriteLine(result);
                    }
                }
            }
        }

        public async Task GroundLeveling(int Sx, int Sy, int Sz, int Ex, int Ey, int Ez, string blockName)
        {
            if (Sx > Ex || Sy > Ey || Sz > Ez)
                return;

            await rcon.ConnectAsync();

            for (int y = Sy; y < Ey; y++)
            {
                for (int x = Sx; x < Ex; x++)
                {
                    for (int z = Sz; z < Ez; z++)
                    { 
                        string result = await rcon.SendCommandAsync($"/execute if block {x} {y} {z} {blockName}");
                        if (result.Contains("passed"))
                        {
                            Console.WriteLine(result);
                            break;
                        }
                        else
                        {
                            //除外するブロックではない場合
                            result = await rcon.SendCommandAsync($"/setblock {x} {y} {z} minecraft:air");
                            Console.WriteLine(result);
                        }
                    }
                }
            }
        }

        //特定のブロックを残して整地
        public async Task GroundLeveling(int Sx, int Sy, int Sz, int Ex, int Ey, int Ez, List<string> blockList)
        {
            if (Sx > Ex || Sy > Ey || Sz > Ez)
                return;

            await rcon.ConnectAsync();

            for (int y = Sy; y < Ey; y++)
            {
                for (int x = Sx; x < Ex; x++)
                {
                    for (int z = Sz; z < Ez; z++)
                    {
                        bool isPassed = false; //ブロック一致フラグ

                        //ブロックリストから検索
                        foreach(string block in blockList)
                        {
                            string blockName = await rcon.SendCommandAsync($"/execute if block {x} {y} {z} {block}");
                            Console.WriteLine(blockName);
                            if (blockName.Contains("passed"))
                            {
                                //登録されたブロックと一致したらフラグをたてる
                                isPassed = true;
                                break;
                            }
                        }

                        if (!isPassed)
                        {
                            string result = await rcon.SendCommandAsync($"/setblock {x} {y} {z} minecraft:air");
                            Console.WriteLine(result);
                        }                        
                    }
                }
            }
        }


    }
}
