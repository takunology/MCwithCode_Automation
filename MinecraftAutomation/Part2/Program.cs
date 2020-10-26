using CoreRCON;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Part2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            Console.WriteLine("Start!");

            //コマンド用インスタンス
            Commands mcCommand = new Commands();

            await mcCommand.Teleport("Takunology");
        }
    }


}
