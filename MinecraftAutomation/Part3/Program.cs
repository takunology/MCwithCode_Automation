﻿using CoreRCON;
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
            Commands command = new Commands();

            await command.getPosition("Takunology");

            float x = command.PlayerPosX;
            float y = command.PlayerPosY;
            float z = command.PlayerPosZ;

            await command.Teleport("Takunology", x+5, y, z-2);
        }
    }


}