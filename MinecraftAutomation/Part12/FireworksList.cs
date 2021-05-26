using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part12
{
    public class FireworksList
    {
        public List<FireworksItem> FireworksItemsList = new List<FireworksItem>();

        public FireworksList(int itemCount)
        {
            for(int i = 0; i < itemCount; i++)
            {
                FireworksItemsList.Add(MakeFireworks());
            }
        }

        private FireworksItem MakeFireworks()
        {
            return new FireworksItem(FireworksShapes.LargeBall, true, false, GetRandomColors(), GetRandomColors());
        }

        private List<FireworksColors> GetRandomColors()
        {
            Random rnd = new Random();
            List<FireworksColors> colorList = new List<FireworksColors>();
            //何色か入れる場合は反復させたり...？
            for (int i = 0; i < rnd.Next(1, 3); i++)
            {
                switch (rnd.Next(0, 15))
                {
                    case 0:
                        colorList.Add(FireworksColors.BLACK);
                        break;
                    case 1:
                        colorList.Add(FireworksColors.BLUE);
                        break;
                    case 2:
                        colorList.Add(FireworksColors.BROWN);
                        break;
                    case 3:
                        colorList.Add(FireworksColors.CYAN);
                        break;
                    case 4:
                        colorList.Add(FireworksColors.GRAY);
                        break;
                    case 5:
                        colorList.Add(FireworksColors.GREEN);
                        break;
                    case 6:
                        colorList.Add(FireworksColors.LIGHTBLUE);
                        break;
                    case 7:
                        colorList.Add(FireworksColors.LIGHTGRAY);
                        break;
                    case 8:
                        colorList.Add(FireworksColors.LIME);
                        break;
                    case 9:
                        colorList.Add(FireworksColors.MAGENTA);
                        break;
                    case 10:
                        colorList.Add(FireworksColors.ORANGE);
                        break;
                    case 11:
                        colorList.Add(FireworksColors.PINK);
                        break;
                    case 12:
                        colorList.Add(FireworksColors.PURPLE);
                        break;
                    case 13:
                        colorList.Add(FireworksColors.RED);
                        break;
                    case 14:
                        colorList.Add(FireworksColors.WHITE);
                        break;
                    default:
                        colorList.Add(FireworksColors.YELLOW);
                        break;
                }
            }
            return colorList;
        }
    }
}
