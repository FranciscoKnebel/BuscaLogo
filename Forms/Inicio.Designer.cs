namespace BuscaLogo
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.MenuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sobreOProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IconAreaNotif = new System.Windows.Forms.NotifyIcon(this.components);
            this.NovaPesquisa = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.TweetReaderButton = new System.Windows.Forms.Button();
            this.MenuContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuContext
            // 
            this.MenuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreOProgramaToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.MenuContext.Name = "contextMenuStrip1";
            this.MenuContext.ShowImageMargin = false;
            this.MenuContext.Size = new System.Drawing.Size(154, 48);
            // 
            // sobreOProgramaToolStripMenuItem
            // 
            this.sobreOProgramaToolStripMenuItem.Name = "sobreOProgramaToolStripMenuItem";
            this.sobreOProgramaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sobreOProgramaToolStripMenuItem.Text = "Sobre o programa...";
            this.sobreOProgramaToolStripMenuItem.Click += new System.EventHandler(this.sobreOProgramaToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // IconAreaNotif
            // 
            this.IconAreaNotif.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IconAreaNotif.ContextMenuStrip = this.MenuContext;
            this.IconAreaNotif.Icon = ((System.Drawing.Icon)(resources.GetObject("IconAreaNotif.Icon")));
            this.IconAreaNotif.Text = "BuscaLogo";
            this.IconAreaNotif.Visible = true;
            this.IconAreaNotif.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IconAreaNotif_MouseDoubleClick);
            // 
            // NovaPesquisa
            // 
            this.NovaPesquisa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NovaPesquisa.Location = new System.Drawing.Point(12, 12);
            this.NovaPesquisa.Name = "NovaPesquisa";
            this.NovaPesquisa.Size = new System.Drawing.Size(116, 30);
            this.NovaPesquisa.TabIndex = 4;
            this.NovaPesquisa.Text = "Nova Pesquisa";
            this.NovaPesquisa.UseVisualStyleBackColor = true;
            this.NovaPesquisa.Click += new System.EventHandler(this.NovaPesquisa_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(249, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 30);
            this.button4.TabIndex = 5;
            this.button4.Text = "Carregar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(249, 219);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 30);
            this.button5.TabIndex = 6;
            this.button5.Text = "Deletar";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Image = global::BuscaLogo.Properties.Resources.bird;
            this.Logo.Location = new System.Drawing.Point(12, 38);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(254, 214);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 3;
            this.Logo.TabStop = false;
            // 
            // TweetReaderButton
            // 
            this.TweetReaderButton.Location = new System.Drawing.Point(191, 12);
            this.TweetReaderButton.Name = "TweetReaderButton";
            this.TweetReaderButton.Size = new System.Drawing.Size(116, 30);
            this.TweetReaderButton.TabIndex = 7;
            this.TweetReaderButton.Text = "Leitor de Tweet";
            this.TweetReaderButton.UseVisualStyleBackColor = true;
            this.TweetReaderButton.Click += new System.EventHandler(this.TweetReaderButton_Click);
            // 
            // Inicio
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::BuscaLogo.Properties.Resources.wpp2;
            this.ClientSize = new System.Drawing.Size(319, 261);
            this.ContextMenuStrip = this.MenuContext;
            this.Controls.Add(this.TweetReaderButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.NovaPesquisa);
            this.Controls.Add(this.Logo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscaLogo ";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.MenuContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MenuContext;
        private System.Windows.Forms.ToolStripMenuItem sobreOProgramaToolStripMenuItem;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.NotifyIcon IconAreaNotif;
        private System.Windows.Forms.Button NovaPesquisa;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.Button TweetReaderButton;
    }
}

