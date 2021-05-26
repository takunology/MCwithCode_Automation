using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Part12
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Commands commands = new Commands();

            List<FireworksColors> colors = new List<FireworksColors>()
            { FireworksColors.BLUE, FireworksColors.GRAY };

            List<FireworksColors> fadeColors = new List<FireworksColors>()
            { FireworksColors.RED, FireworksColors.YELLOW };

            FireworksItem fireworks = new FireworksItem
                (FireworksShapes.LargeBall, false, true, colors, fadeColors);

            await commands.SetoffFireworks(20, 90, 258, fireworks);

            /*Random rnd = new Random();
            Commands commands = new Commands();
            // とりあえず100発つくる
            FireworksList fireworks = new FireworksList(10000);

            foreach(var item in fireworks.FireworksItemsList)
            {
                await commands.SetoffFireworks(20, 90, 258 + rnd.Next(-20, 20), item);
                await Task.Delay(100 * rnd.Next(1, 6));
            }*/
        
        }
    }
}
