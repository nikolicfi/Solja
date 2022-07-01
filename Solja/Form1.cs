namespace Solja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random r = new Random();
        List<Soljica> arrSolje = new List<Soljica>();
        int x, Dx;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point o = new Point(e.X, e.Y);
            Color Boja = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            x = r.Next(10, 100);
            Soljica solja = new Soljica(o, x, Boja);
            arrSolje.Add(solja);
            Dx = r.Next(10, 50);
            solja.Start(Dx);
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < arrSolje.Count(); i++)
            {
                if (arrSolje[i].End(ClientRectangle.Width - arrSolje[i].A))
                {
                    arrSolje[i].Stop();
                }
                else arrSolje[i].Pomeranje();
            }
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < arrSolje.Count(); i++)
            {
                arrSolje[i].Crtaj(e.Graphics);
            }
        }


    }
}