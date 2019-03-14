namespace EatBrick
{
    partial class EatbrickGUI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bntNewgame = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.gamepanel = new System.Windows.Forms.PictureBox();
            this.globalTimer = new System.Windows.Forms.Timer(this.components);
            this.loadNiveau = new System.Windows.Forms.OpenFileDialog();
            this.bntDemo = new System.Windows.Forms.Button();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblNbBall = new System.Windows.Forms.Label();
            this.lblNbBricks = new System.Windows.Forms.Label();
            this.lblTaillePad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gamepanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // bntNewgame
            // 
            this.bntNewgame.Location = new System.Drawing.Point(12, 12);
            this.bntNewgame.Name = "bntNewgame";
            this.bntNewgame.Size = new System.Drawing.Size(107, 34);
            this.bntNewgame.TabIndex = 1;
            this.bntNewgame.Text = "Nouvelle Partie";
            this.bntNewgame.UseVisualStyleBackColor = true;
            this.bntNewgame.Click += new System.EventHandler(this.bntNewgame_Click);
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(501, 12);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(301, 38);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "Score: 000";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gamepanel
            // 
            this.gamepanel.BackColor = System.Drawing.Color.White;
            this.gamepanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamepanel.Location = new System.Drawing.Point(2, 53);
            this.gamepanel.Name = "gamepanel";
            this.gamepanel.Size = new System.Drawing.Size(800, 500);
            this.gamepanel.TabIndex = 4;
            this.gamepanel.TabStop = false;
            this.gamepanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamepanel_Paint);
            this.gamepanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gamepanel_MouseClick);
            this.gamepanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gamepanel_MouseMove);
            // 
            // globalTimer
            // 
            this.globalTimer.Enabled = true;
            this.globalTimer.Interval = 20;
            this.globalTimer.Tick += new System.EventHandler(this.globalTimer_Tick);
            // 
            // loadNiveau
            // 
            this.loadNiveau.DefaultExt = "cpe";
            this.loadNiveau.FileName = "loadNiveauFileDialog";
            this.loadNiveau.Filter = "Niveau Eatbrick|*.cpe|Tous les fichiers|*.*";
            this.loadNiveau.RestoreDirectory = true;
            this.loadNiveau.Title = "Nouvelle partie sur le fichier";
            // 
            // bntDemo
            // 
            this.bntDemo.Location = new System.Drawing.Point(125, 12);
            this.bntDemo.Name = "bntDemo";
            this.bntDemo.Size = new System.Drawing.Size(107, 34);
            this.bntDemo.TabIndex = 5;
            this.bntDemo.Text = "Demo";
            this.bntDemo.UseVisualStyleBackColor = true;
            this.bntDemo.Click += new System.EventHandler(this.bntDemo_Click);
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(808, 69);
            this.speedBar.Maximum = 600;
            this.speedBar.Name = "speedBar";
            this.speedBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.speedBar.Size = new System.Drawing.Size(45, 484);
            this.speedBar.TabIndex = 6;
            this.speedBar.TickFrequency = 20;
            this.speedBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.speedBar, "Change la vitesse du jeu");
            this.speedBar.Value = 10;
            this.speedBar.ValueChanged += new System.EventHandler(this.speedBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(808, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vitesse";
            // 
            // lblNbBall
            // 
            this.lblNbBall.AutoSize = true;
            this.lblNbBall.Location = new System.Drawing.Point(238, 23);
            this.lblNbBall.Name = "lblNbBall";
            this.lblNbBall.Size = new System.Drawing.Size(69, 13);
            this.lblNbBall.TabIndex = 8;
            this.lblNbBall.Text = "Nb balle(s): 0";
            // 
            // lblNbBricks
            // 
            this.lblNbBricks.AutoSize = true;
            this.lblNbBricks.Location = new System.Drawing.Point(343, 22);
            this.lblNbBricks.Name = "lblNbBricks";
            this.lblNbBricks.Size = new System.Drawing.Size(76, 13);
            this.lblNbBricks.TabIndex = 9;
            this.lblNbBricks.Text = "Nb brique(s): 0";
            // 
            // lblTaillePad
            // 
            this.lblTaillePad.AutoSize = true;
            this.lblTaillePad.Location = new System.Drawing.Point(460, 22);
            this.lblTaillePad.Name = "lblTaillePad";
            this.lblTaillePad.Size = new System.Drawing.Size(65, 13);
            this.lblTaillePad.TabIndex = 10;
            this.lblTaillePad.Text = "Taille pad: 0";
            // 
            // EatbrickGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 561);
            this.Controls.Add(this.lblTaillePad);
            this.Controls.Add(this.lblNbBricks);
            this.Controls.Add(this.lblNbBall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.bntDemo);
            this.Controls.Add(this.gamepanel);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.bntNewgame);
            this.KeyPreview = true;
            this.Name = "EatbrickGUI";
            this.Text = "EatBrick -- Complément de Programmation -- Université de Poitiers";
            ((System.ComponentModel.ISupportInitialize)(this.gamepanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntNewgame;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox gamepanel;
        private System.Windows.Forms.Timer globalTimer;
        private System.Windows.Forms.OpenFileDialog loadNiveau;
        private System.Windows.Forms.Button bntDemo;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblNbBall;
        private System.Windows.Forms.Label lblNbBricks;
        private System.Windows.Forms.Label lblTaillePad;
    }
}

