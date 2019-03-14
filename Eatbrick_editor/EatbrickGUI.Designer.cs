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
            this.gamepanel = new System.Windows.Forms.PictureBox();
            this.globalTimer = new System.Windows.Forms.Timer(this.components);
            this.selectBrickKind = new System.Windows.Forms.GroupBox();
            this.layout = new System.Windows.Forms.FlowLayoutPanel();
            this.exportLevel = new System.Windows.Forms.Button();
            this.loadLevel = new System.Windows.Forms.Button();
            this.exportNiveauToFile = new System.Windows.Forms.SaveFileDialog();
            this.loadNiveauFromFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gamepanel)).BeginInit();
            this.selectBrickKind.SuspendLayout();
            this.SuspendLayout();
            // 
            // bntNewgame
            // 
            this.bntNewgame.Location = new System.Drawing.Point(12, 12);
            this.bntNewgame.Name = "bntNewgame";
            this.bntNewgame.Size = new System.Drawing.Size(107, 34);
            this.bntNewgame.TabIndex = 1;
            this.bntNewgame.Text = "Nouveau niveau";
            this.bntNewgame.UseVisualStyleBackColor = true;
            this.bntNewgame.Click += new System.EventHandler(this.bntNewgame_Click);
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
            this.gamepanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gamepanel_MouseDown);
            this.gamepanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gamepanel_MouseMove);
            this.gamepanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gamepanel_MouseUp);
            this.gamepanel.Move += new System.EventHandler(this.gamepanel_Move);
            // 
            // globalTimer
            // 
            this.globalTimer.Enabled = true;
            this.globalTimer.Interval = 20;
            this.globalTimer.Tick += new System.EventHandler(this.globalTimer_Tick);
            // 
            // selectBrickKind
            // 
            this.selectBrickKind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBrickKind.Controls.Add(this.layout);
            this.selectBrickKind.Location = new System.Drawing.Point(809, 53);
            this.selectBrickKind.Name = "selectBrickKind";
            this.selectBrickKind.Size = new System.Drawing.Size(200, 500);
            this.selectBrickKind.TabIndex = 5;
            this.selectBrickKind.TabStop = false;
            this.selectBrickKind.Text = "Type de briques";
            // 
            // layout
            // 
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layout.Location = new System.Drawing.Point(3, 16);
            this.layout.Name = "layout";
            this.layout.Size = new System.Drawing.Size(194, 481);
            this.layout.TabIndex = 0;
            // 
            // exportLevel
            // 
            this.exportLevel.Location = new System.Drawing.Point(695, 12);
            this.exportLevel.Name = "exportLevel";
            this.exportLevel.Size = new System.Drawing.Size(107, 34);
            this.exportLevel.TabIndex = 6;
            this.exportLevel.Text = "Exporte niveau";
            this.exportLevel.UseVisualStyleBackColor = true;
            this.exportLevel.Click += new System.EventHandler(this.exportLevel_Click);
            // 
            // loadLevel
            // 
            this.loadLevel.Location = new System.Drawing.Point(125, 12);
            this.loadLevel.Name = "loadLevel";
            this.loadLevel.Size = new System.Drawing.Size(107, 34);
            this.loadLevel.TabIndex = 7;
            this.loadLevel.Text = "Charger un niveau";
            this.loadLevel.UseVisualStyleBackColor = true;
            this.loadLevel.Click += new System.EventHandler(this.loadLevel_Click);
            // 
            // exportNiveauToFile
            // 
            this.exportNiveauToFile.DefaultExt = "cpe";
            this.exportNiveauToFile.Filter = "Niveau Eatbrick|*.cpe|Tous les fichiers|*.*";
            this.exportNiveauToFile.Title = "Sauvegarde d\'un niveau pour le jeu Eatbrick";
            // 
            // loadNiveauFromFile
            // 
            this.loadNiveauFromFile.DefaultExt = "cpe";
            this.loadNiveauFromFile.FileName = "openFileDialog1";
            this.loadNiveauFromFile.Filter = "Niveau Eatbrick|*.cpe|Tous les fichiers|*.*";
            this.loadNiveauFromFile.ShowReadOnly = true;
            this.loadNiveauFromFile.Title = "Chargement d\'un niveau Eatbrick existant";
            // 
            // EatbrickGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 561);
            this.Controls.Add(this.loadLevel);
            this.Controls.Add(this.exportLevel);
            this.Controls.Add(this.selectBrickKind);
            this.Controls.Add(this.gamepanel);
            this.Controls.Add(this.bntNewgame);
            this.KeyPreview = true;
            this.Name = "EatbrickGUI";
            this.Text = "EatBrick -- Complément de Programmation -- Université de Poitiers";
            ((System.ComponentModel.ISupportInitialize)(this.gamepanel)).EndInit();
            this.selectBrickKind.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntNewgame;
        private System.Windows.Forms.PictureBox gamepanel;
        private System.Windows.Forms.Timer globalTimer;
        private System.Windows.Forms.GroupBox selectBrickKind;
        private System.Windows.Forms.FlowLayoutPanel layout;
        private System.Windows.Forms.Button exportLevel;
        private System.Windows.Forms.Button loadLevel;
        private System.Windows.Forms.SaveFileDialog exportNiveauToFile;
        private System.Windows.Forms.OpenFileDialog loadNiveauFromFile;
    }
}

