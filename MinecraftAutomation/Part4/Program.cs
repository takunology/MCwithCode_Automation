using CoreRCON;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Part4
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

            await command.CreatePond(8);
        }
    }
}
