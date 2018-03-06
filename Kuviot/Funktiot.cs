using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuviot
{
    class Funktio
    {
        private int x, y, rot, vaihda, xr, yr, xr2, yr2;
        private double zoom;
        private int[] sel =  new int [30];
        private double[] num = new double[10];
        private string kaava;
        
        public Funktio(int x, int y,int rot,int vaihda, int xr, int yr, int xr2, int yr2, double zoom, string kaava)
        {
            this.x = x;
            this.y = y;
            this.rot = rot;
            this.vaihda = vaihda;
            this.xr = xr;
            this.yr = yr;
            this.xr2 = xr2;
            this.yr2 = yr2;
            this.zoom = zoom;
            this.kaava = kaava;
        }
        
        public int[] Sel
        {
            get
            {
                return sel;
            }
            set
            {
                sel = value;
            }
        }

        public double[] Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }

        public int X
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

        public int Y
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

        public int Rot
        {
            get
            {
                return rot;
            }
            set
            {
                rot = value;
            }
        }

        public int Vaihda
        {
            get
            {
                return vaihda;
            }
            set
            {
                vaihda = value;
            }
        }

        public int Xr
        {
            get
            {
                return xr;
            }
            set
            {
                xr = value;
            }
        }

        public int Yr
        {
            get
            {
                return yr;
            }
            set
            {
                yr = value;
            }
        }
        public int Xr2
        {
            get
            {
                return xr2;
            }
            set
            {
                xr2 = value;
            }
        }

        public int Yr2
        {
            get
            {
                return yr2;
            }
            set
            {
                yr2 = value;
            }
        }

        public double Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value;
            }
        }

        public string Kaava
        {
            get
            {
                return kaava;
            }
            set
            {
                kaava = value;
            }
        }

    }

    class Funktiot
    {
        private double x, y;
        public Funktiot(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double Paraabeli(double x,double potenssi)
        {
            this.y = Math.Pow(x, potenssi);
            return Math.Pow(x, potenssi);
        }
        public double Pallo(double x, double sade)
        {
            this.y = Math.Sqrt(Math.Pow(sade, 2) - Math.Pow(x, 2));
            return Math.Sqrt(Math.Pow(sade,2) - Math.Pow(x,2));
        }

        public double Kulta()
        {
            
            return 0.5 * (1 + Math.Sqrt(5));
        }

        public double Log10(double x)
        {
            return Math.Log10(x);
        }

        public double Exp(double luku,double x)
        {
            return Math.Pow(luku, x);
        }

        public double Sin(double x)
        {
            return Math.Sin(x);
        }

        static double NthRoot(double A, int N)
        {
            return Math.Pow(A, 1.0 / N);
        }
    }
}
