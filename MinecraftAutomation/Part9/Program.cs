using CoreRCON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part10
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //コマンド用インスタンス
            Commands command = new Commands();

            var Items = await command.GetChestItems(476, 65, 2965);
            await command.SetChestItems(476, 65, 2963, Items.ReverseSortByID());
        }
    }
}
