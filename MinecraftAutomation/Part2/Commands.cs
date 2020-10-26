using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    /// <summary>
    /// Minecraft に投げるコマンド
    /// </summary>
    public class Commands : Rcon
    {
        public async Task Teleport(string playerName)
        {
            await rcon.ConnectAsync();
            string result = await rcon.SendCommandAsync($"/tp {playerName} ~ ~ ~");
            Console.WriteLine(result);
        }
    }
}
