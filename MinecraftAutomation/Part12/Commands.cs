using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part12
{
    /// <summary>
    /// Minecraft に投げるコマンド
    /// </summary>
    public class Commands : Rcon
    {
        //↑ ここまで Part11 (省略)

        public async Task SetoffFireworks(int x, int y, int z, FireworksItem fireworks)
        {
            await rcon.ConnectAsync();
            string nbt = "{LifeTime:" + fireworks.LifeTime
                + ",FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:" 
                + fireworks.FlightDuration
                + ",Explosions:[{Type:" + (int)fireworks.Shape
                + ",Flicker:" + BoolToString(fireworks.Flicker)
                + ",Trail:" + BoolToString(fireworks.Trail)
                + ",Colors:[I;" + ColorToString(fireworks.ExplosionColors)
                + "],FadeColors:[I;" + ColorToString(fireworks.FadeColors) + "]}]}}}}";
            string result = await rcon.SendCommandAsync($"/summon firework_rocket {x} {y} {z} {nbt}");
            Console.WriteLine(result);
        }

        private static string BoolToString(bool item)
        {
            return item == true ? "1" : "0";
        }

        private static string ColorToString(List<FireworksColors> ColorsList)
        {
            string Colors = "";
            foreach (var item in ColorsList)
            {
                Colors += item.GetHashCode() + ",";
            }
            Colors = Colors.TrimEnd(',');
            return Colors;
        }

        //ここから Part12

    }
}