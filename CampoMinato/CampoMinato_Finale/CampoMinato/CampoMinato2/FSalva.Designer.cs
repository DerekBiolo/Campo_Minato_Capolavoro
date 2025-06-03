namespace CampoMinato2
{
    partial class FSalva
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
            btn_Salva = new Button();
            tbx_NomeFile = new TextBox();
            label1 = new Label();
            btn_Close = new Button();
            SuspendLayout();
            // 
            // btn_Salva
            // 
            btn_Salva.BackColor = Color.Transparent;
            btn_Salva.Location = new Point(270, 192);
            btn_Salva.Name = "btn_Salva";
            btn_Salva.Size = new Size(150, 150);
            btn_Salva.TabIndex = 0;
            btn_Salva.UseVisualStyleBackColor = false;
            btn_Salva.Click += btn_Salva_Click;
            // 
            // tbx_NomeFile
            // 
            tbx_NomeFile.BackColor = Color.White;
            tbx_NomeFile.BorderStyle = BorderStyle.None;
            tbx_NomeFile.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            tbx_NomeFile.Location = new Point(195, 129);
            tbx_NomeFile.Name = "tbx_NomeFile";
            tbx_NomeFile.Size = new Size(300, 21);
            tbx_NomeFile.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bauhaus 93", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(140, 75);
            label1.Name = "label1";
            label1.Size = new Size(410, 34);
            label1.TabIndex = 2;
            label1.Text = "Inserisci il nome della partita";
            // 
            // btn_Close
            // 
            btn_Close.BackColor = Color.Transparent;
            btn_Close.Location = new Point(10, 10);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(50, 50);
            btn_Close.TabIndex = 3;
            btn_Close.UseVisualStyleBackColor = false;
            btn_Close.Click += btn_Close_Click;
            // 
            // FSalva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(690, 399);
            Controls.Add(btn_Close);
            Controls.Add(label1);
            Controls.Add(tbx_NomeFile);
            Controls.Add(btn_Salva);
            Name = "FSalva";
            Text = "FSalva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Salva;
        private TextBox tbx_NomeFile;
        private Label label1;
        private Button btn_Close;
    }
}