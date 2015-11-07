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
            this.TweetTextbox.Size = new System.Drawing.Size(288, 194);
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
            this.TweetDateTime.Location = new System.Drawing.Point(150, 262);
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
            this.TweetRefresh.Location = new System.Drawing.Point(118, 399);
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
            this.imageFV.Location = new System.Drawing.Point(12, 285);
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
            this.TweetFavourites.Location = new System.Drawing.Point(42, 291);
            this.TweetFavourites.Name = "TweetFavourites";
            this.TweetFavourites.Size = new System.Drawing.Size(86, 13);
            this.TweetFavourites.TabIndex = 12;
            this.TweetFavourites.Text = "TweetFavourites";
            // 
            // Tweet_Reader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 465);
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
    }
}