﻿using CoreRCON;
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
            //左側のチェスト内のアイテムを取得
            var Items = await command.GetChestItems(237, 67, 2856);
            //逆順に並べ替える
            await command.SetChestItems(237, 67, 2854, Items.ReverseSortByID());
        }
    }
}
