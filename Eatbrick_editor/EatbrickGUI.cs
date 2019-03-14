using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Eatbrick_editor;


namespace EatBrick
{

    public partial class EatbrickGUI : Form
    {
        List<Brick> bricks;
        List<RadioButton> selbkind;

        RadioButton current = null;

        bool isMouseDown = false;

        public EatbrickGUI()
        {
            InitializeComponent();
            bricks = new List<Brick>();
            initBricksKind();

           
        }

        private void initBricksKind()
        {
            selbkind = new List<RadioButton>();
            foreach(BrickKind bk in Enum.GetValues(typeof(BrickKind)))
            {
                
                RadioButton rb = new RadioButton();
                rb.Text = bk.ToString();
                rb.BackColor = color_brick(bk);
                rb.Tag = bk;
                selbkind.Add(rb);
                layout.Controls.Add(rb);
                rb.CheckedChanged += Rb_CheckedChanged;
            }
            selectBrickKind.AutoSize = true;

            selbkind[0].Select();
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton s = (RadioButton)sender;
            if (s.Checked)
            {
                current = (RadioButton)sender;
                Console.WriteLine("TYPE BRICK: " + current.Text);
            }
        }

        private void bntNewgame_Click(object sender, EventArgs e)
        {
            bricks = new List<Brick>();
        }

        private void globalTimer_Tick(object sender, EventArgs e)
        {
            gamepanel.Refresh();
//            gamepanel.Update();
//            gamepanel.Invalidate();
        }

        private void gamepanel_Move(object sender, EventArgs e)
        {

        }

        private Color color_brick(BrickKind kind)
        {
            switch (kind)
            {
                case BrickKind.AIR: return Color.Beige;
                case BrickKind.SIMPLE: return Color.LightGray;
                case BrickKind.DOUBLE: return Color.DarkGray;
                case BrickKind.TRIPLE: return Color.Gray;

                case BrickKind.NEWBALL: return Color.Gold;
                case BrickKind.MODIFBALL: return Color.Yellow;

                case BrickKind.PADINCR: return Color.DarkOrange;
                case BrickKind.PADDECR: return Color.Orange;
                case BrickKind.PADRESET: return Color.Goldenrod;

                case BrickKind.SOLID: return Color.Black;
            }
            return Color.Bisque;
        }

        private Brush color_brick(Brick brick)
        {
            return new SolidBrush(color_brick(brick.Kind));
        }

        private void gamepanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = Constantes.BRICK_WIDTH;
            int height = Constantes.BRICK_HEIGHT;

            int sizeW = gamepanel.ClientSize.Width;
            int sizeH = gamepanel.ClientSize.Height;

            Pen pensalmon = Pens.Salmon;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // =========================================================
            foreach(Brick brick in bricks)
            {
                int i = brick.Column * width;
                int j = brick.Row * height;
                RectangleF r = new RectangleF(i, j, width, height);
                g.FillRectangle(color_brick(brick), r);
            }
            // =========================================================
            for (int i = 0; i < sizeW; i += width)
            {
                g.DrawLine(pensalmon, i, 0, i, sizeH);
            }

            for (int j = 0; j < sizeH; j += height)
            {
                g.DrawLine(pensalmon, 0, j, sizeW, j);
            }

            for (int i = 0; i < sizeW; i += width)
            {
                for (int j = 0; j < sizeH; j += height)
                {
                    Font font = this.Font;
                    RectangleF r = new RectangleF(i, j, width, height);
                    g.DrawString("(" + (i/width) + ";" + (j/height) + ")", font, Brushes.Black, r, sf);
                }
            }
        }

        private void gamepanel_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void addBrick(int X, int Y)
        {
            int i = X / Constantes.BRICK_WIDTH;
            int j = Y / Constantes.BRICK_HEIGHT;

            Brick brick = bricks.Find(b => (b.Row == j && b.Column == i));
            if (brick == null)
            {
                Brick b = new Brick(i, j, (BrickKind)current.Tag);
                bricks.Add(b);
//                gamepanel.Update();
//                gamepanel.Refresh();
            }
        }

        public void delBrick(int X, int Y)
        {
            int i = X / Constantes.BRICK_WIDTH;
            int j = Y / Constantes.BRICK_HEIGHT;
            
            bricks.RemoveAll(b => (b.Row == j && b.Column == i));
        }


        private void gamepanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                addBrick(e.X, e.Y);
            }
            else if(e.Button == MouseButtons.Right)
            {
                delBrick(e.X, e.Y);
            }
        }

        private void gamepanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) { 
                isMouseDown = true;
                addBrick(e.X, e.Y);
            }
        }

        private void gamepanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = false;
            else if (e.Button == MouseButtons.Right)
                delBrick(e.X, e.Y);
        }

        private void loadLevel_Click(object sender, EventArgs e)
        {
            if(loadNiveauFromFile.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(loadNiveauFromFile.FileName);
                foreach(string line in lines)
                {
                    string[] brick_info = line.Split(' ');
                    int col = Int32.Parse(brick_info[0]);
                    int row = Int32.Parse(brick_info[1]);
                    int kind = Int32.Parse(brick_info[2]);

                    Brick b = new Brick(col, row, (BrickKind)(kind));
                    bricks.Add(b);
                }
            }
        }

        private void exportLevel_Click(object sender, EventArgs e)
        {
            if(exportNiveauToFile.ShowDialog() == DialogResult.OK)
            {

                Stream stream;
                if((stream = exportNiveauToFile.OpenFile()) != null)
                {
                    StreamWriter sw = new StreamWriter(stream);
                    Console.WriteLine("[");
                    foreach (Brick brick in bricks)
                    {
                        int index = Convert.ToInt32(brick.Kind);
                        string line = "" + brick.Column + " " + brick.Row + " " + index;
                        string linedebug = "   [| " + brick.Column + "; " + brick.Row + "; " + index + "|]";
                        sw.WriteLine(line);
                        Console.WriteLine(linedebug);
                    }
                    Console.WriteLine("]");
                    sw.Close();
                    stream.Close();
                }
            }

        }
    }
}
