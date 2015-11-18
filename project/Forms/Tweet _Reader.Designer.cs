namespace BuscaLogo.Forms
{
    partial class Tweet_Reader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tweet_Reader));
            this.TweetTextbox = new System.Windows.Forms.RichTextBox();
            this.TweetName = new System.Windows.Forms.Label();
            this.TweetDisplayName = new System.Windows.Forms.Label();
            this.TweetDateTime = new System.Windows.Forms.Label();
            this.TweetList = new System.Windows.Forms.ListBox();
            this.TweetRefresh = new System.Windows.Forms.Button();
            this.BackgroundNull = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageRT = new System.Windows.Forms.PictureBox();
            this.imageFV = new System.Windows.Forms.PictureBox();
            this.TweetRetweets = new System.Windows.Forms.Label();
            this.TweetFavourites = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.crescentOrder = new System.Windows.Forms.RadioButton();
            this.decrescentOrder = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buscaUsuario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundNull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFV)).BeginInit();
            this.SuspendLayout();
            // 
            // TweetTextbox
            // 
            this.TweetTextbox.Location = new System.Drawing.Point(12, 57);
            this.TweetTextbox.Name = "TweetTextbox";
            this.TweetTextbox.ReadOnly = true;
            this.TweetTextbox.Size = new System.Drawing.Size(288, 169);
            this.TweetTextbox.TabIndex = 0;
            this.TweetTextbox.Text = "";
            // 
            // TweetName
            // 
            this.TweetName.Location = new System.Drawing.Point(12, 41);
            this.TweetName.Name = "TweetName";
            this.TweetName.Size = new System.Drawing.Size(150, 13);
            this.TweetName.TabIndex = 1;
            this.TweetName.Text = "TweetName";
            // 
            // TweetDisplayName
            // 
            this.TweetDisplayName.Location = new System.Drawing.Point(180, 41);
            this.TweetDisplayName.Name = "TweetDisplayName";
            this.TweetDisplayName.Size = new System.Drawing.Size(120, 13);
            this.TweetDisplayName.TabIndex = 2;
            this.TweetDisplayName.Text = "TweetUsername";
            this.TweetDisplayName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TweetDateTime
            // 
            this.TweetDateTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TweetDateTime.Location = new System.Drawing.Point(150, 236);
            this.TweetDateTime.Name = "TweetDateTime";
            this.TweetDateTime.Size = new System.Drawing.Size(150, 13);
            this.TweetDateTime.TabIndex = 3;
            this.TweetDateTime.Text = "TweetDateTime";
            this.TweetDateTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TweetList
            // 
            this.TweetList.FormattingEnabled = true;
            this.TweetList.Location = new System.Drawing.Point(373, 41);
            this.TweetList.Name = "TweetList";
            this.TweetList.Size = new System.Drawing.Size(154, 381);
            this.TweetList.TabIndex = 4;
            this.TweetList.SelectedIndexChanged += new System.EventHandler(this.Tweet_ShowSelected);
            // 
            // TweetRefresh
            // 
            this.TweetRefresh.Location = new System.Drawing.Point(183, 252);
            this.TweetRefresh.Name = "TweetRefresh";
            this.TweetRefresh.Size = new System.Drawing.Size(75, 23);
            this.TweetRefresh.TabIndex = 5;
            this.TweetRefresh.Text = "Refresh";
            this.TweetRefresh.UseVisualStyleBackColor = true;
            this.TweetRefresh.Click += new System.EventHandler(this.TweetRefresh_Click);
            // 
            // BackgroundNull
            // 
            this.BackgroundNull.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundNull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundNull.Image = global::BuscaLogo.Properties.Resources.birdQ;
            this.BackgroundNull.Location = new System.Drawing.Point(0, 0);
            this.BackgroundNull.Name = "BackgroundNull";
            this.BackgroundNull.Size = new System.Drawing.Size(548, 465);
            this.BackgroundNull.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackgroundNull.TabIndex = 6;
            this.BackgroundNull.TabStop = false;
            this.BackgroundNull.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nenhum tweet carregado!";
            this.label1.Visible = false;
            // 
            // imageRT
            // 
            this.imageRT.BackColor = System.Drawing.Color.Transparent;
            this.imageRT.Image = global::BuscaLogo.Properties.Resources.retweet_action_on;
            this.imageRT.Location = new System.Drawing.Point(12, 255);
            this.imageRT.Name = "imageRT";
            this.imageRT.Size = new System.Drawing.Size(24, 24);
            this.imageRT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageRT.TabIndex = 8;
            this.imageRT.TabStop = false;
            // 
            // imageFV
            // 
            this.imageFV.Image = global::BuscaLogo.Properties.Resources.like_action_on;
            this.imageFV.Location = new System.Drawing.Point(12, 229);
            this.imageFV.Name = "imageFV";
            this.imageFV.Size = new System.Drawing.Size(24, 24);
            this.imageFV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageFV.TabIndex = 10;
            this.imageFV.TabStop = false;
            // 
            // TweetRetweets
            // 
            this.TweetRetweets.AutoSize = true;
            this.TweetRetweets.Location = new System.Drawing.Point(42, 262);
            this.TweetRetweets.Name = "TweetRetweets";
            this.TweetRetweets.Size = new System.Drawing.Size(82, 13);
            this.TweetRetweets.TabIndex = 11;
            this.TweetRetweets.Text = "TweetRetweets";
            // 
            // TweetFavourites
            // 
            this.TweetFavourites.AutoSize = true;
            this.TweetFavourites.Location = new System.Drawing.Point(42, 236);
            this.TweetFavourites.Name = "TweetFavourites";
            this.TweetFavourites.Size = new System.Drawing.Size(86, 13);
            this.TweetFavourites.TabIndex = 12;
            this.TweetFavourites.Text = "TweetFavourites";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Por data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Por usuário";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // crescentOrder
            // 
            this.crescentOrder.AutoSize = true;
            this.crescentOrder.Checked = true;
            this.crescentOrder.Location = new System.Drawing.Point(224, 347);
            this.crescentOrder.Name = "crescentOrder";
            this.crescentOrder.Size = new System.Drawing.Size(73, 17);
            this.crescentOrder.TabIndex = 15;
            this.crescentOrder.TabStop = true;
            this.crescentOrder.Text = "Crescente";
            this.crescentOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.crescentOrder.UseVisualStyleBackColor = true;
            // 
            // decrescentOrder
            // 
            this.decrescentOrder.AutoSize = true;
            this.decrescentOrder.Location = new System.Drawing.Point(224, 370);
            this.decrescentOrder.Name = "decrescentOrder";
            this.decrescentOrder.Size = new System.Drawing.Size(86, 17);
            this.decrescentOrder.TabIndex = 16;
            this.decrescentOrder.Text = "Decrescente";
            this.decrescentOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.decrescentOrder.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Por nome";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(113, 326);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "Por nº retweets";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(113, 355);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 23);
            this.button5.TabIndex = 19;
            this.button5.Text = "Por nº favoritos";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(113, 384);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 23);
            this.button6.TabIndex = 20;
            this.button6.Text = "Por ID do tweet";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // buscaUsuario
            // 
            this.buscaUsuario.Location = new System.Drawing.Point(45, 430);
            this.buscaUsuario.Name = "buscaUsuario";
            this.buscaUsuario.Size = new System.Drawing.Size(117, 23);
            this.buscaUsuario.TabIndex = 21;
            this.buscaUsuario.Text = "Buscar por usuário";
            this.buscaUsuario.UseVisualStyleBackColor = true;
            this.buscaUsuario.Click += new System.EventHandler(this.buscaUsuario_Click);
            // 
            // Tweet_Reader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 465);
            this.Controls.Add(this.buscaUsuario);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.decrescentOrder);
            this.Controls.Add(this.crescentOrder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TweetFavourites);
            this.Controls.Add(this.TweetRetweets);
            this.Controls.Add(this.imageFV);
            this.Controls.Add(this.imageRT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TweetRefresh);
            this.Controls.Add(this.TweetList);
            this.Controls.Add(this.TweetDateTime);
            this.Controls.Add(this.TweetDisplayName);
            this.Controls.Add(this.TweetName);
            this.Controls.Add(this.TweetTextbox);
            this.Controls.Add(this.BackgroundNull);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tweet_Reader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leitor de Tweet";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundNull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TweetTextbox;
        private System.Windows.Forms.Label TweetName;
        private System.Windows.Forms.Label TweetDisplayName;
        private System.Windows.Forms.Label TweetDateTime;
        private System.Windows.Forms.ListBox TweetList;
        private System.Windows.Forms.Button TweetRefresh;
        private System.Windows.Forms.PictureBox BackgroundNull;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imageRT;
        private System.Windows.Forms.PictureBox imageFV;
        private System.Windows.Forms.Label TweetRetweets;
        private System.Windows.Forms.Label TweetFavourites;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton crescentOrder;
        private System.Windows.Forms.RadioButton decrescentOrder;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buscaUsuario;
    }
}