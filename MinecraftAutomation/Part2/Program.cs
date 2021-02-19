using CoreRCON;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Part02
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("Start!");

            //コマンド用インスタンス
            Commands command = new Commands();

            await command.getPosition("Takunology");

            float x = command.PlayerPosX;
            float y = command.PlayerPosY;
            float z = command.PlayerPosZ;

            Console.WriteLine($"X : {x}");
            Console.WriteLine($"Y : {y}");
            Console.WriteLine($"Z : {z}");
        }
    }
}
