using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Timers;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Kuviot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ellipse[,] el = new Ellipse[10,1200];
        Line[,] li = new Line[10, 1200];
        Funktiot joo = new Funktiot(0, 0);
        Funktio[] fun = new Funktio[20];
        public DispatcherTimer timer;
        TimeSpan time;
        int speed = 10;
        Pallero myPa = new Pallero(0, 0, 200, 200, 0);
        Ellipse myEl = new Ellipse();
        double aste = 0;
        double alpha=0, beta=0;
        Line li1 = new Line();
        Line li2 = new Line();
        Boolean liike = false;
        int ins = 1;
        int ins2 = 1;
        int ins3 = 1;
        int ins4 = 1;
        double M1 = 0, M2 = 0;
        double X = 0, Y = 0;
        int laskuri = 0;

        public MainWindow()
        {
            InitializeComponent();
            C.Height = Height;
            M1 = C.Height = Height;
            M2 = C.Width = Width;
            Pallo();
            Ajastin();
            Alustus();
            Koordinaatisto();
            Listat();
            Piilotus();
            Kombo();
        }

        private void Pallo()
        {
            myEl.Stroke = System.Windows.Media.Brushes.Yellow;
            myEl.Fill = System.Windows.Media.Brushes.YellowGreen;
            myEl.Width = 20;
            myEl.Height = 20;

            Canvas.SetTop(myEl, myPa.Ypal - (myEl.ActualHeight) / 2);
            Canvas.SetLeft(myEl, myPa.Xpal - (myEl.ActualWidth) / 2);

            C.Children.Add(myEl);
        }
        private void Ajastin()
        {
            Time = TimeSpan.Zero;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(speed);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void Alustus()
        {
            for (int las = 0; las < 10; las++)
            {
                fun[las] = new Funktio(0, 0, 0, 0, -200, -200, 200, 200, 1,"");
                for (int las2 = 0; las2 < 25; las2++) fun[las].Sel[las2] = 1;
                for (int las3 = 0; las3 < 7; las3++) fun[las].Num[las3] = 3;
            }
            for (int x3 = 0; x3 < 10; x3++)
            {
                for (int kai = 0; kai < 1200; kai++)
                {
                    el[x3, kai] = new Ellipse();
                    el[x3, kai].Width = 4;
                    el[x3, kai].Height = 4;
                                       
                        li[x3, kai] = new Line();
                        li[x3, kai].Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                        li[x3, kai].X1 = 0;
                        li[x3, kai].X2 = 0;
                        li[x3, kai].Y1 = 0;
                        li[x3, kai].Y2 = 0;

                        C.Children.Add(li[x3, kai]);
                   
                    Canvas.SetTop(el[x3, kai], 0);
                    Canvas.SetLeft(el[x3, kai], 0);

                    C.Children.Add(el[x3, kai]);

                }
            }
        }
        private void Koordinaatisto()
        {
            li1.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            li2.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            li1.X1 = 0;
            li1.X2 = 400+X;
            li1.Y1 = 200+Y;
            li1.Y2 = 200+Y;
            li2.X1 = 200+X;
            li2.X2 = 200+X;
            li2.Y1 = 0;
            li2.Y2 = 400+Y;

            C.Children.Add(li1);
            C.Children.Add(li2);
        }
        private void Listat()
        {
            listBox.Items.Add("ei mitään");//0
            listBox1.Items.Add("ei mitään");
            listBox2.Items.Add("ei mitään");
            listBox3.Items.Add("ei mitään");
            listBox4.Items.Add("ei mitään");

            listBox.Items.Add("plus");//1
            listBox1.Items.Add("plus");
            listBox2.Items.Add("plus");
            listBox3.Items.Add("plus");
            listBox4.Items.Add("plus");

            listBox.Items.Add("miinus");//2
            listBox1.Items.Add("miinus");
            listBox2.Items.Add("miinus");
            listBox3.Items.Add("miinus");
            listBox4.Items.Add("miinus");

            listBox.Items.Add("kerto");//3
            listBox1.Items.Add("kerto");
            listBox2.Items.Add("kerto");
            listBox3.Items.Add("kerto");
            listBox4.Items.Add("kerto");

            listBox.Items.Add("jako");//4
            listBox1.Items.Add("jako");
            listBox2.Items.Add("jako");
            listBox3.Items.Add("jako");
            listBox4.Items.Add("jako");

            listBox.Items.Add("paraabeli");//5
            listBox1.Items.Add("paraabeli");
            listBox2.Items.Add("paraabeli");
            listBox3.Items.Add("paraabeli");
            listBox4.Items.Add("paraabeli");

            listBox.Items.Add("ympyrä");//6
            listBox1.Items.Add("ympyrä");
            listBox2.Items.Add("ympyrä");
            listBox3.Items.Add("ympyrä");
            listBox4.Items.Add("ympyrä");

            listBox.Items.Add("1/");//7
            listBox1.Items.Add("1/");
            listBox2.Items.Add("1/");
            listBox3.Items.Add("1/");
            listBox4.Items.Add("1/");

            listBox.Items.Add("sin");//8
            listBox1.Items.Add("sin");
            listBox2.Items.Add("sin");
            listBox3.Items.Add("sin");
            listBox4.Items.Add("sin");

            listBox.Items.Add("cos");//9
            listBox1.Items.Add("cos");
            listBox2.Items.Add("cos");
            listBox3.Items.Add("cos");
            listBox4.Items.Add("cos");

            listBox.Items.Add("tan");//10
            listBox1.Items.Add("tan");
            listBox2.Items.Add("tan");
            listBox3.Items.Add("tan");
            listBox4.Items.Add("tan");

            listBox.Items.Add("inside");//11
            listBox1.Items.Add("inside");
            listBox2.Items.Add("inside");
            listBox3.Items.Add("inside");
            listBox4.Items.Add("inside");

            listBox.Items.Add("numero");//12
            listBox1.Items.Add("numero");
            listBox2.Items.Add("numero");
            listBox3.Items.Add("numero");
            listBox4.Items.Add("numero");

            listBox.Items.Add("log");//13
            listBox1.Items.Add("log");
            listBox2.Items.Add("log");
            listBox3.Items.Add("log");
            listBox4.Items.Add("log");

            listBox.Items.Add("suora");//14
            listBox1.Items.Add("suora");
            listBox2.Items.Add("suora");
            listBox3.Items.Add("suora");
            listBox4.Items.Add("suora");

            listBox.Items.Add("neliö");//15
            listBox1.Items.Add("neliö");
            listBox2.Items.Add("neliö");
            listBox3.Items.Add("neliö");
            listBox4.Items.Add("neliö");

            listBox.Items.Add("potenssin kantaluku");//16
            listBox1.Items.Add("potenssin kantaluku");
            listBox2.Items.Add("potenssin kantaluku");
            listBox3.Items.Add("potenssin kantaluku");
            listBox4.Items.Add("potenssin kantaluku");

            listBox.SelectedIndex = 1;
            listBox1.SelectedIndex = 1;
            listBox2.SelectedIndex = 1;
            listBox3.SelectedIndex = 1;
            listBox4.SelectedIndex = 1;

        }
        private void Piilotus()
        {
            TranslateTransform transform = new TranslateTransform();

            transform.X = -1000;
            transform.Y = -1000;

            this.A3.RenderTransform = transform;
            this.B3.RenderTransform = transform;
            this.C3.RenderTransform = transform;
            this.D3.RenderTransform = transform;
            this.E3.RenderTransform = transform;
            this.F3.RenderTransform = transform;
            this.G3.RenderTransform = transform;
            this.H3.RenderTransform = transform;
            this.I3.RenderTransform = transform;
            this.J3.RenderTransform = transform;
            this.K3.RenderTransform = transform;
            this.L3.RenderTransform = transform;
            this.M3.RenderTransform = transform;
            this.N3.RenderTransform = transform;
            this.O3.RenderTransform = transform;
            this.P3.RenderTransform = transform;
            this.Q3.RenderTransform = transform;

            this.A1.RenderTransform = transform;
            this.B1.RenderTransform = transform;
            this.C1.RenderTransform = transform;
            this.D1.RenderTransform = transform;
            this.E1.RenderTransform = transform;
            this.A2.RenderTransform = transform;
            this.B2.RenderTransform = transform;
            this.C2.RenderTransform = transform;
            this.D2.RenderTransform = transform;
            this.E2.RenderTransform = transform;

            this.button3.RenderTransform = transform;
            this.button4.RenderTransform = transform;
            this.textBox12.RenderTransform = transform;
            this.button5.RenderTransform = transform;
            this.button6.RenderTransform = transform;
            this.button7.RenderTransform = transform;
            this.button8.RenderTransform = transform;

            this.kaava0.RenderTransform = transform;
            this.kaava1.RenderTransform = transform;
            this.kaava2.RenderTransform = transform;
            this.kaava3.RenderTransform = transform;
            this.kaava4.RenderTransform = transform;
            this.kaava5.RenderTransform = transform;
        }
        private void Kombo()
        {
            CB.Items.Add("ei mitään");
            CB.Items.Add("ei mitään");
            CB.Items.Add("ei mitään");
            CB.Items.Add("ei mitään");
            CB.Items.Add("ei mitään");
            CB.Items.Add("ei mitään");
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            Kaava();
        }
        private void Kaava()
        {
            int[] taul = new int[9];
            string kaava = "";

            for (int n = 0; n < 9; n++) taul[n] = 0;

            TranslateTransform transform = new TranslateTransform();

            A1.Text = "";
            A2.Text = "";
            B2.Text = "";
            C2.Text = "";
            D2.Text = "";
            E2.Text = "";

            M3.Text = "";
            N3.Text = "";
            O3.Text = "";
            P3.Text = "";
            Q3.Text = "";

            A3.Text = "";
            E3.Text = "";
            F3.Text = "";
            G3.Text = "";
            H3.Text = "";

            B3.Text = "";
            C3.Text = "";
            D3.Text = "";
            I3.Text = "";

            J3.Text = "";
            K3.Text = "";
            L3.Text = "";


            if ((listBox.SelectedIndex == 5 || listBox.SelectedIndex == 6 || listBox.SelectedIndex == 7 || listBox.SelectedIndex == 8 || listBox.SelectedIndex == 9 || listBox.SelectedIndex == 10 || listBox.SelectedIndex == 13 || listBox.SelectedIndex == 14 || listBox.SelectedIndex == 16))
            {
                /*A1.Text += '(';
                A2.Text += ')';*/

                A3.Text = listBox.SelectedItem.ToString();
                if (ins == 5)
                {
                    N3.Text += '(';
                    M3.Text += ')';
                    A3.Text += 'X';
                }
                else if (listBox1.SelectedIndex != 0 && listBox1.SelectedIndex != 1 && listBox1.SelectedIndex != 2 && listBox1.SelectedIndex != 3 && listBox1.SelectedIndex != 4)
                {
                    M3.Text += '+';
                    
                }
                else
                {
                    N3.Text += '(';
                    M3.Text += ')';
                }
                if(ins!=5) A3.Text += 'X';
                taul[4] = 1;
                

            }
            else
            {
                /*if (listBox.SelectedIndex == 4) A3.Text = "oikea/vasen";
                else if (listBox.SelectedIndex == 2) A3.Text = "oikea-vasen";
                else A3.Text = listBox.SelectedItem.ToString();*/
                //    M3.Text += '+';
                /*taul[5] = 1;
                L3.Text += ')';*/
                switch (listBox.SelectedIndex)
                {
                    case 1 : A3.Text = "+";
                             break;
                    case 2 : A3.Text = "-";
                            break;
                    case 3 : A3.Text = "*";
                            break;
                    case 4 : A3.Text = "/";
                            break;
                    case 12: A3.Text = textBox.Text.ToString();
                            if (ins != 5)
                            {
                                if (listBox1.SelectedIndex != 0 && listBox1.SelectedIndex != 1 && listBox1.SelectedIndex != 2 && listBox1.SelectedIndex != 3 && listBox1.SelectedIndex != 4) M3.Text += '+';
                            }
                            else
                            {
                                N3.Text += '(';
                                M3.Text += ')';
                            }   
                            break;

                }
            }
            if ((listBox1.SelectedIndex == 5 || listBox1.SelectedIndex == 6 || listBox1.SelectedIndex == 7 || listBox1.SelectedIndex == 8 || listBox1.SelectedIndex == 9 || listBox1.SelectedIndex == 10 || listBox1.SelectedIndex == 13 || listBox1.SelectedIndex == 14 || listBox1.SelectedIndex == 16))
            {
                /*A1.Text += '(';
                B2.Text += ')';*/
               
                if(ins==5) E3.Text = listBox1.SelectedItem.ToString();
                else B3.Text = listBox1.SelectedItem.ToString();
                if (ins2 == 5)
                {
                    O3.Text += '(';
                    L3.Text += ')';
                    /*if (ins == 5) ;// E3.Text += 'X';
                    else B3.Text += 'X';*/
                }
                else if (listBox2.SelectedIndex != 0 && listBox2.SelectedIndex != 1 && listBox2.SelectedIndex != 2 && listBox2.SelectedIndex != 3 && listBox2.SelectedIndex != 4)
                {
                    L3.Text += '+';
                    /*if (ins == 5) ; //E3.Text += 'X';
                    else B3.Text += 'X';*/
                }
                else
                {
                    O3.Text += '(';
                    L3.Text += ')';
                }
                if (ins == 5) ; //E3.Text += 'X';
                else B3.Text += 'X';
                taul[3] = 1;
                
            }
            else
            {
                /*if (listBox1.SelectedIndex == 4) E3.Text = "oikea/vasen";
                else if (listBox1.SelectedIndex == 2) E3.Text = "oikea-vasen";
                else E3.Text = listBox1.SelectedItem.ToString();*/
            //    L3.Text += '+';
                taul[5] = 1;
                //K3.Text += ')';
                //M3.Text += '+';
                //M3.Text = "";
                switch (listBox1.SelectedIndex)
                {
                    case 1:
                        B3.Text = "+";
                        break;
                    case 2:
                        B3.Text = "-";
                        break;
                    case 3:
                        B3.Text = "*";
                        break;
                    case 4:
                        B3.Text = "/";
                        break;
                    case 12:
                        B3.Text = textBox1.Text.ToString();
                        if (ins2 != 5)
                        {
                            if (listBox2.SelectedIndex != 0 && listBox2.SelectedIndex != 1 && listBox2.SelectedIndex != 2 && listBox2.SelectedIndex != 3 && listBox2.SelectedIndex != 4) L3.Text += '+';
                        }
                        else
                        {
                            O3.Text += '(';
                            L3.Text += ')';
                        }
                        break;
                }

            }
            if ((listBox2.SelectedIndex == 5 || listBox2.SelectedIndex == 6 || listBox2.SelectedIndex == 7 || listBox2.SelectedIndex == 8 || listBox2.SelectedIndex == 9 || listBox2.SelectedIndex == 10 || listBox2.SelectedIndex == 13 || listBox2.SelectedIndex == 14 || listBox2.SelectedIndex == 16))
            {

                /*A1Text += '(';
                C2.Text += ')';
                F3.Text = listBox2.SelectedItem.ToString();*/
                if (ins2 == 5) F3.Text = listBox2.SelectedItem.ToString();
                else C3.Text = listBox2.SelectedItem.ToString();
                if (ins3 == 5)
                {
                    P3.Text += '(';
                    K3.Text += ')';
                    /*if (ins2 == 5) ;// F3.Text += 'X';
                    else C3.Text += 'X';*/
                }
                else if (listBox3.SelectedIndex != 0 && listBox3.SelectedIndex != 1 && listBox3.SelectedIndex != 2 && listBox3.SelectedIndex != 3 && listBox3.SelectedIndex != 4)
                {
                    K3.Text += '+';
                    /*if (ins2 == 5); //F3.Text += 'X';
                    else C3.Text += 'X';*/
                }
                else
                {
                    P3.Text += '(';
                    K3.Text += ')';
                }
                if (ins2 == 5) ; //F3.Text += 'X';
                else C3.Text += 'X';
                /*P3.Text += '(';
                K3.Text += ')';
                taul[2] = 1;
                F3.Text = listBox2.SelectedItem.ToString();*/
            }
            else
            {
                /*if (listBox2.SelectedIndex == 4) F3.Text = "oikea/vasen";
                else if (listBox2.SelectedIndex == 2) F3.Text = "oikea-vasen";
                else F3.Text = listBox2.SelectedItem.ToString();*/
         //       K3.Text += '+';
                taul[6] = 1;
                //J3.Text += ')';
                //K3.Text += '+';
                //L3.Text = "";
                switch (listBox2.SelectedIndex)
                {
                    case 1:
                        C3.Text = "+";
                        break;
                    case 2:
                        C3.Text = "-";
                        break;
                    case 3:
                        C3.Text = "*";
                        break;
                    case 4:
                        C3.Text = "/";
                        break;
                    case 12:
                        C3.Text = textBox2.Text.ToString();
                        if (ins3 != 5)
                        {
                            if (listBox3.SelectedIndex != 0 && listBox3.SelectedIndex != 1 && listBox3.SelectedIndex != 2 && listBox3.SelectedIndex != 3 && listBox3.SelectedIndex != 4) K3.Text += '+';
                        }
                        else
                        {
                            P3.Text += '(';
                            K3.Text += ')';
                        }
                        break;
                }
            }
            if ((listBox3.SelectedIndex == 5 || listBox3.SelectedIndex == 6 || listBox3.SelectedIndex == 7 || listBox3.SelectedIndex == 8 || listBox3.SelectedIndex == 9 || listBox3.SelectedIndex == 10 || listBox3.SelectedIndex == 13 || listBox3.SelectedIndex == 14 || listBox3.SelectedIndex == 16))
            {
                /*A1.Text += '(';
                D2.Text += ')';
                G3.Text = listBox3.SelectedItem.ToString();*/
                if (ins3 == 5) G3.Text = listBox3.SelectedItem.ToString();
                else D3.Text = listBox3.SelectedItem.ToString();
                if (ins4 == 5)
                {
                    Q3.Text += '(';
                    J3.Text += ')';
                    /*if (ins3 == 5) ;// G3.Text += 'X';
                    else D3.Text += 'X';*/
                }
                else if (listBox4.SelectedIndex != 0 && listBox4.SelectedIndex != 1 && listBox4.SelectedIndex != 2 && listBox4.SelectedIndex != 3 && listBox4.SelectedIndex != 4)
                {
                    J3.Text += '+';
                    /*if (ins3 == 5) ; //G3.Text += 'X';
                    else D3.Text += 'X';*/
                }
                else
                {
                    Q3.Text += '(';
                    J3.Text += ')';
                }
                if (ins3 == 5) ; //G3.Text += 'X';
                else D3.Text += 'X';
                /*Q3.Text += '(';
                J3.Text += ')';
                taul[1] = 1;
                G3.Text = listBox3.SelectedItem.ToString();*/

            }
            else
            {
                /*if (listBox3.SelectedIndex == 4) G3.Text = "oikea/vasen";
                else if (listBox3.SelectedIndex == 2) G3.Text = "oikea-vasen";
                else G3.Text = listBox3.SelectedItem.ToString();*/
            //    J3.Text += '+';
                taul[7] = 1;
                //J3.Text += '+';
                //K3.Text = "";
                switch (listBox3.SelectedIndex)
                {
                    case 1:
                        D3.Text = "+";
                        break;
                    case 2:
                        D3.Text = "-";
                        break;
                    case 3:
                        D3.Text = "*";
                        break;
                    case 4:
                        D3.Text = "/";
                        break;
                    case 12:
                        D3.Text = textBox3.Text.ToString();
                        if (ins4 != 5)
                        {
                            if (listBox4.SelectedIndex != 0 && listBox4.SelectedIndex != 1 && listBox4.SelectedIndex != 2 && listBox4.SelectedIndex != 3 && listBox4.SelectedIndex != 4) J3.Text += '+';
                        }
                        else
                        {
                            Q3.Text += '(';
                            J3.Text += ')';
                        }
                        break;
                }
                
            }
            if (listBox4.SelectedIndex == 5 || listBox4.SelectedIndex == 6 || listBox4.SelectedIndex == 7 || listBox4.SelectedIndex == 8 || listBox4.SelectedIndex == 9 || listBox4.SelectedIndex == 10 || listBox4.SelectedIndex == 13 || listBox4.SelectedIndex == 14 || listBox4.SelectedIndex == 16)
            {
                /*A1.Text += '(';
                E2.Text += ')';
                H3.Text = listBox4.SelectedItem.ToString();*/
                if (ins4 == 5) H3.Text = listBox4.SelectedItem.ToString();
                else I3.Text = listBox4.SelectedItem.ToString();
                /*if (ins2 == 5)
                {
                    O3.Text += '(';
                    L3.Text += ')';
                }*/
                if (ins4 == 5) ; //G3.Text += 'X';
                else I3.Text += 'X';
                taul[0] = 1;
                //H3.Text = listBox4.SelectedItem.ToString();

            }
            else
            {
                /*if (listBox4.SelectedIndex == 4) H3.Text = "oikea/vasen";
                else if (listBox4.SelectedIndex == 2) H3.Text = "oikea-vasen";
                else H3.Text = listBox4.SelectedItem.ToString();*/
                taul[8] = 1;
                switch (listBox4.SelectedIndex)
                {
                    case 1:
                        I3.Text = "+";
                        break;
                    case 2:
                        I3.Text = "-";
                        break;
                    case 3:
                        I3.Text = "*";
                        break;
                    case 4:
                        I3.Text = "/";
                        break;
                    case 12:
                        I3.Text = textBox4.Text.ToString();
                        //if (ins4 != 5) L3.Text += '+';
                        break;
                }
            }

            kaava += H3.Text;
            kaava += Q3.Text;
            kaava += G3.Text;
            kaava += P3.Text;
            kaava += F3.Text;
            kaava += O3.Text;
            kaava += E3.Text;
            kaava += N3.Text;
            kaava += A3.Text;
            kaava += M3.Text;
            kaava += B3.Text;
            kaava += L3.Text;
            kaava += C3.Text;
            kaava += K3.Text;
            kaava += D3.Text;
            kaava += J3.Text;
            kaava += I3.Text;

            textBox29.Text = kaava;
        }
        private TimeSpan Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            Time += TimeSpan.FromMilliseconds(100);

            if (myPa.Xspeed > 0)
            {
                if (myPa.Xpal < C.ActualWidth - myPa.Xspeed)
                {
                    myPa.Xpal += myPa.Xspeed; 
                }
                else
                {
                    if (aste < 90) alpha = 90 - aste;
                    else alpha = aste - 270;
                    beta = alpha;
                    if(aste<90) aste += ( beta * 2); 
                    else aste -= (beta * 2);
                    if (aste > 360) aste -= 360;
                    if (aste < 0) aste += 360;
                    myPa.Xpal -= myPa.Xspeed;
                }
            }
            else if (myPa.Xspeed < 0)
            {
                if (myPa.Xpal > 0 - myPa.Xspeed)
                {
                    myPa.Xpal += myPa.Xspeed;
                }
                else
                {
                    if (aste < 180) alpha = aste - 90;
                    else alpha = 270 - aste;
                    beta = alpha;
                    if(aste<180) aste -= (beta * 2);
                    else   aste += (beta * 2);
                    if (aste > 360) aste -= 360;
                    if (aste < 0) aste += 360;
                    myPa.Xpal -= myPa.Xspeed;
                }
            }
            if (myPa.Yspeed > 0)
            {
                if (myPa.Ypal < C.ActualHeight - myPa.Yspeed)
                {
                    myPa.Ypal += myPa.Yspeed;
                }
                else
                {
                    if (aste < 90) alpha = aste;
                    else alpha = 180 - aste;
                    beta = alpha;
                    if (aste < 90) aste -= (beta * 2);
                    else aste += (beta * 2);
                    if (aste > 360) aste -= 360;
                    if (aste < 0) aste += 360;
                    myPa.Ypal -= myPa.Yspeed;
                }
            }
            else if (myPa.Yspeed < 0)
            {
                if (myPa.Ypal > 0 - myPa.Yspeed)
                {
                    myPa.Ypal += myPa.Yspeed;
                }
                else
                {
                    if (aste < 270) alpha = aste - 180;
                    else alpha = 360 - aste;
                    beta = alpha;
                    if (aste < 270) aste -= (beta * 2);
                    else aste += (beta * 2);
                    if (aste > 360) aste -= 360;
                    if (aste < 0) aste += 360;
                    myPa.Ypal -= myPa.Yspeed;
                }
            }

            Canvas.SetTop(myEl, myPa.Ypal - (myEl.ActualHeight) / 2); 
            Canvas.SetLeft(myEl, myPa.Xpal - (myEl.ActualWidth) / 2);

            if (laskuri++ > 100)
            {
                for (int x3 = 0; x3 < 6; x3++)
                {
                    for (int kai = 0; kai < 1200; kai++)
                    {
                        double xh = Canvas.GetLeft(el[x3, kai]);
                        double yh = Canvas.GetTop(el[x3, kai]);
                        if ((yh > myPa.Ypal - 10 && yh < myPa.Ypal + 10) && (xh > myPa.Xpal - 10 && xh < myPa.Xpal + 10))
                        {
                            Canvas.SetTop(el[x3, kai], 0);
                            Canvas.SetLeft(el[x3, kai], 0);
                            myPa.Nopeus *= 0.9;
                            if (myPa.Nopeus < 0.5) myPa.Nopeus = 0.5;
                        }

                    }
                }
                laskuri = 0;
            }

            myPa.Xspeed = (8 * Math.Cos(DegreeToRadian(aste)));
            myPa.Yspeed = (8 * Math.Sin(DegreeToRadian(aste)));

            if (liike == false) myPa.Nopeus = 0;

            myPa.Xspeed = (8 * Math.Cos(DegreeToRadian(aste)))/8 * myPa.Nopeus;
            myPa.Yspeed = (8 * Math.Sin(DegreeToRadian(aste)))/8 * myPa.Nopeus;
                       
            if (Keyboard.IsKeyDown(Key.Up))
            { 
                if (myPa.Nopeus <= 0.1) myPa.Nopeus = 0.1;
                myPa.Nopeus *= 1.1;
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                myPa.Nopeus *= 0.9;
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                aste += 5;
                if (aste > 360) aste -= 360;
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                aste -= 5;
                if (aste < 0) aste += 360;
            }
            if (myPa.Nopeus > 10) myPa.Nopeus = 10;
            if (myPa.Nopeus < 0.1) myPa.Nopeus = 0;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        private void Piirra(int t,double x2,double y2,int rot, int mon, int vaihda, int xr, int xr2, double zoom)
        {
            int t2 = 0, t3 = 0, t4 = 0;
            int x3 = 200, xx=0,xxx=0,yy=0,yyy=0;
            double x5 =0, y5=0, x4 = 0, y4 = 0;
            double xd, x=0, y=0;
            double x0=0, x1=0, y0=0, y1=0;

            if (xr < -400) xr = -400;
            if (xr2 > 400) xr2 = 400;
                       
            li1.X1 = 0;
            li1.X2 = C.Width;// * zoom;
            li1.Y1 = C.Height / 2; //* zoom;
            li1.Y2 = C.Height / 2; //* zoom;
            li2.X1 = C.Width / 2; //* zoom;
            li2.X2 = C.Width / 2; //* zoom;
            li2.Y1 = 0;
            li2.Y2 = C.Height; // * zoom;

            for (y = 0, xd = (double)xr; xd < (double)xr2; xd += 0.1) 
                {                                                       
                    xxx = (int)(Math.Round(xd)/*xd/* * 2*/); // y suunta
                    x = xd;
                    x3 = xxx+400;
                if (x3 < 0 || x3 >= 1200) x3 = 1199;
                    el[mon,x3].Stroke = System.Windows.Media.Brushes.Red;
                    el[mon, x3].Width = 4;
                    el[mon, x3].Height = 4;

               

                switch (rot)
                    {
                        case 0:
                        if (vaihda == 0)
                        {
                            y5 = 0 + y - (el[mon, x3].ActualHeight) / 2 + y2;
                            x5 = 0 + x - (el[mon, x3].ActualWidth) / 2 + x2; 
                        }
                        else if (vaihda == 1)
                        {
                            x5 = 0 + y - (el[mon, x3].ActualHeight) / 2 + y2; 
                            y5 = 0 + x - (el[mon, x3].ActualWidth) / 2 + x2; 
                        }
                        break;
                        case 1:
                        if (vaihda == 0)
                        {
                            y5 = 0 - y - (el[mon, x3].ActualHeight) / 2 + y2; 
                            x5 = 0 + x - (el[mon, x3].ActualWidth) / 2 + x2; 
                        }
                        else if (vaihda == 1)
                        {
                            x5 = 0 - y - (el[mon, x3].ActualHeight) / 2 + y2; 
                            y5 = 0 + x - (el[mon, x3].ActualWidth) / 2 + x2; 
                        }
                        break;
                        case 2:
                        if (vaihda == 0)
                        {
                            y5 = 0 - y - (el[mon, x3].ActualHeight) / 2 + y2; 
                            x5 = 0 - x - (el[mon, x3].ActualWidth) / 2 + x2; 
                        }
                        else if (vaihda == 1)
                        {
                            x5 = 0 - y - (el[mon, x3].ActualHeight) / 2 + y2; 
                            y5 = 0 - x - (el[mon, x3].ActualWidth) / 2 + x2; 
                        }
                        break;
                        case 3:
                        if (vaihda == 0)
                        {
                            y5 = 0 + y - (el[mon, x3].ActualHeight) / 2 + y2; 
                            x5 = 0 - x - (el[mon, x3].ActualWidth) / 2 + x2; 
                        }
                        else if(vaihda == 1)
                        {
                            x5 = 0 + y - (el[mon, x3].ActualHeight) / 2 + y2; 
                            y5 = 0 - x - (el[mon, x3].ActualWidth) / 2 + x2; 
                        }
                        break;
                    }

                x0 = x5 * zoom - (C.Width / 2 * zoom - C.Width / 2);
                y0 = y5 * zoom - (C.Height / 2 * zoom - C.Height / 2);
                x1 = x4 * zoom - (C.Width / 2 * zoom - C.Width / 2);
                y1 = y4 * zoom - (C.Height / 2 * zoom - C.Height / 2);

                if (xxx > xr && xxx < xr2 && x0 > -999 && x0 < 999 && y0 > -999 && y0 < 999)
                {
                    el[mon, x3].Stroke = System.Windows.Media.Brushes.Red;
                    Canvas.SetTop(el[mon, x3], y0);
                    Canvas.SetLeft(el[mon, x3], x0); 
                }
                else
                {
                    Canvas.SetTop(el[mon, x3], 0); 
                    Canvas.SetLeft(el[mon, x3], 0);
                }
                                                 
                if (xx!=xxx || yy!=yyy) 
                {
                    if (xxx > xr && xxx < xr2 && x0 > -999 && x0 < 999 && y0 > -999 && y0 < 999 && x1 > -999 && x1 < 999 && y1 > -999 && y1 < 999)
                    {
                        li[mon, x3].X1 = x0;
                        li[mon, x3].X2 = x1;
                        li[mon, x3].Y1 = y0;
                        li[mon, x3].Y2 = y1;
                    }
                    else
                    {
                        li[mon, x3].X1 = 0;
                        li[mon, x3].X2 = 0;
                        li[mon, x3].Y1 = 0;
                        li[mon, x3].Y2 = 0;
                    }
                    x4 = x5;
                    y4 = y5;
                    xx = (int)xxx;
                    yy = (int)yyy;
                }
                
                t = ins;
                    switch (listBox.SelectedIndex)
                    {
                        case 0: break;
                        case 1: t = 1; break;
                        case 2: t = 2; break;
                        case 3: t = 3; break;
                        case 4: t = 4; break;
                        case 5: y = Suorita(xd, 5, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture));                        
                        break; 
                        case 6: y = Suorita(xd, 6, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); break; 
                        case 7: y = Suorita(xd, 7, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); break;
                        case 8: y = Suorita(xd, 8, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); break;
                        case 9: y = Suorita(xd, 9, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); break;
                        case 10: y = Suorita(xd, 10, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); break;
                        case 11: t = 5; break;  
                        case 12: t = 6; break;  
                        case 13: y = Suorita(xd, 11, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); break;
                        case 14: y = Suorita(xd, 12, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); break;
                        case 15: y = Suorita(xd, 13, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); break;
                        case 16: y = Suorita(xd, 14, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); break;
                }
                    if (listBox1.SelectedIndex == 5 || listBox1.SelectedIndex == 6 || listBox1.SelectedIndex == 7 || listBox1.SelectedIndex == 8 || listBox1.SelectedIndex == 9 || listBox1.SelectedIndex == 10 || listBox1.SelectedIndex == 13 || listBox1.SelectedIndex == 14 || listBox1.SelectedIndex == 15 || listBox1.SelectedIndex == 16)
                    {
                        y = F(t, xd, listBox1.SelectedIndex, (double)y, double.Parse(textBox1.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture)); 
                        t2 = ins2;
                    }
                    else t2 = T(listBox1.SelectedIndex);
                if (listBox2.SelectedIndex == 5 || listBox2.SelectedIndex == 6 || listBox2.SelectedIndex == 7 || listBox2.SelectedIndex == 8 || listBox2.SelectedIndex == 9 || listBox2.SelectedIndex == 10 || listBox2.SelectedIndex == 13 || listBox2.SelectedIndex == 14 || listBox2.SelectedIndex == 15 || listBox2.SelectedIndex == 16)
                {
                    if (t == 6)
                    {
                        y = F(t2, xd, listBox2.SelectedIndex, double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture), double.Parse(textBox2.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                    }
                    else y = F(t2, xd, listBox2.SelectedIndex, (double)y, double.Parse(textBox2.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                    t3 = ins3;
                }
                else if (listBox2.SelectedIndex == 12) y = F2(t2, double.Parse(textBox2.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture), listBox2.SelectedIndex, (double)y);
                else t3 = T(listBox2.SelectedIndex);
                    if (listBox3.SelectedIndex == 5 || listBox3.SelectedIndex == 6 || listBox3.SelectedIndex == 7 || listBox3.SelectedIndex == 8 || listBox3.SelectedIndex == 9 || listBox3.SelectedIndex == 10 || listBox3.SelectedIndex == 13 || listBox3.SelectedIndex == 14 || listBox3.SelectedIndex == 15 || listBox3.SelectedIndex == 16)
                    {
                        if (t2 == 6)
                        {
                            y = F(t3, xd, listBox3.SelectedIndex, double.Parse(textBox1.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture), double.Parse(textBox3.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                        }
                        else y = F(t3, xd, listBox3.SelectedIndex, (double)y, double.Parse(textBox3.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                    t4 = ins4;
                    }
                    else if (listBox3.SelectedIndex == 12) y = F2(t3, double.Parse(textBox3.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture), listBox3.SelectedIndex, (double)y);
                    else t4 = T(listBox3.SelectedIndex);
                    if (listBox4.SelectedIndex == 5 || listBox4.SelectedIndex == 6 || listBox4.SelectedIndex == 7 || listBox4.SelectedIndex == 8 || listBox4.SelectedIndex == 9 || listBox4.SelectedIndex == 10 || listBox4.SelectedIndex == 13 || listBox4.SelectedIndex == 14 || listBox4.SelectedIndex == 15 || listBox4.SelectedIndex == 16)
                    {
                        if (t3 == 6)
                        {
                            y = F(t4, xd, listBox4.SelectedIndex, double.Parse(textBox2.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture), double.Parse(textBox4.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                        }
                        else y = F(t4, xd, listBox4.SelectedIndex, (double)y, double.Parse(textBox4.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                    }
                    else if (listBox4.SelectedIndex == 12) y = F2(t4, double.Parse(textBox4.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture), listBox4.SelectedIndex, (double)y);
                }
        }

        
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void listBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void listBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           for (int x3 = 0; x3 < 6; x3++)
            {
                for (int kai = 0; kai < 1200; kai++)
                {
                    Canvas.SetTop(el[x3, kai], 0);
                    Canvas.SetLeft(el[x3, kai], 0);
                    li[x3,kai].X1 = 0;
                    li[x3,kai].X2 = 0;
                    li[x3,kai].Y1 = 0;
                    li[x3,kai].Y2 = 0;
                }
            }
        }

        private int T(int arvo)
        {
            int t3 = 5;
            switch (arvo)
            {
                case 0: break;
                case 1: t3 = 1; break;
                case 2: t3 = 2; break;
                case 3: t3 = 3; break;
                case 4: t3 = 4; break;
                case 11: t3 = 5; break;
                case 12: t3 = 6; break;
            }
            return t3;
        }

        private double F(int t, double xd, int index, double y, double apu)
        {
            switch (index)
            {
                case 5: index = 5; break;
                case 6: index = 6; break;
                case 7: index = 7; break;
                case 8: index = 8; break;
                case 9: index = 9; break;
                case 10: index = 10; break;
                case 13: index = 11; break;
                case 14: index = 12; break;
                case 15: index = 13; break;
                case 16: index = 14; break;
            }
            if (t == 1) y += Suorita(xd, index, apu); // y+=
            else if (t == 2) y -= Suorita(xd, index, apu);
            else if (t == 3) y *= Suorita(xd, index, apu);
            else if (t == 4) y /= Suorita(xd, index, apu) == 0 ? 1 : (int)Suorita(xd, index, apu);
            else if (t == 5) y = Suorita(y, index, apu);
            else if (t == 7) y = (int)Suorita(xd, index, apu);
            return y;
        }

        private double F2(int t, double nxd, int index, double y)
        {

            if (t == 1) y += -nxd;
            else if (t == 2) y -= -nxd;
            else if (t == 3) y *= nxd;
            else if (t == 4) y /= nxd == 0 ? 1 : nxd;
            else y = 0;
            return y;
        }


        private double Suorita(double s, int toiminto, double apu)
        {
            switch (toiminto)
            {
                case 5:
                    return -joo.Paraabeli(s, apu);
                    break;
                case 6:
                    return -joo.Pallo(s, 100)*(apu/3);
                    break;
                case 7:
                    if (s + 0.1 != 0) return -(1.0f / ((s + 0.1) / 50.0f)) * 50.0f;
                    else return 1;
                    break;
                case 8:
                    return -Math.Sin(s/* * apu*/) * apu;
                    break;
                case 9:
                    return -Math.Cos(s * apu) * apu;
                    break;
                case 10:
                    return -Math.Tan(s * apu) * apu;
                    break;
                case 11:
                    return -joo.Log10(s / 100.0f) * 100.0f;
                    break;
                case 12:
                    return -s * apu;
                    break;
                case 13:
                    if (s > -apu && s < apu) return -apu;
                    else return 0;
                    break;
                case 14:
                    return -joo.Paraabeli(apu, s); ;
                    break;
            }
            return s;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int ee;
            Int32.TryParse(textBox12.Text, out ee);
            if (!(ee == 0 || ee == 1 || ee == 2 || ee == 3 || ee == 4 || ee == 5)) ee = 0;

            fun[ee].Sel[0] = listBox.SelectedIndex;
            fun[ee].Sel[1] = listBox1.SelectedIndex;
            fun[ee].Sel[2] = listBox2.SelectedIndex;
            fun[ee].Sel[3] = listBox3.SelectedIndex;
            fun[ee].Sel[4] = listBox4.SelectedIndex;

            int a = 0;
            
            fun[ee].Num[0] = double.Parse(textBox.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            fun[ee].Num[1] = double.Parse(textBox1.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            fun[ee].Num[2] = double.Parse(textBox2.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            fun[ee].Num[3] = double.Parse(textBox3.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            fun[ee].Num[4] = double.Parse(textBox4.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture);

            a = 0;
            int c = 0;
            int b = 0;
            int f = 0;
            int g = 0;
            int h = 0;
            double i = 1;
            //string kaava = "";

            Kaava();
            fun[ee].Kaava = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);

            switch (ee)
            {
                case 0:
                    CB.Items[0] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 0;
                    break;
                case 1:
                    CB.Items[1] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 1;
                    break;
                case 2:
                    CB.Items[2] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 2;
                    break;
                case 3:
                    CB.Items[3] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 3;
                    break;
                case 4:
                    CB.Items[4] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 4;
                    break;
                case 5:
                    CB.Items[5] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 5;
                    break;
            }

            Int32.TryParse(textBox6.Text, out a);
            Int32.TryParse(textBox7.Text, out b);
            Int32.TryParse(textBox8.Text, out c);
            Int32.TryParse(textBox25.Text, out f);
            Int32.TryParse(textBox27.Text, out g);
            Int32.TryParse(textBox27_Copy5.Text, out h);
            i = double.Parse(textBox28.Text, System.Globalization.CultureInfo.InvariantCulture);
            if (!(f == 0 || f == 1)) f = 0;

            fun[ee].X = a;
            fun[ee].Y = b;
            fun[ee].Vaihda = c;
            fun[ee].Rot = f;
            fun[ee].Xr = g;
            fun[ee].Xr2 = h;
            fun[ee].Zoom = i;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int ee;
            Int32.TryParse(textBox12.Text, out ee);
            if (!(ee == 0 || ee == 1 || ee == 2 || ee == 3 || ee == 4 || ee == 5)) ee = 0;
            
            listBox.SelectedIndex = fun[ee].Sel[0];
            listBox1.SelectedIndex = fun[ee].Sel[1];
            listBox2.SelectedIndex = fun[ee].Sel[2];
            listBox3.SelectedIndex = fun[ee].Sel[3];
            listBox4.SelectedIndex = fun[ee].Sel[4];

            
            textBox.Text = fun[ee].Num[0].ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox1.Text = fun[ee].Num[1].ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox2.Text = fun[ee].Num[2].ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox3.Text = fun[ee].Num[3].ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox4.Text = fun[ee].Num[4].ToString(System.Globalization.CultureInfo.InvariantCulture);

            textBox29.Text = fun[ee].Kaava.ToString(System.Globalization.CultureInfo.InvariantCulture);

            switch(ee)
            {
                case 0:
                    CB.Items[0] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 0;
                    break;
                case 1:
                    CB.Items[1] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 1;
                    break;
                case 2:
                    CB.Items[2] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 2;
                    break;
                case 3:
                    CB.Items[3] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 3;
                    break;
                case 4:
                    CB.Items[4] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 4;
                    break;
                case 5:
                    CB.Items[5] = textBox29.Text.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    CB.SelectedIndex = 5;
                    break;
            }

            textBox6.Text= fun[ee].X.ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox7.Text= fun[ee].Y.ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox8.Text= fun[ee].Vaihda.ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox25.Text= fun[ee].Rot.ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox27.Text= fun[ee].Xr.ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox27_Copy5.Text= fun[ee].Xr2.ToString(System.Globalization.CultureInfo.InvariantCulture);
            textBox28.Text= fun[ee].Zoom.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            int ee;
            ee = 0;
            textBox12.Text = ee.ToString();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int ee;
            ee = 1;
            textBox12.Text = ee.ToString();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            int ee;
            ee = 2;
            textBox12.Text = ee.ToString();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            int ee;
            ee = 3;
            textBox12.Text = ee.ToString();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            int ee;
            ee = 4;
            textBox12.Text = ee.ToString();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            int ee;
            ee = 5;
            textBox12.Text = ee.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Näytä();
        }

        private void Näytä()
        {
            int ee;
            Int32.TryParse(textBox12.Text, out ee);
            if (!(ee == 0 || ee == 1 || ee == 2 || ee == 3 || ee == 4 || ee == 5)) ee = 0;
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int f = 0;
            int g = 0;
            int h = 0;
            double i = 0;

            Int32.TryParse(textBox6.Text, out a);
            Int32.TryParse(textBox7.Text, out b);
            Int32.TryParse(textBox8.Text, out c);
            Int32.TryParse(textBox25.Text, out f);
            Int32.TryParse(textBox27.Text, out g);
            Int32.TryParse(textBox27_Copy5.Text, out h);
            i = double.Parse(textBox28.Text, System.Globalization.CultureInfo.InvariantCulture);
            if (!(f == 0 || f == 1)) f = 0;

            Piirra(listBox.SelectedIndex, a + C.Width/2/*(int)X*/, b + C.Height/2/*(int)Y*/, c, ee, f, g, h, i);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            if (liike == true) liike = false;
            else liike = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ins == 1)
            {
                ins = 5;
                t1.Text = "päällä";
            }
            else
            {
                ins = 1;
                t1.Text = "pois";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ins2 == 1)
            {
                ins2 = 5;
                t2.Text = "päällä";
            }
            else
            {
                ins2 = 1;
                t2.Text = "pois";
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            textBox28.Text = S.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
            Näytä();
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ee;
            ee = CB.SelectedIndex;
            textBox12.Text = ee.ToString();
        }

        private void nol_Click(object sender, RoutedEventArgs e)
        {
            listBox.SelectedIndex = 1;
            listBox1.SelectedIndex = 1;
            listBox2.SelectedIndex = 1;
            listBox3.SelectedIndex = 1;
            listBox4.SelectedIndex = 1;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ins3 == 1)
            {
                ins3 = 5;
                t3.Text = "päällä";
            }
            else
            {
                ins3 = 1;
                t3.Text = "pois";
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (ins4 == 1)
            {
                ins4 = 5;
                t4.Text = "päällä";
            }
            else
            {
                ins4 = 1;
                t4.Text = "pois";
            }
        }
                
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TranslateTransform transform = new TranslateTransform();
            Y += Height - M1;
            X += Width - M2;

            transform.X = X; 
            transform.Y = Y;
            
            if(400+X>0) C.Width = 400+X;
            if(400+Y>0) C.Height = 400+Y;
            
            this.ohje.RenderTransform = transform;
            this.button9.RenderTransform = transform;
            this.listBox.RenderTransform = transform;
            this.listBox1.RenderTransform = transform;
            this.listBox2.RenderTransform = transform;
            this.listBox3.RenderTransform = transform;
            this.listBox4.RenderTransform = transform;
            this.button.RenderTransform = transform;
            this.textBox.RenderTransform = transform;
            this.textBox1.RenderTransform = transform;
            this.textBox2.RenderTransform = transform;
            this.textBox3.RenderTransform = transform;
            this.textBox4.RenderTransform = transform;
            this.button1.RenderTransform = transform;
            this.button2.RenderTransform = transform;
            this.textBox6.RenderTransform = transform;
            this.textBox7.RenderTransform = transform;
            this.textBox8.RenderTransform = transform;
            //this.button3.RenderTransform = transform;
            //this.button4.RenderTransform = transform;
            //this.textBox12.RenderTransform = transform;
            //this.button5.RenderTransform = transform;
            //this.button6.RenderTransform = transform;
            //this.button7.RenderTransform = transform;
            //this.button8.RenderTransform = transform;
            this.textBox25.RenderTransform = transform;
            this.textBlock.RenderTransform = transform;
            this.textBlock1.RenderTransform = transform;
            this.textBlock2.RenderTransform = transform;
            this.textBlock3.RenderTransform = transform;
            this.textBox27.RenderTransform = transform;
            this.textBox27_Copy5.RenderTransform = transform;
            this.textBlock4.RenderTransform = transform;
            this.textBlock4_Copy.RenderTransform = transform;
            this.textBlock5.RenderTransform = transform;
            this.textBox28.RenderTransform = transform;
            this.Piirrä.RenderTransform = transform;
            this.textBox29.RenderTransform = transform;
            this.CB.RenderTransform = transform;
            /*this.A1.RenderTransform = transform;
            this.A2.RenderTransform = transform;
            this.B1.RenderTransform = transform;
            this.B2.RenderTransform = transform;
            this.C1.RenderTransform = transform;
            this.C2.RenderTransform = transform;
            this.D1.RenderTransform = transform;
            this.D2.RenderTransform = transform;
            this.E1.RenderTransform = transform;
            this.E2.RenderTransform = transform;*/
            this.button10.RenderTransform = transform;
            /*this.A3.RenderTransform = transform;
            this.B3.RenderTransform = transform;
            this.C3.RenderTransform = transform;
            this.D3.RenderTransform = transform;
            this.E3.RenderTransform = transform;
            this.F3.RenderTransform = transform;
            this.G3.RenderTransform = transform;
            this.H3.RenderTransform = transform;
            this.I3.RenderTransform = transform;
            this.J3.RenderTransform = transform;
            this.K3.RenderTransform = transform;
            this.L3.RenderTransform = transform;
            this.M3.RenderTransform = transform;
            this.N3.RenderTransform = transform;
            this.O3.RenderTransform = transform;
            this.P3.RenderTransform = transform;
            this.Q3.RenderTransform = transform;*/
            this.Inside1.RenderTransform = transform;
            this.Inside2.RenderTransform = transform;
            this.Inside3.RenderTransform = transform;
            this.Inside4.RenderTransform = transform;
            this.t1.RenderTransform = transform;
            this.t2.RenderTransform = transform;
            this.t3.RenderTransform = transform;
            this.t4.RenderTransform = transform;
            /*this.kaava0.RenderTransform = transform;
            this.kaava1.RenderTransform = transform;
            this.kaava2.RenderTransform = transform;
            this.kaava3.RenderTransform = transform;
            this.kaava4.RenderTransform = transform;
            this.kaava5.RenderTransform = transform;*/
            this.S.RenderTransform = transform;
            this.textBox12.RenderTransform = transform;
            this.nol.RenderTransform = transform;
            this.val.RenderTransform = transform;
            this.val0.RenderTransform = transform;

            Näytä();

            M1 = Height;
            M2 = Width;
            //900 1500
        }
    }
}

