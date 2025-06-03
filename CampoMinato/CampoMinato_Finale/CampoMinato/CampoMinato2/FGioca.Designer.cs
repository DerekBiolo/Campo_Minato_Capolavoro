namespace CampoMinato2
{
    partial class FGioca
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
            lbl_grandezzagriglia = new Label();
            tbr_Griglia = new TrackBar();
            lbl_10x10 = new Label();
            lbl_30x30 = new Label();
            lbl_50x50 = new Label();
            lbl_50 = new Label();
            lbl_25 = new Label();
            lbl_10 = new Label();
            tbr_Bombe = new TrackBar();
            lbl_Bombe = new Label();
            btn_Gioca = new Button();
            btn_Esci = new Button();
            btn_Carica = new Button();
            ((System.ComponentModel.ISupportInitialize)tbr_Griglia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbr_Bombe).BeginInit();
            SuspendLayout();
            // 
            // lbl_grandezzagriglia
            // 
            lbl_grandezzagriglia.BackColor = Color.Transparent;
            lbl_grandezzagriglia.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_grandezzagriglia.Location = new Point(118, 31);
            lbl_grandezzagriglia.Name = "lbl_grandezzagriglia";
            lbl_grandezzagriglia.Size = new Size(298, 89);
            lbl_grandezzagriglia.TabIndex = 0;
            lbl_grandezzagriglia.Text = "Grandezza Griglia";
            lbl_grandezzagriglia.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbr_Griglia
            // 
            tbr_Griglia.BackColor = Color.FromArgb(192, 190, 188);
            tbr_Griglia.LargeChange = 1;
            tbr_Griglia.Location = new Point(34, 92);
            tbr_Griglia.Margin = new Padding(3, 4, 3, 4);
            tbr_Griglia.Maximum = 3;
            tbr_Griglia.Minimum = 1;
            tbr_Griglia.Name = "tbr_Griglia";
            tbr_Griglia.Size = new Size(420, 56);
            tbr_Griglia.TabIndex = 1;
            tbr_Griglia.Value = 3;
            // 
            // lbl_10x10
            // 
            lbl_10x10.BackColor = Color.Transparent;
            lbl_10x10.Location = new Point(34, 140);
            lbl_10x10.Name = "lbl_10x10";
            lbl_10x10.Size = new Size(35, 31);
            lbl_10x10.TabIndex = 2;
            lbl_10x10.Text = "5x5";
            // 
            // lbl_30x30
            // 
            lbl_30x30.BackColor = Color.Transparent;
            lbl_30x30.Location = new Point(246, 140);
            lbl_30x30.Name = "lbl_30x30";
            lbl_30x30.Size = new Size(53, 31);
            lbl_30x30.TabIndex = 4;
            lbl_30x30.Text = "10x10";
            // 
            // lbl_50x50
            // 
            lbl_50x50.BackColor = Color.Transparent;
            lbl_50x50.Location = new Point(442, 140);
            lbl_50x50.Name = "lbl_50x50";
            lbl_50x50.Size = new Size(63, 31);
            lbl_50x50.TabIndex = 6;
            lbl_50x50.Text = "15 x 15";
            // 
            // lbl_50
            // 
            lbl_50.BackColor = Color.Transparent;
            lbl_50.Location = new Point(470, 340);
            lbl_50.Name = "lbl_50";
            lbl_50.Size = new Size(45, 31);
            lbl_50.TabIndex = 11;
            lbl_50.Text = "50%";
            // 
            // lbl_25
            // 
            lbl_25.BackColor = Color.Transparent;
            lbl_25.Location = new Point(251, 340);
            lbl_25.Name = "lbl_25";
            lbl_25.Size = new Size(39, 31);
            lbl_25.TabIndex = 10;
            lbl_25.Text = "25%";
            // 
            // lbl_10
            // 
            lbl_10.BackColor = Color.Transparent;
            lbl_10.Location = new Point(34, 340);
            lbl_10.Name = "lbl_10";
            lbl_10.Size = new Size(40, 31);
            lbl_10.TabIndex = 9;
            lbl_10.Text = "10%";
            // 
            // tbr_Bombe
            // 
            tbr_Bombe.BackColor = Color.FromArgb(192, 190, 188);
            tbr_Bombe.LargeChange = 1;
            tbr_Bombe.Location = new Point(34, 300);
            tbr_Bombe.Margin = new Padding(3, 4, 3, 4);
            tbr_Bombe.Maximum = 3;
            tbr_Bombe.Minimum = 1;
            tbr_Bombe.Name = "tbr_Bombe";
            tbr_Bombe.Size = new Size(420, 56);
            tbr_Bombe.TabIndex = 8;
            tbr_Bombe.Value = 1;
            tbr_Bombe.Scroll += tbr_Bombe_Scroll;
            // 
            // lbl_Bombe
            // 
            lbl_Bombe.BackColor = Color.Transparent;
            lbl_Bombe.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Bombe.Location = new Point(123, 231);
            lbl_Bombe.Name = "lbl_Bombe";
            lbl_Bombe.Size = new Size(298, 89);
            lbl_Bombe.TabIndex = 7;
            lbl_Bombe.Text = "Numero Bombe";
            lbl_Bombe.TextAlign = ContentAlignment.TopCenter;
            // 
            // btn_Gioca
            // 
            btn_Gioca.BackColor = Color.Transparent;
            btn_Gioca.Location = new Point(89, 464);
            btn_Gioca.Margin = new Padding(3, 4, 3, 4);
            btn_Gioca.Name = "btn_Gioca";
            btn_Gioca.Size = new Size(145, 75);
            btn_Gioca.TabIndex = 12;
            btn_Gioca.UseVisualStyleBackColor = false;
            btn_Gioca.Click += btn_Gioca_Click;
            // 
            // btn_Esci
            // 
            btn_Esci.BackColor = Color.Transparent;
            btn_Esci.Location = new Point(277, 464);
            btn_Esci.Margin = new Padding(3, 4, 3, 4);
            btn_Esci.Name = "btn_Esci";
            btn_Esci.Size = new Size(145, 75);
            btn_Esci.TabIndex = 13;
            btn_Esci.UseVisualStyleBackColor = false;
            btn_Esci.Click += btn_Esci_Click;
            // 
            // btn_Carica
            // 
            btn_Carica.BackColor = Color.Transparent;
            btn_Carica.Location = new Point(192, 375);
            btn_Carica.Margin = new Padding(3, 4, 3, 4);
            btn_Carica.Name = "btn_Carica";
            btn_Carica.Size = new Size(145, 75);
            btn_Carica.TabIndex = 14;
            btn_Carica.UseVisualStyleBackColor = false;
            btn_Carica.Click += btn_Carica_Click;
            // 
            // FGioca
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 600);
            Controls.Add(btn_Carica);
            Controls.Add(btn_Esci);
            Controls.Add(btn_Gioca);
            Controls.Add(lbl_50);
            Controls.Add(lbl_25);
            Controls.Add(lbl_10);
            Controls.Add(tbr_Bombe);
            Controls.Add(lbl_Bombe);
            Controls.Add(lbl_50x50);
            Controls.Add(lbl_30x30);
            Controls.Add(lbl_10x10);
            Controls.Add(tbr_Griglia);
            Controls.Add(lbl_grandezzagriglia);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FGioca";
            Text = "FGioca";
            ((System.ComponentModel.ISupportInitialize)tbr_Griglia).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbr_Bombe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_grandezzagriglia;
        private TrackBar tbr_Griglia;
        private Label lbl_10x10;
        private Label lbl_30x30;
        private Label lbl_50x50;
        private Label lbl_50;
        private Label lbl_25;
        private Label lbl_10;
        private TrackBar tbr_Bombe;
        private Label lbl_Bombe;
        private Button btn_Gioca;
        private Button btn_Esci;
        private Button btn_Carica;
    }
}