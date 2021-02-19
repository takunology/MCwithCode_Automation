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

            var Items = await command.GetChestItems(237, 67, 2856);

            Console.WriteLine("=== チェスト内のアイテム ===");
            foreach(var item in Items)
            {
                Console.WriteLine($"{item.ItemSlot} \t {item.ItemID} \t {item.ItemCount}");
            }
        }
    }
}
