using CoreRCON;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Part03
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //コマンド用インスタンス
            Commands command = new Commands();
            await command.GetPosition("Takunology");

            //プレイヤーが押し出されるのを防ぐ
            int x = (int)command.PlayerPosX + 1;
            int y = (int)command.PlayerPosY;
            int z = (int)command.PlayerPosZ;

            //1次元方向への配置（線形配置）
            /*for(int i = 0; i < 10; i++)
            {
                await command.SetBlock(x+i, y, z, "minecraft:stone");
            }*/

            //2次元方向への配置（平面配置）
            /*for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    await command.SetBlock(x + i, y, z + j, "minecraft:air");
                }
            }*/

            //3次元方向への配置（空間配置）
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for(int k = 0; k < 10; k++)
                    {
                        await command.SetBlock(x + j, y + i, z + k, "minecraft:stone");
                    }            
                }
            }
        }
    }


}
