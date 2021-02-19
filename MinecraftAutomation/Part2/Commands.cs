using CoreRCON.Parsers.Standard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part02
{
    /// <summary>
    /// Minecraft に投げるコマンド
    /// </summary>
    public class Commands : Rcon
    {
        public float PlayerPosX;
        public float PlayerPosY;
        public float PlayerPosZ;

        public async Task Teleport(string playerName, float x, float y, float z)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/tp {playerName} {x} {y} {z}");
            Console.WriteLine(result);
        }

        public async Task getPosition(string playerName)
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
    }
}
