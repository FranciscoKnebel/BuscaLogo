namespace BuscaLogo
{
    partial class Nova_Pesquisa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nova_Pesquisa));
            this.searchTextParameter = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numberTweetsParameter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.GeoPosBoxParameter = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radiusParameter = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.langParameter = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tweetSearchTypeParameter = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberTweetsParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTextParameter
            // 
            this.searchTextParameter.Location = new System.Drawing.Point(65, 34);
            this.searchTextParameter.Name = "searchTextParameter";
            this.searchTextParameter.Size = new System.Drawing.Size(223, 20);
            this.searchTextParameter.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(78, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 25);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Texto";
            // 
            // numberTweetsParameter
            // 
            this.numberTweetsParameter.Location = new System.Drawing.Point(108, 61);
            this.numberTweetsParameter.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numberTweetsParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberTweetsParameter.Name = "numberTweetsParameter";
            this.numberTweetsParameter.Size = new System.Drawing.Size(87, 20);
            this.numberTweetsParameter.TabIndex = 4;
            this.numberTweetsParameter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max Tweets";
            // 
            // GeoPosBoxParameter
            // 
            this.GeoPosBoxParameter.Items.AddRange(new object[] {
            "<undefined>",
            "Campus Centro",
            "Campus do Vale",
            "Hospital de Clínicas",
            "Aeroporto Salgado Filho",
            "Mercado Público",
            "Cristo Redentor",
            "Aeropuerto Tegucigalpa"});
            this.GeoPosBoxParameter.Location = new System.Drawing.Point(311, 34);
            this.GeoPosBoxParameter.Name = "GeoPosBoxParameter";
            this.GeoPosBoxParameter.Size = new System.Drawing.Size(141, 186);
            this.GeoPosBoxParameter.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(341, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Geolocal";
            // 
            // radiusParameter
            // 
            this.radiusParameter.DecimalPlaces = 1;
            this.radiusParameter.Location = new System.Drawing.Point(387, 232);
            this.radiusParameter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.radiusParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.radiusParameter.Name = "radiusParameter";
            this.radiusParameter.Size = new System.Drawing.Size(50, 20);
            this.radiusParameter.TabIndex = 9;
            this.radiusParameter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(314, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Raio (Km)";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(110, 210);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(85, 18);
            this.progressBar.TabIndex = 11;
            this.progressBar.Visible = false;
            // 
            // langParameter
            // 
            this.langParameter.FormattingEnabled = true;
            this.langParameter.Location = new System.Drawing.Point(97, 87);
            this.langParameter.Name = "langParameter";
            this.langParameter.Size = new System.Drawing.Size(120, 56);
            this.langParameter.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(12, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Linguagem";
            // 
            // tweetSearchTypeParameter
            // 
            this.tweetSearchTypeParameter.FormattingEnabled = true;
            this.tweetSearchTypeParameter.Items.AddRange(new object[] {
            "Todos os Tweets",
            "Excluir Retweets",
            "Apenas Retweets"});
            this.tweetSearchTypeParameter.Location = new System.Drawing.Point(97, 149);
            this.tweetSearchTypeParameter.Name = "tweetSearchTypeParameter";
            this.tweetSearchTypeParameter.Size = new System.Drawing.Size(120, 43);
            this.tweetSearchTypeParameter.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(48, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tipos";
            // 
            // Nova_Pesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::BuscaLogo.Properties.Resources.wpp2;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tweetSearchTypeParameter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.langParameter);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radiusParameter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GeoPosBoxParameter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberTweetsParameter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchTextParameter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nova_Pesquisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova Pesquisa";
            this.Load += new System.EventHandler(this.Nova_Pesquisa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numberTweetsParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusParameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numberTweetsParameter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox GeoPosBoxParameter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown radiusParameter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox langParameter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox tweetSearchTypeParameter;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button button1;
    }
}