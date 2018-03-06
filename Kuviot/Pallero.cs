using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuviot
{
    class Pallero
    {
        private double xspeed, yspeed, x, y, nopeus;

        public Pallero(double xs, double ys, double xx, double yy, double nopeus)
        {
            this.xspeed = xs;
            this.yspeed = ys;
            this.x = xx;
            this.y = yy;
            this.nopeus = nopeus;
        }

        public double Xspeed
        {
            get
            {
                return xspeed;
            }
            set
            {
                xspeed = value;
            }
        }
        public double Yspeed
        {
            get
            {
                return yspeed;
            }
            set
            {
                yspeed = value;
            }
        }
        public double Xpal
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Ypal
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public double Nopeus
        {
            get
            {
                return nopeus;
            }
            set
            {
                nopeus = value;
            }
        }

    }
        
}
