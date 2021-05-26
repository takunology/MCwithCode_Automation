using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part12
{
    public class FireworksItem
    {
        public int LifeTime { get; set; } = 30;
        public int FlightDuration { get; set; } = 2;
        public FireworksShapes Shape { get; set; }
        public bool Flicker { get; set; }
        public bool Trail { get; set; }
        public List<FireworksColors> ExplosionColors { get; set; }
        public List<FireworksColors> FadeColors { get; set; }

        public FireworksItem(FireworksShapes Shape, bool Flicker, bool Trail, 
            List<FireworksColors> ExplosionColors, List<FireworksColors> FadeColors)
        {
            this.Shape = Shape;
            this.Flicker = Flicker;
            this.Trail = Trail;
            this.ExplosionColors = ExplosionColors;
            this.FadeColors = FadeColors;
        }
    }

    public enum FireworksShapes : int
    {
        SmallBall,
        LargeBall,
        Star,
        Creeper,
        Burst
    }

    public enum FireworksColors : int
    {
        BLACK = 1973019,
        RED = 11743532,
        GREEN = 3887386,
        BROWN = 5320730,
        BLUE = 2437522,
        PURPLE = 8073150,
        CYAN = 2651799,
        LIGHTGRAY = 11250603,
        GRAY = 4408131,
        PINK = 14188952,
        LIME = 4312372,
        YELLOW = 14602026,
        LIGHTBLUE = 6719955,
        MAGENTA = 12801229,
        ORANGE = 15435844,
        WHITE = 15790320
    }
}
