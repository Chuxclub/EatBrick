using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;

namespace EatBrick
{
    public partial class EatbrickGUI : Form
    {
        private Conception.t_eatbrick eatbrick;
        private bool running;
        

        public EatbrickGUI()
        {
            InitializeComponent();
            running = true;
        }

        private void bntNewgame_Click(object sender, EventArgs e)
        {
            if(loadNiveau.ShowDialog() == DialogResult.OK)
            {
                string filename = loadNiveau.FileName;
                try { 
                    eatbrick = Utils.make_eatbrick(filename);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erreur: " + ex.ToString(), "Error new game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void bntDemo_Click(object sender, EventArgs e)
        {
            try { 
                eatbrick = Utils.make_eatbrick_demo();
            }
            catch(Exception mfe) {
                Conception.t_pad pad = new Conception.t_pad(new FSharpRef<double>(Constantes.SCREEN_WIDTH/2) , new FSharpRef<int>(Constantes.PAD_DEFAULT_SIZE));
                Conception.t_ball ball = Utils.make_ball(Constantes.SCREEN_WIDTH/2, Constantes.SCREEN_HEIGHT/2);
                FSharpList<Conception.t_ball>  listBall = FSharpList<Conception.t_ball>.Cons(ball, FSharpList<Conception.t_ball>.Empty);
                eatbrick = new Conception.t_eatbrick(pad,
                        new FSharpRef<FSharpList<Conception.t_ball>>(listBall),
                        new FSharpRef<FSharpList<Conception.t_brick>>(FSharpList<Conception.t_brick>.Empty),
                        new FSharpRef<int>(123));
            }
        }

        private void globalTimer_Tick(object sender, EventArgs e)
        {
            gamepanel.Invalidate();

            if (eatbrick != null && running) { 
                lblScore.Text = "Score: " + padding(eatbrick.score.contents);
                lblNbBall.Text = "Nb balle(s): " + eatbrick.balls.contents.Length;
                lblNbBricks.Text = "Nb brique(s): " + eatbrick.bricks.contents.Length;
                lblTaillePad.Text = "Taille pad: " + eatbrick.pad.width.contents;

                // Callbacks.animate(eatbrick);

                int nbBall = eatbrick.balls.contents.Length;

                foreach(Conception.t_ball ball in eatbrick.balls.contents)
                {
                    Callbacks.animate_ball(eatbrick, ball);
                    Collision.bounce_bound_screen(ball);
                    Collision.collision_ball_pad(eatbrick, ball);
                    Collision.collision_ball_bricks(ball, eatbrick.bricks.contents, eatbrick);
                   
                }
                eatbrick.balls.contents = Callbacks.remove_dead_balls(eatbrick.balls.contents);


                if(Callbacks.check_gameover(eatbrick))
                {
                    running = false;
                    try
                    {
                        MessageBox.Show("Fin de partie avec " + eatbrick.score.contents + " points");
                        running = true;
                    }
                    finally
                    {
                        eatbrick = null;
                    }

                }

                speedBar.Value = Math.Max(Math.Min(600, (int)(Constantes.COEF_SPEED.contents * 10.0)), 0);
            }
        }

        private string padding(int contents)
        {
            string res = "" + contents;
            while(res.Length < 3)
            {
                res = "0" + res;
            }
            return res;
        }


        private void gamepanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;



            // petit garde-fou
            if (eatbrick == null) {
                Font font = new Font(SystemFonts.DefaultFont.FontFamily, 42);
                g.DrawString("Run new game!", font, Brushes.Green, ClientRectangle,sf);
                return;
            }

            if(!running)
            {
                Font font = new Font(SystemFonts.DefaultFont.FontFamily, 42);
                g.DrawString("Paused!", font, Brushes.Green, ClientRectangle, sf);
                return;
            }

            
            int sizeW = gamepanel.ClientSize.Width;
            int sizeH = gamepanel.ClientSize.Height;

            Pen pensalmon = Pens.Salmon;

            
            // ======================= BRICKS
            FSharpList<Conception.t_brick> bricks = eatbrick.bricks.contents;
            foreach(Conception.t_brick brick in bricks)
            {
                double x = brick.pos.x.contents;
                double y = brick.pos.y.contents;


                RectangleF r = new RectangleF((float)x, (float)y , Constantes.BRICK_WIDTH, Constantes.BRICK_HEIGHT);
                if(brick.bkind.contents != Conception.t_brick_kind.AIR) { 
                    g.FillRectangle(color_brick(brick.bkind.contents), r);
                    g.DrawRectangle(Pens.Black, r.Left, r.Top, r.Width, r.Height);
                }
            }

            // ========================= BALLS
            FSharpList<Conception.t_ball> balls = eatbrick.balls.contents;
            foreach(Conception.t_ball ball in balls)
            {
                float size = (float)Utils.ball_size(ball);
                RectangleF r = new RectangleF(((float)ball.pos.x.contents) - (size / 2), ((float)ball.pos.y.contents) - (size / 2), size, size);
                g.FillEllipse(Brushes.LightBlue, r);
                g.DrawEllipse(Pens.Black, r);
            }

            // =============================== PAD

            Conception.t_pad pad = eatbrick.pad;
            float widthPad = (float)pad.width.contents;
            float heightPad = (float)Constantes.BRICK_HEIGHT;
            float xPad = (float)pad.loc.contents;
            float yPad = (float)(Constantes.PAD_INDEX_ROW * Constantes.BRICK_HEIGHT);
            RectangleF rectPad = new RectangleF( xPad - (widthPad/2), yPad,  widthPad, heightPad);
            g.FillRectangle(Brushes.Red, rectPad);
            g.DrawRectangle(Pens.Black, rectPad.Left, rectPad.Top, rectPad.Width, rectPad.Height);
            for(int i = 1;i < 5; i++)
            {
                float delta = (float) rectPad.Left + (i * pad.width.contents/5);
                g.DrawLine(Pens.Black, delta, rectPad.Top, delta, rectPad.Bottom);
            }
        }
        

        private Brush color_brick(Conception.t_brick_kind contents)
        {
            if (contents.IsAIR) return Brushes.White;
            else if (contents.IsSIMPLE) return Brushes.LightGray;
            else if (contents.IsDOUBLE) return Brushes.DarkGray;
            else if (contents.IsTRIPLE) return Brushes.Gray;
            else if (contents.IsSOLID) return Brushes.Black;
            else return Brushes.Yellow;
        }

        private void gamepanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Callbacks.leftclick();
            else
                Callbacks.rightclick();
        }

        private void gamepanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(eatbrick != null)
            {
                eatbrick.pad.loc.contents = e.X;
            }
        }

        private void speedBar_ValueChanged(object sender, EventArgs e)
        {
            Constantes.COEF_SPEED.contents = speedBar.Value / 10.0;
        }
    }
}
